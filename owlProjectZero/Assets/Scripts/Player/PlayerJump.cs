///////////////////////////////////
//                               //
// ADD GLIDE TIMER               //
// - a.k.a. the time it takes to //
//   enter the glide state       //
//                               //
///////////////////////////////////

// Not sure why I added this comment before
//                      - Charles



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private PlayerInputs input;
    private float horizontalMovement = 0f;

    public PlayerJump(playerControl p)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        input = p.input;
    }
    public void Enter()
    {
        // use jump animation here

        player.Jump();

        input.Gameplay.Tether.started += player.ActivateTether;
        input.Gameplay.Glide.started += player.FastFall;
    }

    public void Exit()
    {
        input.Gameplay.Tether.started -= player.ActivateTether;
        input.Gameplay.Glide.started -= player.FastFall;
    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // Check input for changing skills


        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.numDodges > 0)
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
            if(player.maxSpeed == player.groundSpeed &&
               player.numJumps == playerControl.MAX_JUMPS)
            {
                return new PlayerIdle(player);
            }
        }

        // Check for downwards input
        if(input.Gameplay.Glide.ReadValue<float>() > 0.975f)
        {
            if(Mathf.Abs(playerBody.velocity.y) <= 3f)
                return new PlayerWalk(player, true);

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
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        return null;
    }

    private void DoubleJump(InputAction.CallbackContext context)
    {
        // if(context.startTime == context.duration)
        Debug.Log("Double Jump is called");
        player.Jump();
    }

    private void GlideByJump(InputAction.CallbackContext context)
    {
        if(context.time == context.duration)
            Debug.Log("Should glide now");
        Debug.Log("Value: " + context.ReadValue<float>());
        Debug.Log("Time: " + context.time);
        Debug.Log("Duration: " + context.duration);
    }
}
