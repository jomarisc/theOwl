using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    SphereCollider sphereCollider;

    private float acceleration;
    private float xSpeed;
    private IState myState;
    public GameObject projectile;
    public const int MAX_JUMPS = 3;
    public const int MAX_DODGES = 1;
    public const float DODGE_DURATION = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        if(myState == null)
        {
            myState = new PlayerIdle(this);
            Debug.Log(myState);
        }
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        dodgeDuration = -1f;
    }

    // Update is called once per frame
    new private void Update() // The new keyword was just tacked on to get rid
                              // of a warning for calling base.Update()
    {
        base.Update();
        IState currentState = myState.Update();
        if(currentState != null)
        {
            myState.Exit();
            myState = currentState;
            Debug.Log(myState);
            myState.Enter();
        }
    }

    private void FixedUpdate()
    {
        myState.FixedUpdate();
    }

    public void SpawnProjectile()
    {
        projectile.gameObject.SetActive(true);
        ProjectileAttack projAtk = projectile.GetComponent<ProjectileAttack>();
        Rigidbody projBody = projectile.GetComponent<Rigidbody>();
        Vector3 spawnOffset = (isFacingRight) ? new Vector3(0.5f, 0f, 0f) : new Vector3(-0.5f, 0f, 0f);
        projBody.position = transform.position + spawnOffset;
        projAtk.speed = (isFacingRight) ? ProjectileAttack.INITIAL_SPEED : -ProjectileAttack.INITIAL_SPEED;
    }
}
