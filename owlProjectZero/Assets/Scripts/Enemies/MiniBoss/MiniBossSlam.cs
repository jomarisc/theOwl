using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSlam : IState
{
    private readonly MiniBoss character;
    private Animator animator;
    private string myAnimationState;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private Collider hitbox;
    private Animator atkVFXAnimator;
    
    public MiniBossSlam(MiniBoss myself)
    {
        character = (MiniBoss)myself;
        animator = myself.GetComponent<Animator>();
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.slamHitbox;
        hitbox = character.slamHitbox.GetComponentInChildren<Collider>();
        atkVFXAnimator = character.atkVFXSprite.GetComponent<Animator>();
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        character.atkVFXSprite.flipX = character.data.isFacingRight;
        // Mirror the sprite position
        if(!character.data.isFacingRight)
        {
            Vector3 newAtkVFXPos = character.atkVFXSprite.transform.localPosition;
            newAtkVFXPos.x *= -1;
            character.atkVFXSprite.transform.localPosition = newAtkVFXPos;
        }
        atkVFXAnimator.enabled = false;
        myAnimationState = "MiniBossCrash"; // Temporary
        animator.Play(myAnimationState);
        character.heavyMelee.Play();
        
        meleeAttack.SetActive(true);
        character.Attack(meleeAttack);
    }

    public void Exit()
    {
        // Set the sprite position back to normal
        if(!character.data.isFacingRight)
        {
            Vector3 newAtkVFXPos = character.atkVFXSprite.transform.localPosition;
            newAtkVFXPos.x *= -1;
            character.atkVFXSprite.transform.localPosition = newAtkVFXPos;
        }
        atkVFXAnimator.enabled = false;
        
        if(meleeAttack.activeInHierarchy)
        {
            meleeAttack.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        
    }
    
    public IState Update()
    {
        if(hitbox.enabled && !atkVFXAnimator.enabled)
            atkVFXAnimator.enabled = true;

        if(!meleeAttack.activeInHierarchy)
        {
            Debug.Log("Returning to idle");
            return new MiniBossIdle(character);
        }
        
        return null;
    }
}
