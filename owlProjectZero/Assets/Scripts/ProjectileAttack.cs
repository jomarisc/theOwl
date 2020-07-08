using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    Rigidbody rb;
    public const float INITIAL_SPEED = 12f;
    public float speed = INITIAL_SPEED;
    public float knockback = 5f;
    public float knockbackAngle = 45f;
    public float damage = 0.5f;
    public int activeFrames = 60;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        activeFrames = 60;
    }

    // Update is called once per frame
    void Update()
    {
        activeFrames--;
        if(activeFrames < 0)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
