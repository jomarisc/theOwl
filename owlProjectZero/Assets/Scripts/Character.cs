using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes
    [SerializeField]
    private GameObject meleeAttack;
    private float maxSpeed;

    // protected attributes
    protected Rigidbody rb;

    // public attributes
    public int numJumps;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;
    public bool isFacingRight; // Determines whether the character is
                               //facing in the right-hand direction

    // Moves the player left/right based off of the value of its acceleration
    public void MoveCharacter(float direction)
    {
        if(Mathf.Abs(direction) > 0)
        {
            if(direction < 0)
            {
                isFacingRight = false;
            }
            else
            {
                isFacingRight = true;
            }
        }
        
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
        // Yet to be implemented
        meleeAttack.gameObject.SetActive(true);

        Vector3 atkPos = meleeAttack.transform.localPosition;
        if(isFacingRight)
        {
            atkPos[0] = 1.5f;
        }
        else
        {
            atkPos[0] = -1.5f;
        }
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
