using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes
    private float maxSpeed;

    // protected attributes
    [SerializeField]
    protected GameObject meleeAttack = null;
    protected Rigidbody rb;

    // public attributes
    public int numJumps;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;
    public bool isFacingRight; // Determines whether the character is
                               //facing in the right-hand direction
                               // *So far, must be initialized in sub classes*

    // Moves the player left/right based off of the value of its acceleration
    public void MoveCharacter(float direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = direction * maxSpeed;
        rb.velocity = newVelocity;
    }

    public void Jump()
    {
        if(numJumps > 0)
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity[1] = jumpDistance;
            rb.velocity = newVelocity;
            numJumps--;
        }
    }

    public void Attack()
    {
        Vector3 atkPos = meleeAttack.transform.localPosition;
        atkPos[0] = (isFacingRight) ? 1.5f : -1.5f;
        meleeAttack.transform.localPosition = atkPos;
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
