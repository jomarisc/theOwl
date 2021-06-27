// This script is meant to contain the logic for individual hitboxes.
// This concerns the:
//      1) timing of hitbox phases
//      2) logic for hitbox collision interactions
//      3) deactivating hitboxes by the end of its recovery phase

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum AttackPhase {Startup, Active, Recovery}

[System.Serializable] // This allows us to initialze struct values
                      // in the Unity inspector
public struct HitboxData
{
    [HideInInspector]
    public Vector3 initialLocalPosition; // Attack scripts are in charge of initializing this field, whereas this script is in charge of returning this value to its original value
    public Collider shape;
    public float damage;
    public int startup;
    public int timeActive;
    public int recovery;
    public float gKnockback;
    public float gKnockbackAngle;
    public float aKnockback;
    public float aKnockbackAngle;
    public float currentKnockback;
    public float currentKnockbackAngle;
}
public class Hitbox : MonoBehaviour
{
    public HitboxData data;
    protected float startupDuration;
    protected float activeDuration;
    protected float recoveryDuration;
    public AttackPhase phase { get; private set; }
    
    [Header("Audio Sources")]
    public AudioSource startupSFX;
    public AudioSource activeSFX;
    public AudioSource recoverySFX;
    public delegate void EventDelegate();
    public event EventDelegate OnHitboxFinished;
    // Start is called before the first frame update
    void Start()
    {
        phase = AttackPhase.Startup;
    }

    protected virtual void OnEnable()
    {
        // data.initialLocalPosition = transform.localPosition;
        startupDuration = data.startup * Time.fixedDeltaTime;
        if(data.timeActive == 0)
            activeDuration = Mathf.Infinity;
        else
            activeDuration = data.timeActive * Time.fixedDeltaTime;
        recoveryDuration = data.recovery * Time.fixedDeltaTime;

        phase = AttackPhase.Startup;

        startupSFX.Play();
    }

    protected void OnDisable()
    {
        transform.localPosition = data.initialLocalPosition;
        if(OnHitboxFinished != null)
            OnHitboxFinished();
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
                data.shape.gameObject.GetComponent<Renderer>().material.SetColor("_Color", hitboxColor);
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
            data.shape.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if(phase != AttackPhase.Recovery)
            {
                phase = AttackPhase.Recovery;
                recoverySFX.Play();
                // Debug.Log(phase);
            }
        }
        if(phase == AttackPhase.Active && !data.shape.enabled) // (startupDuration <= 0f && activeDuration > 0f)
        {
            data.shape.enabled = true;
        }
        else if(phase == AttackPhase.Recovery && data.shape.enabled)
        {
            data.shape.enabled = false;
        }
        if(recoveryDuration <= 0f)
        {
            this.enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        ApplyHitboxInteraction(col);
    }

    protected void ApplyHitboxInteraction(Collider col)
    {
        if(col.gameObject.TryGetComponent(out Rigidbody body) &&
           col.GetComponent<EnvironmentElement>() == null)
        {
            if(col.gameObject.TryGetComponent<Shield>(out Shield s))
            {
                col.gameObject.GetComponent<Shield>().GetDamaged(data.damage);
            }


            // This should eventually get refactored into a damaged state for the
            // character class
            if(col.gameObject.TryGetComponent(out Character character))
            {
                // Trigger hitstop mechanic for player feedback on hit




                if(!col.gameObject.GetComponent<Character>().data.hasSuperArmor)
                {
                    // Apply the hitbox's gKnockback angle if character does not have super armor
                    Vector3 currentKnockback = KnockbackForce(data.currentKnockback, data.currentKnockbackAngle);
                    col.attachedRigidbody.velocity = Vector3.zero;
                    col.attachedRigidbody.AddForce(currentKnockback, ForceMode.Impulse);
                    
                    // Go to damaged state
                    col.gameObject.GetComponent<Character>().GoToDamagedState(data.damage, data.currentKnockback);
                }
                else
                {
                    // Just get damaged
                    col.gameObject.GetComponent<Character>().data.health -= data.damage;
                }
            }
            if(col.gameObject.TryGetComponent(out playerControl player))
            {
                Debug.Log("Player Damaged by Hitbox!");
                // col.gameObject.GetComponent<playerControl>().healthbar.Damage(data.damage);
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
