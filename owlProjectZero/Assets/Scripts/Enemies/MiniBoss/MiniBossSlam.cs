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
    
    public MiniBossSlam(MiniBoss myself)
    {
        character = (MiniBoss)myself;
        animator = myself.GetComponent<Animator>();
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.slamHitbox;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        myAnimationState = "MiniBossCrash"; // Temporary
        animator.Play(myAnimationState);
        
        meleeAttack.SetActive(true);
        character.Attack(meleeAttack);
    }

    public void Exit()
    {
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
        if(!meleeAttack.activeInHierarchy)
        {
            Debug.Log("Returning to idle");
            return new MiniBossIdle(character);
        }
        
        return null;
    }
}
