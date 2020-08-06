using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyWalk : IState
{
    private readonly GroundedEnemy character;
    private const float WALK_TIME = 3f;
    private float waitTime;
    private float horizontalMovement;
    
    public GEnemyWalk(GroundedEnemy myself)
    {
        character = myself;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        waitTime = WALK_TIME;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        character.MoveCharacter(horizontalMovement);
    }
    
    public IState Update()
    {
        if(waitTime >= 0f)
        {
            waitTime -= Time.deltaTime;
            return null;
        }
        return new GEnemyIdle(character);
    }
}
