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
    public GameObject tether;
    public TetherPoint activeTetherPoint = null;
    public const int MAX_JUMPS = 3;
    public const int MAX_DODGES = 1;
    public const float DODGE_DURATION = 1.0f;
    public const float DEAD_DURATION = 3.0f;

    public Animator animator;
    

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
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
            //Debug.Log("Entered here!");
            myState.Exit();
            myState = currentState;
            Debug.Log(myState);
            myState.Enter();
        }

        //This is probably suboptimal and juryrigs the animation. But it works. -Joel
        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
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

    public void TetherSwing(float tetherLength, Vector3 tetherDirection, float theta)
    {
        float playerWeight = rb.mass * Physics.gravity.magnitude;
        Vector3 tension = Mathf.Cos(theta) * playerWeight * tetherLength * tetherDirection.normalized;
        rb.AddForce(tension, ForceMode.Acceleration); // Tension
        Debug.DrawLine(rb.position, rb.position + tension, Color.red);

        // Vector3 forceAgainstTension = playerWeight * -tetherDirection.normalized;
        // rb.AddForce(forceAgainstTension, ForceMode.Acceleration);
        // Debug.DrawLine(rb.position, rb.position + forceAgainstTension, Color.green);

        Vector3 tempTether = tetherDirection;
        Vector3 pendulumForce = Vector3.down;
        Vector3.OrthoNormalize(ref tempTether, ref pendulumForce);
        pendulumForce *= (Mathf.Cos(theta) * playerWeight);
        rb.AddForce(pendulumForce, ForceMode.Acceleration); // Tangential Force
        Debug.DrawLine(rb.position, rb.position + pendulumForce, Color.blue);

        Debug.DrawLine(rb.position, rb.position + rb.velocity);
    }

    // New
    public void GoToDeadState()
    {

        myState.Exit();
        myState = new PlayerDead(this);
        Debug.Log(myState);
        myState.Enter();

    }
}
