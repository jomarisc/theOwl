﻿using System.Collections;
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
    public float dodgeDuration;
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes

    // protected attributes
    protected Rigidbody rb;

    // public attributes
    public GameObject meleeAttack;
    public CharacterData data;
    public readonly int MAX_JUMPS;
    public readonly int MAX_DODGES;
    public readonly float DODGE_DURATION;

    public Character(int maxJumps, int maxDodges, float dodgeDuration)
    {
        MAX_JUMPS = maxJumps;
        MAX_DODGES = maxDodges;
        DODGE_DURATION = dodgeDuration;
    }
    
    public void Update()
    {
        if(data.health <= 0f)
        {
            Debug.Log("Got rekt");
            Destroy(this.gameObject);
        }
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
            Vector3 newVelocity = rb.velocity;
            newVelocity[1] = data.jumpDistance;
            rb.velocity = newVelocity;
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
            Physics.IgnoreLayerCollision(9, 10, false); // Player x Enemies
            Physics.IgnoreLayerCollision(9, 12, false); // Player x Enemies' Attacks
            var myRenderer = GetComponent<Renderer>();
            myRenderer.material.SetColor("_Color", Color.red);
        }
    }

    public void GetRekt()
    {
        
    }

    protected void ChangeSkill()
    {
        // Yet to be implemented
    }

    protected void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            data.maxSpeed = data.groundSpeed;
    }
    protected void OnCollisionExit(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
            data.maxSpeed = data.airSpeed;
    }
}
