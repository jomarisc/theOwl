// Still trying to figure out how to perform jumping earthquake attack



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyAttackPrep : IState
{
    private readonly HeavyEnemy character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private bool hasLeftTheGround;
    
    public HEnemyAttackPrep(Enemy myself)
    {
        character = (HeavyEnemy)myself;
        characterBody = myself.GetComponent<Rigidbody>();
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        character.animator.Play("HeavyJump");
        if(character.heavyJump.mute)
            character.heavyJump.mute = false;
        character.heavyJump.Play();
        characterBody.velocity = Vector3.zero;
        characterBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        hasLeftTheGround = false;
    }

    public void Exit()
    {
        if(!character.heavyJump.mute)
            character.heavyJump.mute = true;
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
            return new HEnemyAttack(character);
        }
        else if(characterBody.velocity.y > 0f)
            hasLeftTheGround = true;
        
        return null;
    }
}
