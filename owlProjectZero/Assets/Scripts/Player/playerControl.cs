﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider sphereCollider;

    public int numJumps = 2;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;
    public float dragAmount;

    private Vector3 movement;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Jump") && numJumps > 0)
        {
            rb.AddForce(new Vector3(0, jumpDistance, 0), ForceMode.Impulse);
            numJumps--;
        }

        // Debug.DrawRay(rb.position, Vector2.down * (sphereCollider.bounds.extents.y), Color.green, 0.1f);
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
        
    }

    private void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * groundSpeed * Time.deltaTime));
    }
}
