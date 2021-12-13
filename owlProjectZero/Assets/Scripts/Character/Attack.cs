// This script enables the hitbox(es) associated with this particular
// attack and reverses the initial position and knockback angles of the
// hitbox(es) based on the direction the character is facing.
// 
// *There must be a parent object with the Character component attached
// *Hitbox(es) must be attached to children of the game object with this Attack
//  script attached

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Attack : MonoBehaviour
{
    // private fields
    private Character myCharacter;

    // protected fields
    protected List<Hitbox> hitboxes;
    [Header("General")]

    // public fields
    [HideInInspector]
    public bool isFacingRight;
    public Vector3 initialLocalPosition { get; private set; }
    public float initialKnockbackAngle { get; private set; }

    [Header("Audio Sources")]
    public AudioSource onCharacterHitSFX;
    public AudioSource onEnvironmentHitSFX;

    // Constructors for attack with only 1 hitbox
    public Attack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle)
    {
        // hitboxes = new Hitbox[1];
        // hitboxes[0].data.shape = GetComponent<Collider>();
        // hitboxes[0].data.damage = dmg;
        // hitboxes[0].data.startup = start;
        // hitboxes[0].data.timeActive = active;
        // hitboxes[0].data.recovery = lag;
        // hitboxes[0].data.gKnockback = gkb;
        // hitboxes[0].data.gKnockbackAngle = gAngle;
        // hitboxes[0].data.aKnockback = akb;
        // hitboxes[0].data.aKnockbackAngle = aAngle;
    }

    public Attack(Hitbox hitbox)
    {
        // hitboxes = new Hitbox[1];
        // hitboxes[0] = hitbox;
    }

    // Constructor for attack with multiple hitboxes
    public Attack(Hitbox[] hitboxes)
    {
        InitializeHitboxes(hitboxes, hitboxes.Length);
    }

    protected void Awake()
    {
        myCharacter = GetComponentInParent<Character>();
        hitboxes = new List<Hitbox>(GetComponentsInChildren<Hitbox>());
    }

    protected void Start()
    {
        // Vector3 tempLocalPos = transform.localPosition;
        // bool onRightSide = (transform.localPosition.x > 0f) ? true : false;
        // tempLocalPos.x = Mathf.Abs(tempLocalPos.x);
        // initialLocalPosition = tempLocalPos;
        // Debug.Log($"Initial Local Postition: {initialLocalPosition}");
        // Debug.Break();
    }

    protected virtual void OnEnable()
    {
        hitboxes = new List<Hitbox>(GetComponentsInChildren<Hitbox>());
        isFacingRight = myCharacter.data.isFacingRight;
        bool characterIsGrounded = myCharacter.data.maxSpeed == myCharacter.data.groundSpeed;
        /* USE FOR_EACH LOOP */
        foreach (Hitbox hitbox in hitboxes)
        {
            hitbox.enabled = true;
            // Subscribe to hitbox deactivation event
            hitbox.OnHitboxFinished += CheckRemainingHitboxes;
            // Adjust kb values to either grounded or aerial variants
            hitbox.data.currentKnockback = (characterIsGrounded) ? hitbox.data.gKnockback : hitbox.data.aKnockback;
            hitbox.data.currentKnockbackAngle = (characterIsGrounded) ? hitbox.data.gKnockbackAngle : hitbox.data.aKnockbackAngle;

            // Flip kb angle based off of character facing direction
            initialKnockbackAngle = hitbox.data.gKnockbackAngle;
            hitbox.data.currentKnockbackAngle = (isFacingRight) ? hitbox.data.currentKnockbackAngle : 180 - hitbox.data.currentKnockbackAngle;

            // Mirror the hitbox local positions across the y-axis if isFacingRight
            Vector3 hitboxPos = hitbox.transform.localPosition;
            hitbox.data.initialLocalPosition = hitboxPos; // Required in this script bc this runs before Hitbox.cs's Awake/OnEnable for some reason despite attempts to change script execution order
            hitboxPos.x = (isFacingRight) ? hitbox.data.initialLocalPosition.x : -hitbox.data.initialLocalPosition.x;
            hitbox.transform.localPosition = hitboxPos;
            // Debug.Log("Facing Right?" + isFacingRight);
        }
        /* MAKE SURE YOU'VE USED THE FOR_EACH LOOP */
        


        Vector3 tempLocalPos = transform.localPosition;
        initialLocalPosition = tempLocalPos;

        // Flip kb angle based off of character facing direction
    }

    protected void OnDisable()
    {
        Vector3 localPos = transform.localPosition;
        localPos = initialLocalPosition;
        transform.localPosition = localPos;
        /* ITERATE THRU ALL HITBOXES */
        foreach (Hitbox hitbox in hitboxes)
        {
            hitbox.data.gKnockbackAngle = initialKnockbackAngle;
        }
        /*****************************/
        hitboxes.Clear();
    }

    protected virtual void FixedUpdate()
    {
        /* IF LAST HITBOX HAS BECOME INACTIVE */
            // gameObject.SetActive(false);
        /* MAKE SURE TO FINISH THIS BLOCK OF CODE */ // Moved the logic here to CheckRemainingHitboxes method
    }

    protected void OnTriggerEnter(Collider col)
    {
        PlayOnHitSFX(col);
    }
    
    // Initializes hitbox data for a given attack
    // Helpful if an attack has multiple hitboxes
    private void InitializeHitboxes(Hitbox[] atkData, int numHitboxes)
    {
        if(numHitboxes != atkData.Length)
        {
            Debug.Log("Failed Hitbox Initialization");
            return;
        }

        // hitboxes = new Hitbox[numHitboxes];
        // for(int i = 0 ; i < numHitboxes; i++)
        // {
        //     hitboxes[i] = atkData[i];
        // }

        hitboxes = new List<Hitbox>(atkData);
    }

    public void PlayOnHitSFX(Collider col)
    {
        if(col.TryGetComponent(out Character c))
            onCharacterHitSFX.Play();
        
        if(col.TryGetComponent(out EnvironmentElement ee))
            onEnvironmentHitSFX.Play();
    }

    private void CheckRemainingHitboxes()
    {
        // Check for deacvitvated hitboxes
        foreach (Hitbox hitbox in hitboxes)
        {
            if(!hitbox.enabled)
            {
                hitbox.data.gKnockbackAngle = initialKnockbackAngle;
                hitbox.OnHitboxFinished -= CheckRemainingHitboxes;
                hitboxes.Remove(hitbox);
                break;
            }
        }
        
        if(hitboxes.Count <= 0)
        {
            // Debug.Log("Deactivating Hitbox");
            gameObject.SetActive(false);
            // Debug.Log("Finished Deactivating Hitbox");
        }
    }
}
