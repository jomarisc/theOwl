using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : IState
{
    private readonly playerControl player;
    private GameObject meleeAttack;
    private float horizontalMovement;

    public PlayerMelee(playerControl p, float hm)
    {
        player = p;
        meleeAttack = p.meleeAttack.gameObject;
        horizontalMovement = hm;
    }
    public void Enter()
    {
        // use melee attack animation here

        player.Attack();
        meleeAttack.SetActive(true);
    }

    public void Exit()
    {
        // For assurance that the hitbox gets deactivated
        if(meleeAttack.activeInHierarchy)
        {
            meleeAttack.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        // When the hitbox deactivates
        if(!meleeAttack.activeInHierarchy)
        {
            // Check input for glide
            if(Input.GetAxis("Vertical") < 0)
            {
                return new PlayerGlide(player, PlayerGlide.glideType.Down);
            }
            
            if(player.maxSpeed == player.airSpeed)
            {
                return new PlayerWalk(player, true); // Specify this to be the airborne version later
            }
            else
            {
                return new PlayerIdle(player);
            }
        }
        // No cancels yet
        return null;
    }
}
