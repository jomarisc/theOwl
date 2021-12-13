using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossJump : IState
{
    private readonly MiniBoss character;
    private Animator animator;
    private string myAnimationState;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private bool hasLeftTheGround;
    
    public MiniBossJump(Enemy myself)
    {
        character = (MiniBoss)myself;
        animator = myself.GetComponent<Animator>();
        characterBody = myself.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        myAnimationState = "MiniBossJumpUp";
        animator.Play(myAnimationState);
        if(character.heavyJump.mute)
            character.heavyJump.mute = false;
        character.heavyJump.Play();
        
        characterBody.velocity = Vector3.zero;
        // characterBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        character.Jump();
        hasLeftTheGround = false;
    }

    public void Exit()
    {
        if(!character.heavyJump.mute)
            character.heavyJump.mute = true;
    }

    public void FixedUpdate()
    {
        if(!hasLeftTheGround && characterBody.velocity.y > 0f)
            hasLeftTheGround = true;
    }
    
    public IState Update()
    {
        if(characterBody.velocity.y <= 0f &&
           character.data.maxSpeed == character.data.groundSpeed &&
           character.data.numJumps == character.CONSTANTS.MAX_JUMPS &&
           hasLeftTheGround)
        {
            return new MiniBossSlam(character);
        }
        
        return null;
    }
}
