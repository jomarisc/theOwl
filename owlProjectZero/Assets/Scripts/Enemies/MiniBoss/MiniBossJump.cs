using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossJump : IState
{
    private readonly MiniBoss character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private bool hasLeftTheGround;
    
    public MiniBossJump(Enemy myself)
    {
        character = (MiniBoss)myself;
        characterBody = myself.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        characterBody.velocity = Vector3.zero;
        // characterBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        character.Jump();
        hasLeftTheGround = false;
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
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
        else if(characterBody.velocity.y > 0f)
            hasLeftTheGround = true;
        
        return null;
    }
}
