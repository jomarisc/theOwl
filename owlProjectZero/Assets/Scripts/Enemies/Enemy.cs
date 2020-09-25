using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : Character
{
    private Collider myCollider;
    private Vector3 lookingDirection;
    private EnemyDead enemyDeadListener;

    [Header("Necessary Attachments")]
    [SerializeField] private GameObject experienceCollectable = null;
    public GameObject currencyCollectable = null;
    public Text enemyCounter;


    [Header("Level Designer Variables")]
    [Tooltip("Range in which enemies can see the player")]
    [SerializeField] private float eyePrescription = 0f;
    public float collectableSpawnRange = 1.0f;
    public LayerMask targetLayer;

    public static int totalEnemies = 0;
    public static int numDefeatedEnemies = 0;


    // public Enemy(int maxJumps, int maxDodges, float deadDuration) : base(maxJumps, maxDodges, deadDuration)
    // {
    //     lookingDirection = Vector3.zero;
    // }
    
    public Enemy()
    {
        lookingDirection = Vector3.zero;
    }

    protected void Start()
    {
        totalEnemies++;
        myCollider = GetComponent<Collider>();
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

    public virtual bool SeesPlayer()
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        // Debug.DrawRay(rb.position, rb.position + lookingDirection * eyePrescription, Color.white);
        Vector3 boxColliderCenter = myCollider.bounds.center + (lookingDirection * myCollider.bounds.extents.x);
        Debug.DrawLine(boxColliderCenter - new Vector3(myCollider.bounds.extents.x, myCollider.bounds.extents.y, 0), boxColliderCenter + new Vector3(myCollider.bounds.extents.x, myCollider.bounds.extents.y, 0), Color.red, 0.1f);
        Debug.DrawLine(boxColliderCenter - new Vector3(myCollider.bounds.extents.x, -myCollider.bounds.extents.y, 0), boxColliderCenter + new Vector3(myCollider.bounds.extents.x, -myCollider.bounds.extents.y, 0), Color.red, 0.1f);
        return Physics.BoxCast(boxColliderCenter, myCollider.bounds.extents, lookingDirection, Quaternion.identity, eyePrescription, targetLayer);
        // return Physics.Raycast(rb.position, lookingDirection, eyePrescription, targetLayer);
    }

    public bool PlayerInAttackRange(float range)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        Debug.DrawLine(rb.position, rb.position + lookingDirection * Mathf.Abs(range), Color.red);
        bool inAtkRange = Physics.Raycast(rb.position, lookingDirection, Mathf.Abs(range), targetLayer);
        // Debug.Log(inAtkRange);
        return inAtkRange;
    }

    public bool PlayerInAttackRange(Collider hitbox)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f: -1f;
        bool inAtkRange = Physics.BoxCast(hitbox.bounds.center, hitbox.bounds.extents, lookingDirection, Quaternion.identity, eyePrescription, targetLayer);
        return inAtkRange;
    }

    public void IncrementDefeatedEnemies()
    {
        if(data.health <= 0)
        {
            numDefeatedEnemies++;
            enemyCounter.text = "Defeated Enemies: " + numDefeatedEnemies + "/" + totalEnemies;
            Debug.Log($"Defeated Enemies: {numDefeatedEnemies}");
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

        
        for (int i = 1 ; i <= 3; i++)
        {
            var randomPos = (Random.insideUnitSphere * collectableSpawnRange);
            randomPos.z = 0;
            Instantiate(currencyCollectable, transform.position + randomPos, Quaternion.identity);
        }
        enemyDeadListener.OnEnemyDead -= SpawnExperience;
        //Debug.Break();
    }

    public void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(this.gameObject);
        enemyClone.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }
}
