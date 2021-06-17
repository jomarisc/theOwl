using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Hitbox
{
    Rigidbody rb;
    private SpriteRenderer sp;
    // public const float INITIAL_SPEED = 12f;
    [SerializeField] private Character myShooter = null;
    public float speed;
    public float mySpeed { get; private set; } // This gets set in the editor and should not be modified in code

    // ProjectileAttack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle) : base(dmg, start, active, lag, gkb, gAngle, akb, aAngle)
    // {}

    void Awake()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    new void OnEnable()
    {
        base.OnEnable();
        mySpeed = speed;
    }

    protected void OnDisable()
    {
        speed = mySpeed;
        sp.enabled = false;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if(phase == AttackPhase.Active)
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
            if(!sp.enabled)
            {
                int shootingDirection = (myShooter.data.isFacingRight) ? 1 : -1;
                SpawnProjectile(shootingDirection);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.TryGetComponent<Character>(out Character c))
        //     col.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
    }

    public void SpawnProjectile(int direction) // Direction should be -1 or 1
    {
        // Vector3 pos = transform.localPosition;
        // pos.x = direction * initialLocalPosition.x;
        // pos.y = 0f;
        // transform.localPosition = pos;

        // speed = myShooter.GetComponent<Rigidbody>().velocity.x + direction * speed;
        // isFacingRight = myShooter.data.isFacingRight;
        // sp.flipX = !myShooter.data.isFacingRight;
        // sp.enabled = true;
    }
}
