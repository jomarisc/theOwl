using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    Rigidbody rb;
    // public const float INITIAL_SPEED = 12f;
    public float speed;
    // public float knockback = 5f;
    // public float knockbackAngle = 45f;
    // public float damage = 0.5f;
    // public int activeFrames = 60;

    ProjectileAttack(float dmg, int start, int active, int lag, float kb, float angle) : base(dmg, start, active, lag, kb, angle)
    {}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // void OnEnable()
    // {
    //     activeFrames = 60;
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     activeFrames--;
    //     if(activeFrames < 0)
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }

    // void OnTriggerEnter(Collider col)
    // {
    //     if(col.GetComponent<EnvironmentElement>() == null)
    //         col.gameObject.SetActive(false);
    //     this.gameObject.SetActive(false);
    // }

    // void OnBecameInvisible()
    // {
    //     this.gameObject.SetActive(false);
    // }
}
