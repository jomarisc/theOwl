using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private PlayerInputs input;
    private float horizontalMovement = 0f;
    private bool isFlying = false;
    private bool isGliding = false;
    private string myAnimationState;
    public static float verticalMovement = 0f;


    //Reference to animator/renderer.
    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerMove(playerControl p, bool isAirborne)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        input = p.input;
        isFlying = isAirborne;
        
        //Trying to pass a reference to the Animator/Renderer components here. 
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
    }

    public PlayerMove(playerControl p, bool isAirborne, float hm)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        input = p.input;
        isFlying = isAirborne;
        
        //Trying to pass a reference to the Animator/Renderer components here. 
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
        horizontalMovement = hm;
    }
    public void Enter()
    {
        int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        if (isFlying)
        {
            // Player the appropriate animation here:
            bool isFastfalling = (player.inGuntime && verticalMovement == player.FAST_FALL_SPEED * 2) ||
                                 (!player.inGuntime && verticalMovement == player.FAST_FALL_SPEED);
            if(!animator.GetBool("fastfalling") && !isFastfalling)
            {
                if(playerBody.velocity.y > 0f)
                    myAnimationState = "PlayerJumpUp";
                else
                    myAnimationState = "PlayerJumpDown";
            }
            else
                myAnimationState = "PlayerFastFall";
            animator.Play(myAnimationState, animationLayer);

            // If player's data.maxSpeed == 0 (Ex: Start of a scene)
            if(player.data.maxSpeed == 0f)
                player.data.maxSpeed = player.data.airSpeed;

            input.Gameplay.Tether.started += player.tetherAbility.ActivateTether;
            input.Gameplay.Glide.started += player.FastFall;
            input.Gameplay.Glide.started += Glide;
        }
        else
        {
            // Use walking animation here
            animator.Play("PlayerWalk", animationLayer);
        }
    }

    public void Exit()
    {
        animator.SetBool("fastfalling", false);

        input.Gameplay.Tether.started -= player.tetherAbility.ActivateTether;
        input.Gameplay.Glide.started -= player.FastFall;
        input.Gameplay.Glide.started -= Glide;

        verticalMovement = 0f;
    }

    public void FixedUpdate()
    {
        // if(isFlying)
        // {
            bool isFastfalling = (player.inGuntime && verticalMovement == player.FAST_FALL_SPEED * 2) ||
                                 (!player.inGuntime && verticalMovement == player.FAST_FALL_SPEED);
            if(!isFastfalling)
                    verticalMovement = playerBody.velocity.y;
        // }
        // else
        //     verticalMovement = playerBody.velocity.y;
        player.MoveCharacter(horizontalMovement, verticalMovement);
    }

    public IState Update()
    {
        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
            return new PlayerDodge(player);

        // Check input for jumping
        if(input.Gameplay.Jump.triggered)
            return new PlayerJump(player);

        // Check input for melee attacking
        if(input.Gameplay.Melee.triggered)
            return new PlayerMelee(player, horizontalMovement);

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
            return new PlayerShoot(player);

        if(isGliding)
            return new PlayerGlide(player, PlayerGlide.glideType.Down);

        // If landing on a platform
        if(isFlying &&
           player.data.maxSpeed == player.data.groundSpeed)
        {
            return new PlayerMove(player, false);
        }

        // If leaving a platform
        if(!isFlying &&
           player.data.maxSpeed == player.data.airSpeed)
        {
            // Debug.Log("Left platform");
            return new PlayerMove(player, true);
        }

        if(isFlying &&
           !animator.GetBool("fastfalling") &&
           myAnimationState.Equals("PlayerJumpUp") &&
           playerBody.velocity.y < 0f)
        {
            myAnimationState = "PlayerJumpDown";
            int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
            animator.Play(myAnimationState, animationLayer);
        }

        horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        // if(Mathf.Abs(horizontalMovement) > 0 || isFlying)
        // {
        //     player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
        //     spriterenderer.flipX = !player.data.isFacingRight;
        //     return null;
        // }
        // else
        if(horizontalMovement == 0f && !isFlying)
            return new PlayerIdle(player);
        
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
            spriterenderer.flipX = !player.data.isFacingRight;
        }

        return null;
    }

    public void Glide(InputAction.CallbackContext context)
    {
        if(Mathf.Abs(playerBody.velocity.y) > 3f)
            isGliding = true;
    }
}
