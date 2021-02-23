using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private GameObject projectile;
    private ProjectileAttack projAtk;
    private PlayerInputs input;
    private bool playerCanMove;
    private float horizontalMovement = 0f;

    public PlayerShoot(playerControl p)
    {
        player = p;
        playerBody = p.GetComponent<Rigidbody>();
        projectile = p.projectile.gameObject;
        projAtk = projectile.GetComponent<ProjectileAttack>();
        input = p.input;
    }
    public void Enter()
    {
        // use projectile shooting animation here
        player.animator.Play("PlayerShoot");

        playerCanMove = false;
        player.projectile.SetActive(true);
        player.projectileShoot.Play();
        player.input.Gameplay.UseActiveSkill.Disable();
    }

    public void Exit()
    {
        player.projectileHit.Play();
        player.input.Gameplay.UseActiveSkill.Enable();
    }

    public void FixedUpdate()
    {
        if(playerCanMove)
            player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        if(!projectile.activeInHierarchy)
        {
            // Check for glide input
            if(input.Gameplay.Glide.triggered)
                return new PlayerGlide(player, PlayerGlide.glideType.Down);

            if(player.data.maxSpeed == player.data.airSpeed)
                return new PlayerMove(player, true);
            else
                return new PlayerIdle(player);
        }

        if(projAtk.phase != AttackPhase.Startup)
            playerCanMove = true;
        if(playerCanMove)
            horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        return null;
    }
}
