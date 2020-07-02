using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes
    private float maxSpeed;

    // protected attributes
    protected Rigidbody rb;

    // public attributes
    public int numJumps;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;

    // Moves the player left/right based off of the value of its acceleration
    public void MoveCharacter(float direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = direction * maxSpeed;
        rb.velocity = newVelocity;
    }

    public void Jump()
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[1] = jumpDistance;
        rb.velocity = newVelocity;
    }

    public void Attack()
    {
        // Yet to be implemented
    }

    public void Dodge()
    {
        // Yet to be implemented
    }

    protected void ChangeSkill()
    {
        // Yet to be implemented
    }

    protected void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            maxSpeed = groundSpeed;
    }
    protected void OnCollisionExit(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            maxSpeed = airSpeed;
    }
}
