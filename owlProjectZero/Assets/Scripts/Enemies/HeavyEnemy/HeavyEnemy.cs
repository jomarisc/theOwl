using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{
    // private fields

    // protected fields

    // public fields


    // Initializing maxJumps, maxDodges, dodgeDuration, and deadDuration
    public HeavyEnemy() // : base(1, 0, 3f)
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new HEnemyIdle(this);
            myState = defaultState;
        }
    }
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    public override void MoveCharacter(float direction)
    {
        rb.AddForce(new Vector3(direction * data.maxSpeed, 0f, 0f), ForceMode.VelocityChange);
    }
}
