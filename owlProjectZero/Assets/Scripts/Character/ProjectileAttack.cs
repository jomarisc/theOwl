using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    Rigidbody rb;
    // public const float INITIAL_SPEED = 12f;
    public float speed;
    public float mySpeed { get; private set; } // This gets set in the editor and should not be modified in code
    // public float knockback = 5f;
    // public float knockbackAngle = 45f;
    // public float damage = 0.5f;
    // public int activeFrames = 60;

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

    // Update is called once per frame
    // void Update()
    // {
    //     activeFrames--;
    //     if(activeFrames < 0)
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }

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

    // void OnBecameInvisible()
    // {
    //     this.gameObject.SetActive(false);
    // }
}
