﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGlide : IState
{
    private readonly playerControl player;
    private PlayerInputs input;
    // private const float newGravity = -2.0f;
    private float horizontalMovement = 0f;
    private glideType method = 0;
    public enum glideType {Jump, Down}

    //Get references to both animator and sprite renderer. -Joel
    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerGlide(playerControl p, glideType glideMethod)
    {
        player = p;
        input = p.input;
        method = glideMethod;
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
    }
    public void Enter()
    {
        // use glide animation here:
        animator.Play("PlayerGlide");

        // Halt vertical movement
        player.GetComponent<Rigidbody>().useGravity = false;
        float xMovement = input.Gameplay.MoveX.ReadValue<float>();
        player.GetComponent<Rigidbody>().velocity = new Vector3(xMovement, 0f, 0f);
    }

    public void Exit()
    {
        // Reset gravity
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    public void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, player.GLIDE_GRAVITY, 0f));
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // Check input for exiting glide state while airborne
        if((method.Equals(glideType.Jump) && input.Gameplay.Jump.ReadValue<float>() == 0f) ||
           (method.Equals(glideType.Down) && input.Gameplay.Glide.ReadValue<float>() == 0f))
        {
            return new PlayerMove(player, true);
        }

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

        // If jumps get refreshed, i.e. landing on a platform
        if(player.data.maxSpeed == player.data.groundSpeed &&
           player.data.numJumps == player.CONSTANTS.MAX_JUMPS)
        {
            return new PlayerIdle(player);
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
