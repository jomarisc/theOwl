using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider sphereCollider;

    private float maxSpeed;
    private float acceleration;

    public const int MAX_JUMPS = 3;
    public int numJumps;
    public float groundSpeed;
    public float airSpeed;
    public float xSpeed;
    public float jumpDistance;
    public float dragAmount;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        xSpeed = rb.velocity.x;
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

    // Moves the player left/right based off of the value of its acceleration
    private void MoveCharacter(float direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = direction * maxSpeed;
        rb.velocity = newVelocity;
    }

    private void Jump()
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[1] = jumpDistance;
        rb.velocity = newVelocity;
    }

    private void Attack()
    {
        // Yet to be implemented
    }

    private void Dodge()
    {
        // Yet to be implemented
    }

    private void ChangeSkill()
    {
        // Yet to be implemented
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            maxSpeed = groundSpeed;
    }
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            maxSpeed = airSpeed;
    }
}
