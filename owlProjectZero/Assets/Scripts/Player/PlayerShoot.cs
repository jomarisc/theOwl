using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : IState
{
    private readonly playerControl player;
    private GameObject projectile;
    private PlayerInputs input;

    public PlayerShoot(playerControl p)
    {
        player = p;
        projectile = p.projectile.gameObject;
        input = p.input;
    }
    public void Enter()
    {
        // use projectile shooting animation here

        player.SpawnProjectile();
        player.projectileShoot.Play();
    }

    public void Exit()
    {
        player.projectileHit.Play();
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

        // Check for glide input
        if(input.Gameplay.Glide.triggered)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        if(player.data.maxSpeed == player.data.airSpeed)
        {
            return new PlayerWalk(player, true); // Change this to specify the airborne version later
        }
        else
        {
            return new PlayerIdle(player);
        }
    }
}
