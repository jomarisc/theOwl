﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Idle State
public class PlayerIdle : IState
{
    private readonly playerControl player;
    private PlayerInputs input;
    private float waitTime = 30f; // Time until the "no input" animation kicks in

    private Animator animator;

    public PlayerIdle(playerControl p)
    {
        player = p;
        animator = p.gameObject.GetComponent<Animator>();
        input = p.input;
    }
    public void Enter()
    {
        // Enter idle animation code here:
        animator.Play("PlayerIdle");
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        // Constantly stay in place
        player.MoveCharacter(0f);
    }

    public IState Update()
    {
        // Check if somehow airborne while in idle state
        if(player.data.maxSpeed == player.data.airSpeed)
            return new PlayerMove(player, true);
        
        // Check input for horizontal movement
        if(input.Gameplay.MoveX.ReadValue<float>() != 0f)
            return new PlayerMove(player, false);

        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
            return new PlayerDodge(player);

        // Check input for jumping
        if(input.Gameplay.Jump.triggered)
            return new PlayerJump(player);

        // Check input for melee attacking
        if(input.Gameplay.Melee.triggered)
            return new PlayerMelee(player, 0f);

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
            return new PlayerShoot(player);

        // Check idle for a while
        if(waitTime >= 0)
            waitTime -= Time.deltaTime;
        else
        {
            // Begin "no input" animation
        }
        return null;
    }
}
