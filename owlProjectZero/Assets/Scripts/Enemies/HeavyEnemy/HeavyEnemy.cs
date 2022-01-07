using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : Enemy
{
    // private fields

    // protected fields

    // public fields
    public bool hasCollidedWithHitbox = false;
    public SpriteRenderer atkVFXSprite;
    public AudioSource heavyJump;
    public AudioSource heavyMelee;

    // Initializing maxJumps, maxDodges, dodgeDuration, and deadDuration
    public HeavyEnemy() // : base(1, 0, 3f)
    {}

    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new HEnemyIdle(this);
            myState = defaultState;
        }
    }
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        if(GetComponentInChildren<SpriteRenderer>()) // This is here bc Mini Boss dun have this component
        {
            sRenderer = GetComponentInChildren<SpriteRenderer>();
            myCharacterColor = sRenderer.color;
        }
        animator = GetComponentInChildren<Animator>();
    }

    new private void Update()
    {
        base.Update();
        if(sRenderer != null) // This is here bc Mini Boss dun have this component
            FlipSprite();
    }

    public override void MoveCharacter(float direction)
    {
        rb.AddForce(new Vector3(direction * data.maxSpeed, 0f, 0f), ForceMode.VelocityChange);
    }

    public virtual void FlipSprite()
    {
        sRenderer.flipX = data.isFacingRight;
    }

    public override IEnumerator ShowSuperArmorFeedback(float duration)
    {
        if(data.hasSuperArmor && myCharacterColor != null)
        {
            sRenderer.color = Color.red;
            yield return new WaitForSeconds(duration);
            sRenderer.color = myCharacterColor;
        }
        else
            yield return base.ShowSuperArmorFeedback(duration);
    }
}
