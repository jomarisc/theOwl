using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    Rigidbody rb;
    // public const float INITIAL_SPEED = 12f;
    [SerializeField] private Character myShooter;
    public float speed;
    public float mySpeed { get; private set; } // This gets set in the editor and should not be modified in code

    ProjectileAttack(float dmg, int start, int active, int lag, float kb, float angle) : base(dmg, start, active, lag, kb, angle)
    {}

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }
    new void OnEnable()
    {
        base.OnEnable();
        mySpeed = speed;
    }

    new void OnDisable()
    {
        base.OnDisable();
        speed = mySpeed;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        rb.velocity = new Vector3(speed, 0f, 0f);
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
        // projectile.SetActive(true);
        // ProjectileAttack projAtk = projectile.GetComponent<ProjectileAttack>();
        // Vector3 projPos = projectile.transform.position;
        // projPos.x = transform.position.x + direction * projAtk.initialLocalPosition;
        // projPos.y = transform.position.y;
        // projectile.transform.position = projPos;

        // projAtk.speed = rb.velocity.x + direction * projAtk.mySpeed;
        // projAtk.isFacingRight = data.isFacingRight;

        Vector3 pos = transform.localPosition;
        pos.x = direction * initialLocalPosition;
        transform.localPosition = pos;

        speed = myShooter.GetComponent<Rigidbody>().velocity.x + direction * speed;
        isFacingRight = myShooter.data.isFacingRight;
    }
}
