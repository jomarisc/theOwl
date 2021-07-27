using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    Rigidbody rb;
    private SpriteRenderer sp;
    // public const float INITIAL_SPEED = 12f;
    [SerializeField] private Character myShooter = null;
    public float speed;
    [Tooltip("properSpeed is the value that the above speed should return to OnEnable and OnDisable()")]
    [HideInInspector] public float properSpeed;

    ProjectileAttack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle) : base(dmg, start, active, lag, gkb, gAngle, akb, aAngle)
    {}

    new void Awake()
    {
        base.Awake();
        sp = GetComponentInChildren<SpriteRenderer>();
        properSpeed = speed;
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }
    new void OnEnable()
    {
        base.OnEnable();
        speed = properSpeed;
    }

    new void OnDisable()
    {
        base.OnDisable();
        speed = properSpeed;
        sp.enabled = false;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        foreach (Hitbox hitbox in hitboxes)
        {
            if(hitbox.phase == AttackPhase.Active)
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
                if(!sp.enabled)
                {
                    int shootingDirection = (myShooter.data.isFacingRight) ? 1 : -1;
                    SpawnProjectile(shootingDirection);
                }
            }
        }
    }

    new void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        if(col.TryGetComponent<Character>(out Character c))
        //     col.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
    }

    public void SpawnProjectile(int direction) // Direction should be -1 or 1
    {
        Vector3 pos = transform.localPosition;
        pos.x = direction * initialLocalPosition.x;
        pos.y = 0f;
        transform.localPosition = pos;

        speed = myShooter.GetComponent<Rigidbody>().velocity.x + direction * speed;
        isFacingRight = myShooter.data.isFacingRight;
        sp.flipX = !myShooter.data.isFacingRight;
        sp.enabled = true;
    }
}
