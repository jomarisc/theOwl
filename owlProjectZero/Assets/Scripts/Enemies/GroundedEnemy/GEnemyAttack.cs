using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyAttack : IState
{
    private readonly GroundedEnemy character;
    private Animator animator;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private Collider hitbox;
    private float horizontalMovement;
    
    public GEnemyAttack(Enemy myself, float hm)
    {
        character = (GroundedEnemy)myself;
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
        character.windUp.Play();
        characterBody.velocity = Vector3.zero;
        meleeAttack.SetActive(true);
        character.Attack();
    }

    public void Exit()
    {
        if(animator.GetBool("windingUp"))
            animator.SetBool("windingUp", false);

        if(animator.GetBool("attacking"))
            animator.SetBool("attacking", false);

        if(character.windUp.isPlaying)
            character.windUp.Stop();

        if(meleeAttack.activeInHierarchy)
        {
            hitbox.enabled = false;
            meleeAttack.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if(meleeAttack.GetComponentInChildren<Hitbox>().phase == AttackPhase.Active) // hitbox.enabled)
            characterBody.AddForce(new Vector3(horizontalMovement, 0f, 0f), ForceMode.VelocityChange);
    }
    
    public IState Update()
    {
        if(character.isOnEnvironmentEdge())
            return new GEnemyIdle(character);

        if(hitbox.enabled && animator.GetBool("windingUp"))
        {
            animator.SetBool("windingUp", false);
            animator.SetBool("attacking", true);
            character.sfxMelee.Play();
        }
        
        if(!meleeAttack.activeInHierarchy) // && Mathf.Approximately(characterBody.velocity.magnitude, 0f))
        {
            // Debug.Log("Returning to idle");
            return new GEnemyIdle(character);
        }
        
        return null;
    }
}
