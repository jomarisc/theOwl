﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : IState
{
    private readonly playerControl player;
    private GameObject meleeAttack;
    private PlayerInputs input;
    private float horizontalMovement;

    private Animator animator;

    public PlayerMelee(playerControl p, float hm)
    {
        player = p;
        meleeAttack = p.basicAttack.gameObject;
        input = p.input;
        horizontalMovement = hm;
        animator = p.gameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        // use melee attack animation here
        animator.Play("PlayerMelee");
        player.meleeHit.Play();

        meleeAttack.SetActive(true);
        player.Attack();
        player.input.Gameplay.UseActiveSkill.Disable();
    }

    public void Exit()
    {
        // For assurance that the hitbox gets deactivated
        if(meleeAttack.activeInHierarchy)
            meleeAttack.SetActive(false);
        player.input.Gameplay.UseActiveSkill.Enable();
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
            if(input.Gameplay.Glide.triggered)
                return new PlayerGlide(player, PlayerGlide.glideType.Down);
            
            if(player.data.maxSpeed == player.data.airSpeed)
                return new PlayerMove(player, true);
            else
                return new PlayerIdle(player);
        }
        
        // No cancels yet
        return null;
    }
}
