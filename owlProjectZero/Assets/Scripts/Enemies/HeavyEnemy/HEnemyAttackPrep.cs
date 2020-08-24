// Still trying to figure out how to perform jumping earthquake attack



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyAttackPrep : IState
{
    private readonly HeavyEnemy character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    
    public HEnemyAttackPrep(Enemy myself)
    {
        character = (HeavyEnemy)myself;
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.meleeAttack.gameObject;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        characterBody.velocity = Vector3.zero;
        characterBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
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
           character.data.numJumps == character.MAX_JUMPS)
        {
            return new HEnemyAttack(character);
        }
        
        return null;
    }
}
