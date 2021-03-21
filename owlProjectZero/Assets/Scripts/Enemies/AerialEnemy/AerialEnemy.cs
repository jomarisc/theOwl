using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemy : Enemy
{
    // private fields
    private SpriteRenderer sRenderer;

    // protected fields

    // public fields

    // Initializing maxJumps, maxDodges, dodgeDuration
    public AerialEnemy()
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new AEnemyIdle(this);
            myState = defaultState;
        }
    }
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        sRenderer.flipX = data.isFacingRight;
    }
}
