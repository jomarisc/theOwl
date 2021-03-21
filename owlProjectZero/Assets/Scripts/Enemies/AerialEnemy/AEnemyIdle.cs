using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEnemyIdle : IState
{
    private readonly AerialEnemy character;
    private const float IDLE_TIME = 3f;
    private float waitTime;
    private bool playerFound;

    public AEnemyIdle(AerialEnemy myself)
    {
        character = myself;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        return null;
    }
}
