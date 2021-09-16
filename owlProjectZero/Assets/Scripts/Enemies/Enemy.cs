using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : Character
{
    private Collider myCollider;
    private Vector3 lookingDirection;
    private EnemyDead enemyDeadListener;
    private bool isNearEdge = true; // 0 = left; 1 = right
    private Room myRoom = null;

    [Header("Necessary Attachments")]
    [HideInInspector] public SpriteRenderer sRenderer;
    [SerializeField] private GameObject experienceCollectable = null;
    [SerializeField] private GameObject healthCollectable = null;
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

    void OnEnable()
    {
        enemyCounter = GameObject.Find("GameplayCanvas/EnemyCounter").GetComponent<Text>();
    }

    protected new void Start()
    {
        base.Start();
        totalEnemies++;
        myCollider = GetComponent<Collider>();
        enemyCounter = GameObject.Find("GameplayCanvas/EnemyCounter").GetComponent<Text>();
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

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out Room room))
        {
            myRoom = col.GetComponent<Room>();
            myRoom.enemyColliders.Add(myCollider);
            Debug.Log("Adding me self into va enemy list ye");
            // Debug.Break();
        }
    }

    public virtual bool SeesPlayer()
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        for(int i = -3; i <= 3; i++)
        {
            Vector3 raycastOrigin = transform.position + new Vector3(0f, transform.localScale.y * i / 6);
            Debug.DrawLine(raycastOrigin, raycastOrigin + lookingDirection * eyePrescription, Color.red);
            if(Physics.Raycast(raycastOrigin, lookingDirection, eyePrescription, targetLayer))
                return true;
        }
        return false;
    }

    public bool PlayerInAttackRange(float range)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        for(int i = -3; i <= 3; i++)
        {
            Vector3 raycastOrigin = transform.position + new Vector3(transform.localScale.x / 2 * lookingDirection.x, transform.localScale.y * i / 6);
            Debug.DrawLine(raycastOrigin, raycastOrigin + lookingDirection * Mathf.Abs(range), Color.red);
            if(Physics.Raycast(raycastOrigin, lookingDirection, Mathf.Abs(range), targetLayer))
                return true;
        }
        return false;
    }

    [System.Obsolete("This function dun work nicely atm. Consider using a different one m8.")]
    public bool PlayerInAttackRange(Collider hitbox)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f: -1f;
        Bounds bounds = hitbox.bounds;

        Vector3 topLeft = bounds.center
                          + new Vector3(-bounds.extents.x, bounds.extents.y, 0f);
        Vector3 topRight = bounds.center
                          + new Vector3(bounds.extents.x, bounds.extents.y, 0f);
        Vector3 bottomLeft = bounds.center
                          + new Vector3(-bounds.extents.x, -bounds.extents.y, 0f);
        Vector3 bottomRight = bounds.center
                          + new Vector3(bounds.extents.x, -bounds.extents.y, 0f);

        Debug.DrawLine(topLeft, topRight, Color.red);
        Debug.DrawLine(topRight, bottomRight, Color.red);
        Debug.DrawLine(bottomRight, bottomLeft, Color.red);
        Debug.DrawLine(bottomLeft, topLeft, Color.red);

        Collider[] playersInRange = Physics.OverlapBox(bounds.center,
                                             bounds.extents,
                                             Quaternion.identity,
                                             targetLayer);
                                          
        if(playersInRange.Length > 0)
            // Debug.Break();
            return true;
        return false;
    }

    [System.Obsolete("This function also dun work nicely atm. Consider using a different one m8.")]
    public bool PlayerInAttackRange(Bounds bounds)
    {
        lookingDirection.x = (data.isFacingRight) ? 1f: -1f;

        Vector3 topLeft = bounds.center
                          + new Vector3(-bounds.extents.x, bounds.extents.y, 0f);
        Vector3 topRight = bounds.center
                          + new Vector3(bounds.extents.x, bounds.extents.y, 0f);
        Vector3 bottomLeft = bounds.center
                          + new Vector3(-bounds.extents.x, -bounds.extents.y, 0f);
        Vector3 bottomRight = bounds.center
                          + new Vector3(bounds.extents.x, -bounds.extents.y, 0f);

        Debug.DrawLine(topLeft, topRight, Color.red);
        Debug.DrawLine(topRight, bottomRight, Color.red);
        Debug.DrawLine(bottomRight, bottomLeft, Color.red);
        Debug.DrawLine(bottomLeft, topLeft, Color.red);

        Collider[] playersInRange = Physics.OverlapBox(bounds.center,
                                             bounds.extents,
                                             Quaternion.identity,
                                             targetLayer);
                                          
        if(playersInRange.Length > 0)
            // Debug.Break();
            return true;
        return false;
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

    public virtual void EnemyGoToDeadState()
    {
        myState.Exit();
        myState = new EnemyDead(this);

        enemyDeadListener = (EnemyDead) myState;
        enemyDeadListener.OnEnemyDead += SpawnExperience; // Subscribes to publisher
        enemyDeadListener.OnEnemyDead += SpawnHealth; // Subscribes to publisher
        // Debug.Log(myState);
        myState.Enter();
    }

    private void SpawnHealth(bool sender)
    {
    
        for (int i = Random.Range(1, 4); i <= 2; i++) // Previously starts with 1 and ended with 2
        {
            var randomPos = (Random.insideUnitSphere * collectableSpawnRange);
            randomPos.z = 0;
            Instantiate(healthCollectable, transform.position + randomPos, Quaternion.identity);
        }
        enemyDeadListener.OnEnemyDead -= SpawnHealth;
    }

    private void SpawnExperience(bool sender)
    {
        //Debug.Log("Spawn Experience!");
        Instantiate(currencyCollectable, transform.position, Quaternion.identity);

        
        for (int i = 1 ; i <= 3; i++)
        {
            var randomPos = (Random.insideUnitSphere * collectableSpawnRange);
            randomPos.z = 0;
            Instantiate(experienceCollectable, transform.position + randomPos, Quaternion.identity);
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

    public bool isOnEnvironmentEdge()
    {
        float xOffset = data.isFacingRight ? Vector3.Dot(Vector3.right, myCollider.bounds.extents) : Vector3.Dot(-Vector3.right, myCollider.bounds.extents);
        Vector3 offsetVector = new Vector3(xOffset, 0f, 0f);
        isNearEdge = !Physics.Raycast(myCollider.bounds.center + offsetVector, Vector3.down, myCollider.bounds.extents.magnitude + 0.01f);
        Debug.DrawRay(myCollider.bounds.center + offsetVector, Vector3.down * (myCollider.bounds.extents.magnitude + 0.01f), Color.green);
        return isNearEdge;
    }

    public void RemoveFromListOfEnemies()
    {
        if(myRoom != null)
            myRoom.enemyColliders.Remove(myCollider);
    }
}
