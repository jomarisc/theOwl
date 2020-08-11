using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : Enemy
{
    // private fields

    // protected fields

    // public fields


    // Initializing maxJumps, maxDodges, dodgeDuration
    public GroundedEnemy() : base(0, 1, 5f, 3f)
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            myState = new GEnemyIdle(this);
        }
    }
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
    }

    new private void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void OnBecameVisible()
    {
        Debug.Log("Visible");
        gameObject.SetActive(true);
    }

    void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        gameObject.SetActive(false);
    }
}
