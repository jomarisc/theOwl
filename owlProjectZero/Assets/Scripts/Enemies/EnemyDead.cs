using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDead : IState
{

    private readonly Enemy enemy;

    public event EventDelegate OnEnemyDead;

    public delegate void EventDelegate(bool isDead);

    public EnemyDead(Enemy e)
    {
        enemy = e;
    }

    public void Enter()
    {
        //Instantiate(enemy.experienceCollectable, enemy.transform.position, Quaternion.identity);
    }

    public void Exit()
    {
        enemy.IncrementDefeatedEnemies();
        enemy.GetRekt();
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {

        if (OnEnemyDead != null) OnEnemyDead(true);

        if (enemy.data.deadDuration >= 0f)
        {
            enemy.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
            return null;
        }

        // Set to arbitrary state to exit to Character Update()
        // return new GEnemyIdle((GroundedEnemy) enemy);
        return new EnemyDead(enemy);
    }
}
