using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CharacterData
{
    public int numJumps;
    public int numDodges;
    public float health;
    public float maxSpeed;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;
    public bool isFacingRight; // Determines whether the character is
                               //facing in the right-hand direction
                               // *So far, must be initialized in sub classes*
    public bool hasSuperArmor;
    public float deadDuration;

    //public Animator animator;
    public float dodgeDuration;
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes

    // protected attributes
    protected Rigidbody rb;
    protected IState myState;

    // public attributes
    public CharacterData data;
    public GameObject meleeAttack;
    public Animator animator;
    public readonly int MAX_JUMPS;
    public readonly int MAX_DODGES;
    public readonly float DODGE_DURATION;
    public readonly float DEAD_DURATION;

    public Character(int maxJumps, int maxDodges, float dodgeDuration, float deadDuration)
    {
        MAX_JUMPS = maxJumps;
        MAX_DODGES = maxDodges;
        DODGE_DURATION = dodgeDuration;
        DEAD_DURATION = deadDuration;
    }
    
    public void Update()
    {
        if(data.health <= 0f)
        {
            //GetRekt();
        }

        IState currentState = myState.Update();
        if(currentState != null)
        {
            myState.Exit();
            myState = currentState;
            Debug.Log(myState);
            myState.Enter();
            // Debug.Log("moveY " + animator.GetFloat("VerticalMovement"));
            // Debug.Log("moveX " + animator.GetFloat("horizontalMovement"));
            // Debug.Log("dodging? " + animator.GetBool("dodging"));
            // Debug.Log("idling? " + animator.GetBool("idling"));
            // Debug.Log("moving? " + animator.GetBool("moving"));
            // Debug.Log("tethered? " + animator.GetBool("tethered"));
            // Debug.Log("meleeing? " + animator.GetBool("meleeing"));
            // Debug.Log("gliding? " + animator.GetBool("gliding"));
            // Debug.Log("grounded? " + animator.GetBool("grounded"));
            // Debug.Log("jumping up? " + animator.GetBool("jumpup"));
            // Debug.Log("jumping down? " + animator.GetBool("jumpdown"));
        }
    }

    public void FixedUpdate()
    {
        myState.FixedUpdate();
    }

    // Moves the player left/right based off of the value of its acceleration
    public void MoveCharacter(float direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = direction * data.maxSpeed;
        rb.velocity = newVelocity;
    }

    public void MoveCharacter(float xDirection, float yVelocity)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = xDirection * data.maxSpeed;
        newVelocity[1] = yVelocity;
        rb.velocity = newVelocity;
    }

    public void Jump()
    {
        if(data.numJumps > 0)
        {
            // Vector3 newVelocity = rb.velocity;
            // newVelocity[1] = data.jumpDistance;
            // rb.velocity = newVelocity;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0f, data.jumpDistance, 0f), ForceMode.VelocityChange);
            data.numJumps--;
        }
    }

    public void Attack()
    {
        Vector3 atkPos = meleeAttack.transform.localPosition;
        atkPos[0] = (data.isFacingRight) ? 1.5f : -1.5f;
        meleeAttack.transform.localPosition = atkPos;
    }

    // Currently Only toggles player collisions with Enemy-related rigidbodies/colliders
    public void Dodge()
    {
        if(data.dodgeDuration > 0f)
        {
            // Stop checking collisions with player hurtbox and enemy-related physics layers
            Physics.IgnoreLayerCollision(9, 10, true); // Player x Enemies
            Physics.IgnoreLayerCollision(9, 12, true); // Player x Enemies' Attacks
            // If character is grounded, do a roll in whichever facing direction
            if(data.maxSpeed == data.groundSpeed)
            {
                
            }
            // Else do an 8-directional spin in whichever direction the player is holding
            else
            {

            }
        }
        // This branch should only be called once as dodgeDuration becomes negative
        else
        {
            Physics.IgnoreLayerCollision(9, 12, false); // Player x Enemies' Attacks
            Physics.IgnoreLayerCollision(9, 10, false); // Player x Enemies
        }
    }

    public void GetRekt()
    {
        // New lines
        Debug.Log("Got rekt");
        Destroy(this.gameObject);
    }

    protected void ChangeSkill()
    {
        // Yet to be implemented
    }

    protected void OnCollisionStay(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null &&
           data.maxSpeed != data.groundSpeed)
        {
            data.maxSpeed = data.groundSpeed;
            animator.SetBool("grounded", true);
        }
            
    }
    protected void OnCollisionExit(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
        {
            data.maxSpeed = data.airSpeed;
            animator.SetBool("grounded", false);
        }
            
    }
}
