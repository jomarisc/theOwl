using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    SphereCollider sphereCollider;

    private float acceleration;
    private float xSpeed;
    public const int MAX_JUMPS = 3;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        acceleration = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && numJumps > 0)
        {
            Jump();
            numJumps--;
        }
    }

    private void FixedUpdate()
    {
        xSpeed = rb.velocity.x;
        MoveCharacter(acceleration);
    }

}
