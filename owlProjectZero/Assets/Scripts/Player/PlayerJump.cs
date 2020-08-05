

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

public class PlayerJump : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private float horizontalMovement = 0f;
    // private float jumpCooldown = 0.06f;

    public PlayerJump(playerControl p)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
    }
    public void Enter()
    {
        // use jump animation here

        player.Jump();
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // Check input for tether
        if(player.activeTetherPoint != null &&
           Input.GetKeyDown(KeyCode.T) &&
           player.transform.position.y <= player.activeTetherPoint.transform.position.y)
        {
            return new PlayerTether(player);
        }

        // Check input for changing skills

        // Check input for double jump
        if(Input.GetButtonDown("Jump"))
        {
            // player.numJumps--;
            return new PlayerJump(player);
        }

        // Check input for dodging
        if(Input.GetButtonDown("Fire3") && player.data.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for melee attacking
        if(Input.GetButtonDown("Fire1"))
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        if(Input.GetButtonDown("Fire2"))
        {
            return new PlayerShoot(player);
        }                 

        // Check if descending
        if(playerBody.velocity.y <= 0)
        {
            // If jumps get refreshed, i.e. landing on a platform
            if(player.data.maxSpeed == player.data.groundSpeed &&
               player.data.numJumps == player.MAX_JUMPS)
            {
                return new PlayerIdle(player);
            }
            else if(Input.GetButton("Jump"))
                return new PlayerGlide(player, PlayerGlide.glideType.Jump);
        }

        if(Input.GetKey(KeyCode.DownArrow) ||
           Input.GetKey(KeyCode.S))
        {
            // Check for fastfall input during fastfall window
            if(playerBody.velocity.y < 0f &&
               playerBody.velocity.y > -2f)
            {
                return new PlayerWalk(player, true);
            }
            // Check if cancelling into glide
            else
            {
                return new PlayerGlide(player, PlayerGlide.glideType.Down);
            }
        }   

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //  This Chunk of code is also in PlayerWalk                       //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////
        horizontalMovement = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        return null;
    }
}
