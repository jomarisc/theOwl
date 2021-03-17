using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackPhase {Startup, Active, Recovery}

[System.Serializable] // This allows us to initialze struct values
                      // in the Unity inspector
public struct HitboxData
{
    public Collider shape;
    public float damage;
    public int startup;
    public int timeActive;
    public int recovery;
    public float gKnockback;
    public float gKnockbackAngle;
    public float aKnockback;
    public float aKnockbackAngle;
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public abstract class Attack : MonoBehaviour
{
    // private fields

    // protected fields
    [Header("General")]
    [SerializeField] protected HitboxData[] hitboxes;
    protected float startupDuration;
    protected float activeDuration;
    protected float recoveryDuration;

    // public fields
    [HideInInspector]
    public bool isFacingRight;
    public Vector3 initialLocalPosition { get; private set; }
    public float initialKnockbackAngle { get; private set; }
    public AttackPhase phase { get; private set; }

    [Header("Audio Sources")]
    public AudioSource startupSFX;
    public AudioSource activeSFX;
    public AudioSource recoverySFX;
    public AudioSource onCharacterHitSFX;
    public AudioSource onEnvironmentHitSFX;

    // Constructors for attack with only 1 hitbox
    public Attack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle)
    {
        hitboxes = new HitboxData[1];
        hitboxes[0].shape = GetComponent<Collider>();
        hitboxes[0].damage = dmg;
        hitboxes[0].startup = start;
        hitboxes[0].timeActive = active;
        hitboxes[0].recovery = lag;
        hitboxes[0].gKnockback = gkb;
        hitboxes[0].gKnockbackAngle = gAngle;
        hitboxes[0].aKnockback = akb;
        hitboxes[0].aKnockbackAngle = aAngle;
    }

    public Attack(HitboxData hitbox)
    {
        hitboxes = new HitboxData[1];
        hitboxes[0] = hitbox;
    }

    // Constructor for attack with multiple hitboxes
    public Attack(HitboxData[] hitboxes)
    {
        InitializeHitboxes(hitboxes, hitboxes.Length);
    }

    protected void Start()
    {
        // Vector3 tempLocalPos = transform.localPosition;
        // bool onRightSide = (transform.localPosition.x > 0f) ? true : false;
        // tempLocalPos.x = Mathf.Abs(tempLocalPos.x);
        // initialLocalPosition = tempLocalPos;
        // Debug.Log($"Initial Local Postition: {initialLocalPosition}");
        // Debug.Break();
        phase = AttackPhase.Startup;
    }

    protected virtual void OnEnable()
    {
        // transform.eulerAngles = new Vector3(0f, 0f, hitboxes[0].gKnockbackAngle);
        startupDuration = hitboxes[0].startup * Time.fixedDeltaTime;
        if(hitboxes[0].timeActive == 0)
            activeDuration = Mathf.Infinity;
        else
            activeDuration = hitboxes[0].timeActive * Time.fixedDeltaTime;
        recoveryDuration = hitboxes[0].recovery * Time.fixedDeltaTime;
        
        Vector3 tempLocalPos = transform.localPosition;
        // bool onRightSide = (transform.localPosition.x > 0f) ? true : false;
        // tempLocalPos.x = Mathf.Abs(tempLocalPos.x);
        initialLocalPosition = tempLocalPos;
        phase = AttackPhase.Startup;
        initialKnockbackAngle = hitboxes[0].gKnockbackAngle;

        startupSFX.Play();
    }

    protected void OnDisable()
    {
        Vector3 localPos = transform.localPosition;
        localPos = initialLocalPosition;
        transform.localPosition = localPos;
        hitboxes[0].gKnockbackAngle = initialKnockbackAngle;
    }

    protected virtual void FixedUpdate()
    {
        if(startupDuration > 0f)
        {
            startupDuration -= Time.fixedDeltaTime;
            if(phase != AttackPhase.Startup)
            {
                phase = AttackPhase.Startup;
                // Debug.Log(phase);
            }
        }
        else if(activeDuration > 0f)
        {
            if(activeDuration != Mathf.Infinity)
            {
                activeDuration -= Time.fixedDeltaTime;
                Color hitboxColor = new Color(255f, 0f, 0f, 96f);
                hitboxes[0].shape.gameObject.GetComponent<Renderer>().material.SetColor("_Color", hitboxColor);
                if(phase != AttackPhase.Active)
                {
                    phase = AttackPhase.Active;
                    activeSFX.Play();
                    // Debug.Log(phase);
                }
            }
        }
        else
        {
            recoveryDuration -= Time.fixedDeltaTime;
            hitboxes[0].shape.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if(phase != AttackPhase.Recovery)
            {
                phase = AttackPhase.Recovery;
                recoverySFX.Play();
                // Debug.Log(phase);
            }
        }

        if(startupDuration <= 0f && activeDuration > 0f)
        {
            hitboxes[0].shape.enabled = true;
        }
        if(recoveryDuration <= 0f)
        {
            hitboxes[0].shape.enabled = false;
            gameObject.SetActive(false);
        }
    }

    protected void OnTriggerEnter(Collider col)
    {
        ApplyHitboxInteraction(col);
        PlayOnHitSFX(col);
    }

    // Initializes hitbox data for a given attack
    // Helpful if an attack has multiple hitboxes
    private void InitializeHitboxes(HitboxData[] atkData, int numHitboxes)
    {
        if(numHitboxes != atkData.Length)
        {
            Debug.Log("Failed Hitbox Initialization");
            return;
        }

        hitboxes = new HitboxData[numHitboxes];
        for(int i = 0 ; i < numHitboxes; i++)
        {
            hitboxes[i] = atkData[i];
        }
    }

    protected void ApplyHitboxInteraction(Collider col)
    {
        if(col.gameObject.TryGetComponent(out Rigidbody body) &&
           col.GetComponent<EnvironmentElement>() == null)
        {
            if(col.gameObject.TryGetComponent<Shield>(out Shield s))
            {
                col.gameObject.GetComponent<Shield>().GetDamaged(hitboxes[0].damage);
            }


            // This should eventually get refactored into a damaged state for the
            // character class
            if(col.gameObject.TryGetComponent(out Character character))
            {
                // Trigger hitstop mechanic for player feedback on hit




                if(!col.gameObject.GetComponent<Character>().data.hasSuperArmor)
                {
                    // Apply the hitbox's gKnockback angle if character does not have super armor
                    float adjustedKBAngle = (isFacingRight) ? hitboxes[0].gKnockbackAngle : 180 - hitboxes[0].gKnockbackAngle;
                    Vector3 gKnockback = KnockbackForce(hitboxes[0].gKnockback, adjustedKBAngle);
                    col.attachedRigidbody.velocity = Vector3.zero;
                    col.attachedRigidbody.AddForce(gKnockback, ForceMode.Impulse);
                    
                    // Go to damaged state
                    col.gameObject.GetComponent<Character>().GoToDamagedState(hitboxes[0].damage, hitboxes[0].gKnockback);
                }
                else
                {
                    // Just get damaged
                    col.gameObject.GetComponent<Character>().data.health -= hitboxes[0].damage;
                }
            }
            if(col.gameObject.TryGetComponent(out playerControl player))
            {
                Debug.Log("Player Damaged by Hitbox!");
                // col.gameObject.GetComponent<playerControl>().healthbar.Damage(hitboxes[0].damage);
                col.gameObject.GetComponent<playerControl>().healthbar.Redraw();
            }
            if(col.gameObject.TryGetComponent(out Enemy enemy))
            {
                if (col.gameObject.GetComponent<Enemy>().data.health <= 0)
                {
                    // Have enemy go to dead state.
                    col.gameObject.GetComponent<Enemy>().EnemyGoToDeadState();
                }
            }
        }
    }

    private void PlayOnHitSFX(Collider col)
    {
        if(col.TryGetComponent(out Character c))
            onCharacterHitSFX.Play();
        
        if(col.TryGetComponent(out EnvironmentElement ee))
            onEnvironmentHitSFX.Play();
    }

    // Convert a magnitude and direction into a force in the form of a Vector3
    private Vector3 KnockbackForce(float magnitude, float direction)
    {
        // Calculate the normal vector using the direction


        // Multiply the vector by the magnitude
        float radians = direction * Mathf.PI / 180;
        float xDir = Mathf.Cos(radians);
        float yDir = Mathf.Sin(radians);

        Vector3 force = new Vector3(xDir, yDir, 0f);
        force.Normalize();
        force *= magnitude;
        return force;
    }
}
