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
    public float knockback;
    public float knockbackAngle;
}

[RequireComponent(typeof(Collider))]
public abstract class Attack : MonoBehaviour
{
    // private fields

    // protected fields
    [SerializeField]
    protected HitboxData[] hitboxes;
    protected float startupDuration;
    protected float activeDuration;
    protected float recoveryDuration;

    // public fields
    [HideInInspector]
    public bool isFacingRight;
    public Vector3 initialLocalPosition { get; private set; }
    public float initialKnockbackAngle { get; private set; }
    public AttackPhase phase { get; private set; }

    // Constructors for attack with only 1 hitbox
    public Attack(float dmg, int start, int active, int lag, float kb, float angle)
    {
        hitboxes = new HitboxData[1];
        hitboxes[0].shape = GetComponent<Collider>();
        hitboxes[0].damage = dmg;
        hitboxes[0].startup = start;
        hitboxes[0].timeActive = active;
        hitboxes[0].recovery = lag;
        hitboxes[0].knockback = kb;
        hitboxes[0].knockbackAngle = angle;
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
        Vector3 tempLocalPos = transform.localPosition;
        tempLocalPos.x = Mathf.Abs(tempLocalPos.x);
        initialLocalPosition = tempLocalPos;
        phase = AttackPhase.Startup;
    }

    protected void OnEnable()
    {
        // transform.eulerAngles = new Vector3(0f, 0f, hitboxes[0].knockbackAngle);
        startupDuration = hitboxes[0].startup * Time.fixedDeltaTime;
        if(hitboxes[0].timeActive == 0)
            activeDuration = Mathf.Infinity;
        else
            activeDuration = hitboxes[0].timeActive * Time.fixedDeltaTime;
        recoveryDuration = hitboxes[0].recovery * Time.fixedDeltaTime;
        
        Vector3 tempLocalPos = transform.localPosition;
        tempLocalPos.x = Mathf.Abs(tempLocalPos.x);
        initialLocalPosition = tempLocalPos;
        phase = AttackPhase.Startup;
        initialKnockbackAngle = hitboxes[0].knockbackAngle;
    }

    protected void OnDisable()
    {
        Vector3 localPos = transform.localPosition;
        localPos = initialLocalPosition;
        transform.localPosition = localPos;
        hitboxes[0].knockbackAngle = initialKnockbackAngle;
    }

    protected void FixedUpdate()
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
                // Debug.Log(phase);
            }
        }

        if(startupDuration <= 0f)
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
                    // Apply the hitbox's knockback angle if character does not have super armor
                    float adjustedKBAngle = (isFacingRight) ? hitboxes[0].knockbackAngle : 180 - hitboxes[0].knockbackAngle;
                    Vector3 knockback = KnockbackForce(hitboxes[0].knockback, adjustedKBAngle);
                    col.attachedRigidbody.velocity = Vector3.zero;
                    col.attachedRigidbody.AddForce(knockback, ForceMode.VelocityChange);
                    
                    // Go to damaged state
                    col.gameObject.GetComponent<Character>().GoToDamagedState(hitboxes[0].damage, hitboxes[0].knockback);
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
