﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyIdle : IState
{
    private readonly GroundedEnemy character;
    private Animator animator;
    private const float IDLE_TIME = 3f;
    private float waitTime;
    private bool playerFound;
    
    public GEnemyIdle(GroundedEnemy myself)
    {
        character = myself;
        animator = myself.gameObject.GetComponent<Animator>();
    }

    public void Enter()
    {
        // Enter Grounded enemy idle animation here:
        animator.SetBool("idling", true);

        waitTime = IDLE_TIME;
        playerFound = false;
    }

    public void Exit()
    {
        animator.SetBool("idling", false);

    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
    }
    
    public IState Update()
    {
        if(playerFound)
        {
            return new GEnemyChase(character);
        }

        if(waitTime >= 0f)
        {
            waitTime -= Time.deltaTime;
            return null;
        }
        else
        {
            // Turn around and walk
            character.data.isFacingRight = !character.data.isFacingRight;
            return new GEnemyWalk(character);
        }
    }
}
