using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : Character
{
    private Vector3 lookingDirection;
    [SerializeField]
    private float eyePrescription = 0f;
    [SerializeField]
    private GameObject experienceCollectable = null;
    public LayerMask targetLayer;
    public static int totalEnemies = 0;
    public static int numDefeatedEnemies = 0;
    public Text enemyCounter;
    EnemyDead enemyDeadListener;


    public Enemy(int maxJumps, int maxDodges, float dodgeDuration, float deadDuration) : base(maxJumps, maxDodges, dodgeDuration, deadDuration)
    {
        lookingDirection = Vector3.zero;
    }

    protected void Start()
    {
        totalEnemies++;
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
        // IncrementDefeatedEnemies();
    }

    new protected void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool SeesPlayer()
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        Debug.DrawRay(rb.position, rb.position + lookingDirection * eyePrescription, Color.white);
        return Physics.Raycast(rb.position, lookingDirection, eyePrescription, targetLayer);
    }

    public bool PlayerInAttackRange(float range)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        Debug.DrawLine(rb.position, rb.position + lookingDirection * Mathf.Abs(range), Color.red);
        bool inAtkRange = Physics.Raycast(rb.position, lookingDirection, Mathf.Abs(range), targetLayer);
        Debug.Log(inAtkRange);
        return inAtkRange;
    }

    public void IncrementDefeatedEnemies()
    {
        if(data.health <= 0)
        {
            numDefeatedEnemies++;
            enemyCounter.text = "Defeated Enemies: " + numDefeatedEnemies + "/" + totalEnemies;
        }
    }

    public void EnemyGoToDeadState()
    {
        myState.Exit();
        myState = new EnemyDead(this);

        enemyDeadListener = (EnemyDead) myState;
        enemyDeadListener.OnEnemyDead += SpawnExperience; // Subscribes to publisher
        Debug.Log(myState);
        myState.Enter();
    }

    private void SpawnExperience(bool sender)
    {
        //Debug.Log("Spawn Experience!");
        Instantiate(experienceCollectable, transform.position, Quaternion.identity);
        enemyDeadListener.OnEnemyDead -= SpawnExperience;
        //Debug.Break();
    }
}
