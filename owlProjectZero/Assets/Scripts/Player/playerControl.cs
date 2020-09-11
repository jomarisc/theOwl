using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    private float MAX_STAMANA;
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
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private SkillTreeWindow skillTreeWindow;
    public LevelSystem levelSystem;
    public PlayerSkills unlockedSkills;
    public PlayerSkills equippedSkills;
    public GameObject equippedSkillsUI;
    public static event SkillEquip OnSkillEquip;
    public delegate void SkillEquip();
    private bool usingFastSkillWheel = false;
    public int numCurrency;

    public bool inGuntime = false;


    public playerControl() : base(3, 1, 1f, 3f)
    {}

    private void Awake()
    {
        input = new PlayerInputs();
        guntimeDuration = MAX_GUNTIME_DURATION;
        // playerSkills = new PlayerSkills();
        numCurrency = 0;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Gameplay.Guntime.started += ToggleGuntime;
        input.Gameplay.UseActiveSkill.started += UseCurrentSkill;
        // input.Gameplay.OpenSkillWheel.started += OpenSkillWheel;
        // input.Gameplay.OpenSkillWheel.canceled += CloseSkillWheel;
    }

    private void OnDisable()
    {
        input.Gameplay.Guntime.started -= ToggleGuntime;
        input.Gameplay.UseActiveSkill.started -= UseCurrentSkill;
        // input.Gameplay.OpenSkillWheel.started -= OpenSkillWheel;
        // input.Gameplay.OpenSkillWheel.canceled -= CloseSkillWheel;
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
        MAX_STAMANA = data.remainingStamana;
        Debug.Log("MAX_STAMANA " + MAX_STAMANA);
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

        // Naturally recover stamana
        if(!equippedSkills.currentSkill.isActive)
        {
            if(data.remainingStamana < MAX_STAMANA)
                data.remainingStamana += Time.deltaTime;
            else if(data.remainingStamana > MAX_STAMANA)
                data.remainingStamana = MAX_STAMANA;
        }

        if(!equippedSkillsUI.activeInHierarchy)
        {
            if(input.Gameplay.OpenSkillWheel.ReadValue<Vector2>().magnitude >= 0.125f)
            {
                usingFastSkillWheel = true;
                OpenSkillWheel();
                Debug.Log(input.Gameplay.OpenSkillWheel.phase);
                // input.Gameplay.MoveX.Disable();
                // input.Gameplay.Jump.Disable();
                input.Gameplay.Melee.Disable();
                input.Gameplay.Guntime.Disable();
                // input.Gameplay.Dodge.Disable();
                input.Gameplay.ShootProjectile.Disable();
                // input.Gameplay.Tether.Disable();
                // input.Gameplay.Glide.Disable();
            }
            // else if(input.Gameplay.OpenSkillWheel2.ReadValue<float>() == 1f)
            // {
            //     usingFastSkillWheel = false;
            //     OpenSkillWheel2();
            //     Debug.Log(input.Gameplay.OpenSkillWheel2.phase);
            //     // input.Gameplay.Disable();
            //     input.Gameplay.MoveX.Disable();
            //     input.Gameplay.Jump.Disable();
            //     input.Gameplay.Melee.Disable();
            //     input.Gameplay.Guntime.Disable();
            //     input.Gameplay.Dodge.Disable();
            //     input.Gameplay.ShootProjectile.Disable();
            //     input.Gameplay.Tether.Disable();
            //     input.Gameplay.Glide.Disable();
            // }
        }

        if(equippedSkillsUI.activeInHierarchy)
        {
            if(usingFastSkillWheel)
            {
                if(input.Gameplay.OpenSkillWheel.ReadValue<Vector2>().magnitude < 0.125f)
                {
                    CloseSkillWheel();
                    Debug.Log(input.Gameplay.OpenSkillWheel.phase);
                    // input.Gameplay.MoveX.Enable();
                    // input.Gameplay.Jump.Enable();
                    input.Gameplay.Melee.Enable();
                    input.Gameplay.Guntime.Enable();
                    // input.Gameplay.Dodge.Enable();
                    input.Gameplay.ShootProjectile.Enable();
                    // input.Gameplay.Tether.Enable();
                    // input.Gameplay.Glide.Enable();
                }
            }
            // else
            // {
            //     if(input.Gameplay.OpenSkillWheel2.ReadValue<float>() == 0f)
            //     {
            //         CloseSkillWheel();
            //         Debug.Log(input.Gameplay.OpenSkillWheel2.phase);
            //         // input.Gameplay.Enable();
            //         input.Gameplay.MoveX.Enable();
            //         input.Gameplay.Jump.Enable();
            //         input.Gameplay.Melee.Enable();
            //         input.Gameplay.Guntime.Enable();
            //         input.Gameplay.Dodge.Enable();
            //         input.Gameplay.ShootProjectile.Enable();
            //         input.Gameplay.Tether.Enable();
            //         input.Gameplay.Glide.Enable();
            //     }
            // }
        }
    }

    // Should disable the current selected and active skill
    // Then enable the desired skill
    new private void ChangeSkill()
    {

    }

    new private void FixedUpdate()
    {
        base.FixedUpdate();

        levelWindow.SetLevelSystem(levelSystem);

        if (inGuntime && 
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

    public void UseCurrentSkill(InputAction.CallbackContext context)
    {
        Skill currentSkill = equippedSkills.currentSkill;
        if(currentSkill.isActive)
            currentSkill.DeactivateSkill();
        else
        {
            if(data.remainingStamana >= currentSkill.usageCost)
            {
                data.remainingStamana -= currentSkill.usageCost;
                currentSkill.UseSkill();
            }
            else
                Debug.Log("Not enough stamana!");
        }
    }

    public void OpenSkillWheel()
    {
        Time.timeScale = 0.5f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(input.SkillWheel.Navigate);
        equippedSkillsUI.SetActive(true);
        StartCoroutine(ReadRightStickInput());
    }

    // A slower way of opening the skill wheel
    public void OpenSkillWheel2()
    {
        Time.timeScale = 0f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(input.SkillWheel.Navigate);
        equippedSkillsUI.SetActive(true);
        // StartCoroutine(ReadRightStickInput());
        Button slotOne = equippedSkillsUI.GetComponentInChildren<Button>();
        slotOne.Select();
        slotOne.OnSelect(null);
    }

    IEnumerator ReadRightStickInput()
    {
        yield return new WaitForEndOfFrame();
        Vector2 stickInput = input.Gameplay.OpenSkillWheel.ReadValue<Vector2>();
        while(stickInput.magnitude == 0f)
            yield return null;

        float stickAngle = Vector2.SignedAngle(stickInput, Vector2.up);
        Button[] skillSlots = equippedSkillsUI.GetComponentsInChildren<Button>();
        int index = 0;
        if(stickAngle < -45 && stickAngle > -135)
            index = 3;
        else if(stickAngle > 45 && stickAngle < 135)
            index = 1;
        else if(Mathf.Abs(stickAngle) > 90)
            index = 2;
        else
            index = 0;

        skillSlots[index].Select();
        skillSlots[index].OnSelect(null);
    }

    public void CloseSkillWheel()
    {
        usingFastSkillWheel = false;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(input.UI.Navigate);
        equippedSkills.currentSkill = equippedSkills.unlockedSkillTypeList[EventSystem.current.currentSelectedGameObject.GetComponentInChildren<SkillWheelSlotUI>().slotNumber - 1];
        if(OnSkillEquip != null)
            OnSkillEquip();
        equippedSkillsUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Function(s) for Dead State
    public void GoToDeadState()
    {

        myState.Exit();
        myState = new PlayerDead(this);
        Debug.Log(myState);
        myState.Enter();
    }

    // Function(s) for LevelSystem

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }

    // Functions for currency

    public int GetCurrency()
    {
        return numCurrency;
    }

    public void AddCurrency(int addAmount)
    {
        numCurrency += addAmount;
    }

    public void SubtractCurrency(int subAmount)
    {
        numCurrency -= subAmount;
        if (numCurrency < 0)
        {
            numCurrency = 0;
        }
    }

    // Functions for PlayerSkills

    public PlayerSkills GetPlayerSkills()
    {
        // return playerSkills;
        return unlockedSkills;
    }

    public bool CanUseShield()
    {
        return true; 
        // return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Shield);
    }

}
