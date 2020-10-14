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
    public void Enter()
    {
        // animator.SetBool("moving", true);
        if (isFlying)
        {
            // Debug.Log(input.Gameplay.Glide.phase);
            // Debug.Break();
            // use descending animation here:
            // animator.SetFloat("VerticalMovement", playerBody.velocity.y);
            // animator.Play("PlayerJumpDown");
            if(!animator.GetBool("fastfalling"))
            //     animator.Play("PlayerFastFall");
            // else
                if(playerBody.velocity.y > 0f)
                    animator.Play("PlayerJumpUp");
                else
                    animator.Play("PlayerJumpDown");

            input.Gameplay.Tether.started += player.tetherAbility.ActivateTether;
            input.Gameplay.Glide.started += player.FastFall;
            input.Gameplay.Glide.started += Glide;
        }
        else
        {
            // Use walking animation here
            // verticalMovement = 0f;
            // animator.SetFloat("VerticalMovement", verticalMovement);
            animator.Play("PlayerWalk");
        }
    }

    public void Exit()
    {
        // animator.SetBool("moving", false);
        animator.SetBool("fastfalling", false);

        input.Gameplay.Tether.started -= player.tetherAbility.ActivateTether;
        input.Gameplay.Glide.started -= player.FastFall;
        input.Gameplay.Glide.started -= Glide;

        verticalMovement = 0f;
    }

    public void FixedUpdate()
    {
        if(isFlying)
        {
            if((player.inGuntime && verticalMovement != player.FAST_FALL_SPEED * 2) ||
               (!player.inGuntime && verticalMovement != player.FAST_FALL_SPEED))
                    verticalMovement = playerBody.velocity.y;
        }
        else
            verticalMovement = playerBody.velocity.y;
        player.MoveCharacter(horizontalMovement, verticalMovement);
    }

    public IState Update()
    {
        // if(isFlying)
        //     animator.SetFloat("VerticalMovement", playerBody.velocity.y);

        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        if(input.Gameplay.Jump.triggered)
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        if(input.Gameplay.Melee.triggered)
        {
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }

        if(isGliding)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

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
            Debug.Log("Left platform");
            // animator.Play("PlayerJumpDown");
            return new PlayerMove(player, true);
        }

        horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        // animator.SetFloat("horizontalMovement", horizontalMovement);
        if(Mathf.Abs(horizontalMovement) > 0 || isFlying)
        {
            player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
            spriterenderer.flipX = !player.data.isFacingRight;
            return null;
        }
        else
        {
            return new PlayerIdle(player);
        }
    }

    public void Glide(InputAction.CallbackContext context)
    {
        if(Mathf.Abs(playerBody.velocity.y) > 3f)
        {
            isGliding = true;
        }
    }
}
