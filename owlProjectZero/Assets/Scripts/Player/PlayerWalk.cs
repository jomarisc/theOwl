using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : IState
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


    // Maybe add another argument in constructor that determines
    // whether the player is grounded or not bc I'm considering having this
    // state govern strictly horizontal movement; grounded or otherwise
    public PlayerWalk(playerControl p, bool isAirborne)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        input = p.input;
        isFlying = isAirborne;
        
        //Trying to pass a reference to the Animator/Renderer components here. 
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
        // verticalMovement = (isAirborne) ? playerBody.velocity.y : 0f;
    }
    public void Enter()
    {
        if (isFlying)
        {
            // use descending animation here:
            animator.SetBool("walking", false);
            animator.SetBool("idling", false);

            input.Gameplay.Tether.started += player.ActivateTether;
            input.Gameplay.Glide.started += player.FastFall;
            input.Gameplay.Glide.started += Glide;
        }
        else
        {
            // Use walking animation here
            animator.SetBool("walking", true);
            animator.SetBool("jumpup", false);
            animator.SetBool("jumpdown", false);
        }
    }

    public void Exit()
    {
        animator.SetBool("walking", false);
        animator.SetBool("jumpup", false);
        // isFastFalling = false;
        input.Gameplay.Tether.started -= player.ActivateTether;
        input.Gameplay.Glide.started -= player.FastFall;
        input.Gameplay.Glide.started -= Glide;

        verticalMovement = 0f;
    }

    public void FixedUpdate()
    {
        if(isFlying)
        {
            if((player.inGuntime && verticalMovement != playerControl.FAST_FALL_SPEED * 2) ||
               (!player.inGuntime && verticalMovement != playerControl.FAST_FALL_SPEED))
                    verticalMovement = playerBody.velocity.y;
        }
        else
            verticalMovement = playerBody.velocity.y;
        player.MoveCharacter(horizontalMovement, verticalMovement);

        //Also checking Vertical speed.
        animator.SetFloat("VerticalMovement", verticalMovement);
        animator.SetFloat("horizontalMovement", horizontalMovement);
    }

    public IState Update()
    {
        //Check Horizontal Movement. Flip accordingly.
        if (horizontalMovement > 0) 
        {
            animator.SetBool("walking", true);
            animator.SetBool("idling", false);
            spriterenderer.flipX = false; 
        }
        else if (horizontalMovement < 0) 
        {
            animator.SetBool("walking", true);
            animator.SetBool("idling", false);
            spriterenderer.flipX = true; 
        }
        else 
        { 
            animator.SetBool("walking", false);
            animator.SetBool("idling", true);
        }

        // Check input for changing skills




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
            Debug.Log("Landing");
            // isFastFalling = false;
            return new PlayerWalk(player, false);
            
        }

        // If leaving a platform
        if(!isFlying &&
           player.data.maxSpeed == player.data.airSpeed)
        {
            Debug.Log("Left platform");
            return new PlayerWalk(player, true);
        }

        horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        if(Mathf.Abs(horizontalMovement) > 0 ||
           player.data.maxSpeed == player.data.airSpeed)
        {
            player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
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
