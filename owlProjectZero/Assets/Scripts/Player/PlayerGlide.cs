using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlide : IState
{
    private readonly playerControl player;
    private float horizontalMovement = 0f;

    public PlayerGlide(playerControl p)
    {
        player = p;
    }
    public void Enter()
    {
        // use glide animation here:
    }

    public void Exit()
    {
        // Nothing so far
    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // Check input for changing skills




        // Check input for dodging
        if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        if(Input.GetButtonDown("Jump"))
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        if(Input.GetButtonDown("Fire1"))
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player);
        }

        // Check input for shooting with a projectile
        if(Input.GetButtonDown("Fire2"))
        {
            return new PlayerShoot(player);
        }

        // If jumps get refreshed, i.e. landing on a platform
        if(player.maxSpeed == player.groundSpeed &&
           player.numJumps == playerControl.MAX_JUMPS)
        {
            return new PlayerIdle(player);
        }

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //  This Chunk of code is also in PlayerWalk                       //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////
        horizontalMovement = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        return null;
    }
}
