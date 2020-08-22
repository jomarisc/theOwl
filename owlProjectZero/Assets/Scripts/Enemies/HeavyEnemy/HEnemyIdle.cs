using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyIdle : IState
{
    private readonly HeavyEnemy character;
    private const float IDLE_TIME = 3f;
    private float waitTime;
    private bool playerFound;
    
    public HEnemyIdle(HeavyEnemy myself)
    {
        character = myself;
    }

    public void Enter()
    {
        // Enter Grounded enemy idle animation here:

        waitTime = IDLE_TIME;
        playerFound = false;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
    }
    
    public IState Update()
    {
        // if(playerFound)
        // {
        //     return new GEnemyChase(character);
        // }

        // if(waitTime >= 0f)
        // {
        //     waitTime -= Time.deltaTime;
        //     return null;
        // }
        // else
        // {
        //     // Turn around and walk
        //     character.data.isFacingRight = !character.data.isFacingRight;
        //     return new GEnemyWalk(character);
        // }

        return null;
    }
}
