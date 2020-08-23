using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{
    // private fields

    // protected fields

    // public fields


    // Initializing maxJumps, maxDodges, dodgeDuration, and deadDuration
    public HeavyEnemy() : base(1, 0, 5f, 3f)
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            myState = new HEnemyIdle(this);
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

    new public void MoveCharacter(float direction)
    {
        Debug.Log(data.maxSpeed);
        rb.AddForce(new Vector3(direction * data.maxSpeed, 0f, 0f), ForceMode.VelocityChange);
    }
}
