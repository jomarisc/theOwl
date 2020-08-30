using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : IState
{
    private readonly playerControl player;
    private GameObject projectile;
    private ProjectileAttack projAtk;
    private PlayerInputs input;
    private bool playerCanMove;
    private float horizontalMovement = 0f;

    public PlayerShoot(playerControl p)
    {
        player = p;
        projectile = p.projectile.gameObject;
        projAtk = projectile.GetComponent<ProjectileAttack>();
        input = p.input;
    }
    public void Enter()
    {
        // use projectile shooting animation here

        playerCanMove = false;
        int shootingDirection = (player.data.isFacingRight) ? 1 : -1;
        player.SpawnProjectile(shootingDirection);
        player.projectileShoot.Play();
    }

    public void Exit()
    {
        player.projectileHit.Play();
    }

    public void FixedUpdate()
    {
        if(playerCanMove)
            player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // This basically means that the player can only act out
        // of shooting a projectile after it hit something or went
        // off screen.
        // This has potential to encourage skillful play or be weird/clunky
        if(projectile.activeInHierarchy)
        {
            if(projAtk.phase != AttackPhase.Startup)
                playerCanMove = true;
            if(playerCanMove)
                horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
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
