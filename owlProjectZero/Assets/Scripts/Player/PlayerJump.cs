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
           Input.GetKeyDown(KeyCode.T))
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
        if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
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
        if(playerBody.velocity[1] < 0)
        {
            // If jumps get refreshed, i.e. landing on a platform
            if(player.maxSpeed == player.groundSpeed &&
            player.numJumps == playerControl.MAX_JUMPS)
            {
                return new PlayerIdle(player);
            }
            return new PlayerGlide(player);
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
