using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : IState
{
    private readonly playerControl player;
    private GameObject meleeAttack;

    public PlayerMelee(playerControl p)
    {
        player = p;
        meleeAttack = p.meleeAttack.gameObject;
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
        
    }

    public IState Update()
    {
        // When the hitbox deactivates
        if(!meleeAttack.activeInHierarchy)
        {
            if(player.maxSpeed == player.airSpeed)
            {
                return new PlayerGlide(player);
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
