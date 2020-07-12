using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : IState
{
    private readonly playerControl player;
    private GameObject projectile;

    public PlayerShoot(playerControl p)
    {
        player = p;
        projectile = p.projectile.gameObject;
    }
    public void Enter()
    {
        // use projectile shooting animation here

        player.SpawnProjectile();
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        // This basically means that the player can only act out
        // of shooting a projectile after it hit something or went
        // off screen.
        // This has potential to encourage skillful play or be weird/clunky
        if(projectile.activeInHierarchy)
        {
            return null;
        }

        if(player.maxSpeed == player.airSpeed &&
           player.numJumps < playerControl.MAX_JUMPS)
        {
            return new PlayerJump(player);
        }
        else
        {
            return new PlayerIdle(player);
        }
    }
}
