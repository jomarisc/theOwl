using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSlam : IState
{
    private readonly MiniBoss character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    
    public MiniBossSlam(MiniBoss myself)
    {
        character = (MiniBoss)myself;
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.slamHitbox;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        meleeAttack.SetActive(true);
        character.Attack();
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
