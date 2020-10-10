﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{
    // private fields
    private SpriteRenderer sRenderer;

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
        sRenderer = GetComponent<SpriteRenderer>();
    }

    new private void Update()
    {
        base.Update();
        sRenderer.flipX = data.isFacingRight; // WHY IS THIS IN MOVE_CHARACTER
    }

    public override void MoveCharacter(float direction)
    {
        rb.AddForce(new Vector3(direction * data.maxSpeed, 0f, 0f), ForceMode.VelocityChange);
    }
}
