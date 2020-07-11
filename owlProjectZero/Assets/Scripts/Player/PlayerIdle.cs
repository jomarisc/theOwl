using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Idle State
public class PlayerIdle : IState
{
    private readonly playerControl player;
    private float waitTime = 30f; // Time until the "no input" animation kicks in 

    public PlayerIdle(playerControl p)
    {
        player = p;
    }
    public void Enter()
    {
        // Enter idle animation code here:
    }

    public void Exit()
    {
        // Nothing so far
    }

    public void FixedUpdate()
    {
        // Constantly stay in place
        player.MoveCharacter(0f);
    }

    public IState Update()
    {
        
        // Check input for horizontal movement
        if(Input.GetAxis("Horizontal") != 0)
        {
            return new PlayerWalk(player);
        }

        // Check input for changing skills




        // Check input for dodging
        if(Input.GetButtonDown("Fire3"))
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        if(Input.GetButtonDown("Jump"))
        {
            player.numJumps--;
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

        // Check idle for a while
        if(waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            // Begin "no input" animation
        }
        return null;
    }
}
