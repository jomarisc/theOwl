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
    [field: Header("Level Designer Variables")]
    [field: SerializeField] public float FAST_FALL_SPEED { get; private set; } = -10f;
    [field:SerializeField] public float GLIDE_GRAVITY { get; private set; } = -2.0f;
    [Header("Sound Effects")]
    public AudioSource landingSfx;
    public AudioSource projectileShoot;
    public AudioSource projectileHit;
    public AudioSource meleeHit;
    
    [Header("Player-Specific Abilites")]
    public Guntime guntimeAbility;
    public Tether tetherAbility;
    public PlayerSkills unlockedSkills;
    public EquippedSkills equippedSkills;
    // public const float FAST_FALL_SPEED = -10f;

    private float MAX_STAMANA;

    [Header("Other")]
    public GameObject projectile;
    public PlayerInputs input;
    public HealthbarController healthbar;

    // New line
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private SkillTreeWindow skillTreeWindow;
    public LevelSystem levelSystem;
    public int numCurrency;
    public bool inGuntime { get; private set; } = false;
    private bool UpdateInGuntime()
    {
        inGuntime = guntimeAbility.inGuntime;
        return inGuntime;
    }


    public playerControl() // : base(3, 1, 3f)
    {}

    private void Awake()
    {
        input = new PlayerInputs();
        numCurrency = 0;
    }

    private void OnEnable()
    {
        Debug.Log("Player OnEnable()");

        // Subscribe to any events
        input.Enable();
        if(guntimeAbility.enabled)
            guntimeAbility.OnInGuntimeChanged += UpdateInGuntime;
        else
            input.Gameplay.Guntime.Disable();

        // The tether object (not the script) must be enabled at the start of a scene
        // in order to use the tether ability. This is so that we can simply enable
        // the gameobject to show that the suit and its capabilities have been unlocked
        if(!tetherAbility.gameObject.activeInHierarchy)
            input.Gameplay.Tether.Disable();
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        input.Disable();
        guntimeAbility.OnInGuntimeChanged -= UpdateInGuntime;
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
        // DODGE_DURATION = dodgeAbility.dodgeDuration;
        dodgeAbility.dodgeDuration = -1f;
        MAX_STAMANA = data.remainingStamana;
        Debug.Log("MAX_STAMANA " + MAX_STAMANA);
    }

    // Update is called once per frame
    new private void Update() // The new keyword was just tacked on to get rid
                              // of a warning for calling base.Update()
    {
        base.Update();

        // Naturally recover stamana
        if(!equippedSkills.currentSkill.isActive)
        {
            if(data.remainingStamana < MAX_STAMANA)
                data.remainingStamana += Time.deltaTime;
            else if(data.remainingStamana > MAX_STAMANA)
                data.remainingStamana = MAX_STAMANA;
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
