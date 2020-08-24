using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyWalk : IState
{
    private readonly HeavyEnemy character;
    private const float TIME_BETWEEN_STEPS = 0.25f;
    private const int NUM_STEPS = 10;
    private int stepsTaken;
    private float stepTime;
    private float horizontalMovement;
    private float waitTime;
    private bool playerFound;
    
    public HEnemyWalk(HeavyEnemy myself)
    {
        character = myself;
    }

    public void Enter()
    {
        // Enter heavy enemy walk animation here:
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        stepsTaken = 0;
        stepTime = TIME_BETWEEN_STEPS;
        playerFound = false;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
        if(stepTime <= 0f)
        {
            character.MoveCharacter(horizontalMovement);
            stepTime = TIME_BETWEEN_STEPS;
            stepsTaken++;
        }
    }
    
    public IState Update()
    {
        if(playerFound)
        {
            return new HEnemyChase(character);
        }

        if(stepsTaken < NUM_STEPS)
        {
            stepTime -= Time.deltaTime;
            waitTime -= Time.deltaTime;
            return null;
        }
        return new HEnemyIdle(character);
    }
}
