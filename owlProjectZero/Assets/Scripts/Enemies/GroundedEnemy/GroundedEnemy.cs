using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : Enemy
{
    // private fields
    private SpriteRenderer sRenderer;

    // protected fields

    // public fields
    public AudioSource sfxMelee;
    public AudioSource windUp;

    // Initializing maxJumps, maxDodges, dodgeDuration
    public GroundedEnemy() // : base(0, 1, 3f)
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new GEnemyIdle(this);
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
        sRenderer.flipX = data.isFacingRight;
    }
}
