using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyWalk : IState
{
    private readonly GroundedEnemy character;
    private const float WALK_TIME = 3f;
    private float horizontalMovement;
    private float waitTime;
    private bool playerFound;
    
    public GEnemyWalk(GroundedEnemy myself)
    {
        character = myself;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        waitTime = WALK_TIME;
        playerFound = false;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
        character.MoveCharacter(horizontalMovement);
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
        return new GEnemyIdle(character);
    }
}
