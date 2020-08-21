using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    SphereCollider sphereCollider;
    private const float MAX_GUNTIME_DURATION = 5f;
    private int guntimeDuration;
    public GameObject projectile;
    public GameObject tether;
    public TetherPoint activeTetherPoint = null;
    public Animator animator;
    public PlayerInputs input { get; private set; }
    public const float FAST_FALL_SPEED = -10f;
    public bool inGuntime = false;

    public playerControl() : base(3, 1, 1f, 3f)
    {}

    private void Awake()
    {
        input = new PlayerInputs();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Gameplay.Guntime.started += ToggleGuntime;
    }

    private void OnDisable()
    {
        input.Gameplay.Guntime.started -= ToggleGuntime;
        input.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        if(myState == null)
        {
            myState = new PlayerIdle(this);
            myState.Enter();
            Debug.Log(myState);
        }
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        data.dodgeDuration = -1f;
    }

    // Update is called once per frame
    new private void Update() // The new keyword was just tacked on to get rid
                              // of a warning for calling base.Update()
    {
        base.Update();
    }

    new private void FixedUpdate()
    {
        base.FixedUpdate();
        if(inGuntime && 
           !(myState is PlayerGlide) &&
           !(myState is PlayerDodge))
        {
            rb.AddForce(4.5f * Physics.gravity);
        }
    }

    public void SpawnProjectile()
    {
        projectile.gameObject.SetActive(true);
        ProjectileAttack projAtk = projectile.GetComponent<ProjectileAttack>();
        Rigidbody projBody = projectile.GetComponent<Rigidbody>();
        Vector3 spawnOffset = (data.isFacingRight) ? new Vector3(0.5f, 0f, 0f) : new Vector3(-0.5f, 0f, 0f);
        projBody.position = transform.position + spawnOffset;
        projAtk.speed = (data.isFacingRight) ? ProjectileAttack.INITIAL_SPEED : -ProjectileAttack.INITIAL_SPEED;
    }

    public void TetherSwing(float tetherLength, Vector3 tetherDirection, float theta)
    {
        float playerWeight = rb.mass * Physics.gravity.magnitude;
        if(inGuntime)
            playerWeight *= 6f;
        Vector3 tension = Mathf.Cos(theta) * playerWeight * tetherLength * tetherDirection.normalized;
        rb.AddForce(tension, ForceMode.Acceleration); // Tension
        Debug.DrawLine(rb.position, rb.position + tension, Color.red);

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

    public void ActivateTether(InputAction.CallbackContext context)
    {
        if(activeTetherPoint != null)
        {
            if(rb.position.y < activeTetherPoint.transform.position.y)
            {
                myState.Exit();
                myState = new PlayerTether(this);
                myState.Enter();
            }
        }
        Debug.Log(myState);
    }

    public void Untether(InputAction.CallbackContext context)
    {
        if(activeTetherPoint != null)
        {
            myState.Exit();
            myState = new PlayerWalk(this, true);
            myState.Enter();
        }
    }

    public void FastFall(InputAction.CallbackContext context)
    {
        Debug.Log("Fastfall input");
        if(Mathf.Abs(rb.velocity.y) <= 3f)
        {
            if(inGuntime)
                PlayerWalk.verticalMovement = FAST_FALL_SPEED * 2;
            else
                PlayerWalk.verticalMovement = FAST_FALL_SPEED;
        }
    }

    public void ToggleGuntime(InputAction.CallbackContext context)
    {
        inGuntime = !inGuntime;

        if(inGuntime)
        {

            // Magic Numbers Ahead...
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.016f * Time.timeScale;

            rb.useGravity = false;

            animator.speed *= 2;

            if(data.maxSpeed == data.groundSpeed)
            {
                data.groundSpeed *= 2f;
                data.maxSpeed = data.groundSpeed;
                data.airSpeed *= 2f;
            }
            else if(data.maxSpeed == data.airSpeed)
            {
                data.airSpeed *= 2f;
                data.maxSpeed = data.airSpeed;
                data.groundSpeed *= 2f;
            }
            data.jumpDistance *= 2f;
        }
        else
        {
            rb.useGravity = true;
            animator.speed /= 2;

            // Magic Numbers Ahead...
            if(data.maxSpeed == data.groundSpeed)
            {
                data.groundSpeed /= 2f;
                data.maxSpeed = data.groundSpeed;
                data.airSpeed /= 2f;
            }
            else if(data.maxSpeed == data.airSpeed)
            {
                data.airSpeed /= 2f;
                data.maxSpeed = data.airSpeed;
                data.groundSpeed /= 2f;
            }
            data.jumpDistance /= 2f;
            
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.016f * Time.timeScale;
        }
    }
}
