using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    private const float MAX_GUNTIME_DURATION = 5f;
    private float guntimeDuration;
    [SerializeField]
    private float guntimeUsageRate = 0f;
    [SerializeField]
    private float guntimeRecoveryRate = 0f;
    [SerializeField]
    private Image guntimeMeter = null;
    public GameObject projectile;
    public GameObject tether;
    public TetherPoint activeTetherPoint = null;
    public PlayerInputs input;
    public const float FAST_FALL_SPEED = -10f;
    public HealthbarController healthbar;

    public AudioSource landingSfx;
    public AudioSource projectileShoot;
    public AudioSource projectileHit;
    public AudioSource meleeHit;

    // New line
    [SerializeField]
    private LevelWindow levelWindow = null;
    public LevelSystem levelSystem;
    
    public bool inGuntime = false;

    public playerControl() : base(3, 1, 1f, 3f)
    {}

    private void Awake()
    {
        input = new PlayerInputs();
        guntimeDuration = MAX_GUNTIME_DURATION;
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
        defaultState = new PlayerIdle(this);
        animator = GetComponent<Animator>();
        // New line
        levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
        
        if (myState == null)
        {
            myState = defaultState;
            myState.Enter();
            Debug.Log(myState);
        }
        rb = GetComponent<Rigidbody>();
        data.dodgeDuration = -1f;
    }

    // Update is called once per frame
    new private void Update() // The new keyword was just tacked on to get rid
                              // of a warning for calling base.Update()
    {
        base.Update();
        if(inGuntime)
        {
            // Use up guntime resource
            if(guntimeDuration > 0f)
            {
                guntimeDuration -= guntimeUsageRate * Time.deltaTime;
                guntimeMeter.fillAmount = guntimeDuration / MAX_GUNTIME_DURATION;
            }
            // If ran out of guntime resource, remove character from guntime
            else
                TurnOffGuntime();
        }
        else
        {
            // Recover any missing guntimeDuration
            if(guntimeDuration < MAX_GUNTIME_DURATION)
            {
                guntimeDuration += guntimeRecoveryRate * Time.deltaTime; // deltaTime is so that the recovery rate is hopefully framerate independent
                guntimeMeter.fillAmount = guntimeDuration / MAX_GUNTIME_DURATION;
            }
            // Cap guntimeDuration @ max value
            if(guntimeDuration > MAX_GUNTIME_DURATION)
                guntimeDuration = MAX_GUNTIME_DURATION;
        }
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

    public void SpawnProjectile(int direction) // Direction should be -1 or 1
    {
        projectile.SetActive(true);
        ProjectileAttack projAtk = projectile.GetComponent<ProjectileAttack>();
        Vector3 projPos = projectile.transform.position;
        projPos.x = transform.position.x + direction * projAtk.initialLocalPosition;
        projPos.y = transform.position.y;
        projectile.transform.position = projPos;

        projAtk.speed = rb.velocity.x + direction * projAtk.mySpeed;
        projAtk.isFacingRight = data.isFacingRight;
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
        // Debug.Log("Fastfall input");
        if(Mathf.Abs(rb.velocity.y) <= 3f)
        {
            animator.SetBool("fastfalling", true);
            Debug.Log("fastfalling? " + animator.GetBool("fastfalling"));
            if(inGuntime)
                PlayerWalk.verticalMovement = FAST_FALL_SPEED * 2;
            else
                PlayerWalk.verticalMovement = FAST_FALL_SPEED;
        }
    }

    public void TurnOffGuntime()
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

        inGuntime = false;
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
            TurnOffGuntime();
        }
    }
    /*
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
    */
    /*
    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        Debug.Log("Execute extra code here when player changes level");
    }
    */
}
