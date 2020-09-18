using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : IState
{
    private readonly playerControl player;
    private AudioSource jump;
    private Rigidbody playerBody;
    private PlayerInputs input;
    private float horizontalMovement = 0f;

    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerJump(playerControl p)
    {
        player = p;
        jump = p.gameObject.GetComponentInChildren<AudioSource>();
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        //Need to pass references. - Joel
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
        
        input = p.input;
    }
    public void Enter()
    {
        // use jump animation here
    	if(player.data.numJumps > 0){
    		jump.Play();
    	}
        player.Jump();
        // animator.SetBool("jumpup", true);

        input.Gameplay.Tether.started += player.tetherAbility.ActivateTether;
        input.Gameplay.Glide.started += player.FastFall;
    }

    public void Exit()
    {
        // animator.SetBool("jumpup", false);
        animator.SetFloat("VerticalMovement", 0f);
        
        input.Gameplay.Tether.started -= player.tetherAbility.ActivateTether;
        input.Gameplay.Glide.started -= player.FastFall;
    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
        //Also checking Vertical speed.
        animator.SetFloat("VerticalMovement", playerBody.velocity.y);
    }

    public IState Update()
    {
        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for double jumping
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

        // Check if descending
        if(playerBody.velocity.y <= 0)
        {
            if(input.Gameplay.Jump.ReadValue<float>() == 1f)
                return new PlayerGlide(player, PlayerGlide.glideType.Jump);
                
            // If jumps get refreshed, i.e. landing on a platform
            if(player.data.maxSpeed == player.data.groundSpeed &&
               player.data.numJumps == player.CONSTANTS.MAX_JUMPS)
            {
                return new PlayerIdle(player);
            }
        }

        // Check for downwards input
        if(input.Gameplay.Glide.ReadValue<float>() > 0.975f)
        {
            if(Mathf.Abs(playerBody.velocity.y) <= 3f)
                return new PlayerMove(player, true);

            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //  This Chunk of code is also in PlayerWalk                       //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////
        horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
            spriterenderer.flipX = !player.data.isFacingRight;
        }
        return null;
    }
}
