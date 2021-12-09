using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossPunch : IState
{
    private readonly MiniBoss character;
    private Animator animator;
    private string myAnimationState;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private Collider hitbox;
    private float horizontalMovement;
    private bool playerIsInSight;
    private bool playerIsInAttackRange;
    
    public MiniBossPunch(MiniBoss myself, float hm)
    {
        character = (MiniBoss)myself;
        animator = myself.GetComponent<Animator>();
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.basicAttack.gameObject;
        hitbox = meleeAttack.GetComponentInChildren<Collider>();
        horizontalMovement = hm;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        animator.SetBool("windingUp", true);
        
        characterBody.velocity = Vector3.zero;
        meleeAttack.SetActive(true);
        character.Attack();
        playerIsInSight = false;
        playerIsInAttackRange = false;
    }

    public void Exit()
    {
        if(animator.GetBool("windingUp"))
            animator.SetBool("windingUp", false);

        if(meleeAttack.activeInHierarchy)
        {
            meleeAttack.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if(hitbox.enabled)
            characterBody.AddForce(new Vector3(horizontalMovement * 2f, 0f, 0f), ForceMode.VelocityChange);
    }
    
    public IState Update()
    {
        if(hitbox.enabled && animator.GetBool("windingUp"))
        {
            animator.SetBool("windingUp", false);
            myAnimationState = "MiniBossRush"; // Temporary
            animator.Play(myAnimationState);
        }

        if(!meleeAttack.activeInHierarchy)
        {
            playerIsInSight = character.SeesPlayer();

            if(playerIsInSight)
            {
                playerIsInAttackRange = character.PlayerInAttackRange(character.basicAttack.transform.localPosition.x + character.basicAttack.transform.localScale.x * 10); // 2f comes from scaleY from hitbox's transform component
            }
            
            if(playerIsInAttackRange)
                return new MiniBossPunch(character, horizontalMovement);
            Debug.Log("Returning to idle");
            return new MiniBossIdle(character);
        }
        
        return null;
    }
}
