using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnEnable()
    {
        transform.eulerAngles = new Vector3(0f, 0f, hitboxes[0].knockbackAngle);
        startupDuration = hitboxes[0].startup * Time.fixedDeltaTime;
        activeDuration = hitboxes[0].timeActive * Time.fixedDeltaTime;
        recoveryDuration = hitboxes[0].recovery * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        if(startupDuration > 0f)
        {
            startupDuration -= Time.fixedDeltaTime;
        }
        else if(activeDuration > 0f)
        {
            activeDuration -= Time.fixedDeltaTime;
        }
        else
        {
            recoveryDuration -= Time.fixedDeltaTime;
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
            // Use the hitbox's transform rotation as the knockback angle
            Vector3 knockback = KnockbackForce(hitboxes[0].knockback, transform.eulerAngles[2]);
            col.attachedRigidbody.AddForce(knockback, ForceMode.VelocityChange);

            // This should eventually get refactored into a damaged state for the
            // character class
            if(col.gameObject.TryGetComponent(out Character character))
            {
                col.gameObject.GetComponent<Character>().health -= hitboxes[0].damage;
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
