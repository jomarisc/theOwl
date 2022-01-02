using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDead : IState
{

    private readonly Enemy enemy;

    public event EventDelegate OnEnemyDead;

    public delegate void EventDelegate(bool isDead);
    public static event EnemyDied OnEnemyDeath;
    public delegate void EnemyDied();
    public static event EnemiesCleared OnEnemiesCleared;
    public delegate void EnemiesCleared();

    public EnemyDead(Enemy e)
    {
        enemy = e;
    }

    public void Enter()
    {
        //Instantiate(enemy.experienceCollectable, enemy.transform.position, Quaternion.identity);
        enemy.data.deadDuration = enemy.CONSTANTS.DEAD_DURATION;
    }

    public void Exit()
    {
        enemy.IncrementDefeatedEnemies();
        enemy.RemoveFromListOfEnemies();
        if (OnEnemyDead != null) OnEnemyDead(true);
        OnEnemyDeath?.Invoke();
        if(Enemy.numDefeatedEnemies >= Enemy.totalEnemies || enemy.TryGetComponent<MiniBoss>(out MiniBoss mb))
            OnEnemiesCleared?.Invoke();
        enemy.GetRekt();
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {

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
