

///////////////////////////////////
//                               //
// ADD GLIDE TIMER               //
// - a.k.a. the time it takes to //
//   enter the glide state       //
//                               //
///////////////////////////////////








using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private PlayerInputs.JumpingActions jumpInput;
    private float horizontalMovement = 0f;
    // private float jumpCooldown = 0.06f;

    public PlayerJump(playerControl p)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        jumpInput = p.input.Jumping;
        jumpInput.DoubleJump.started += DoubleJump;
        jumpInput.DoubleJump.performed += GlideByJump;
    }
    public void Enter()
    {
        // use jump animation here

        player.Jump();

        jumpInput.FastFall.Disable();
    }

    public void Exit()
    {
        jumpInput.DoubleJump.started -= DoubleJump;
        jumpInput.DoubleJump.performed -= GlideByJump;
    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // Check input for tether
        if(player.activeTetherPoint != null &&
        //    Input.GetKeyDown(KeyCode.T) &&
           jumpInput.Tether.triggered &&
           player.transform.position.y <= player.activeTetherPoint.transform.position.y)
        {
            return new PlayerTether(player);
        }

        // Check input for changing skills


        // Check input for dodging
        // if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
        if(jumpInput.Dodge.triggered && player.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for melee attacking
        // if(Input.GetButtonDown("Fire1"))
        if(jumpInput.Melee.triggered)
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        // if(Input.GetButtonDown("Fire2"))
        if(jumpInput.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }                 

        // Check if descending
        if(playerBody.velocity.y <= 0)
        {
            // If jumps get refreshed, i.e. landing on a platform
            if(player.maxSpeed == player.groundSpeed &&
               player.numJumps == playerControl.MAX_JUMPS)
            {
                return new PlayerIdle(player);
            }
            // else if(Input.GetButton("Jump"))
            // else if(jumpInput.DoubleJump.ReadValue<float>() > 0)
            //     return new PlayerGlide(player, PlayerGlide.glideType.Jump);
        }

        // if(Input.GetKey(KeyCode.DownArrow) ||
        //    Input.GetKey(KeyCode.S))
        // {
        //     // Check for fastfall input during fastfall window
        //     if(playerBody.velocity.y < 0f &&
        //        playerBody.velocity.y > -2f)
        //     {
        //         return new PlayerWalk(player, true);
        //     }
        //     // Check if cancelling into glide
        //     else
        //     {
        //         return new PlayerGlide(player, PlayerGlide.glideType.Down);
        //     }
        // }

        // Check for fastfall input during fastfall window
        if(playerBody.velocity.y < 0f &&
            playerBody.velocity.y > -2f)
        {
            jumpInput.FastFall.Enable();
            if(jumpInput.FastFall.triggered)
                return new PlayerWalk(player, true);
        }

        if(jumpInput.Glide.ReadValue<float>() > 0.8f)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //  This Chunk of code is also in PlayerWalk                       //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////
        horizontalMovement = jumpInput.Fly.ReadValue<float>();
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
