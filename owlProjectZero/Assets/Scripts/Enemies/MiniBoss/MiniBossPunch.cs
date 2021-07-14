using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossPunch : IState
{
    private readonly MiniBoss character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private Collider hitbox;
    private float horizontalMovement;
    
    public MiniBossPunch(MiniBoss myself, float hm)
    {
        character = (MiniBoss)myself;
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.basicAttack.gameObject;
        hitbox = meleeAttack.GetComponentInChildren<Collider>();
        horizontalMovement = hm;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        characterBody.velocity = Vector3.zero;
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
        if(hitbox.enabled)
            characterBody.AddForce(new Vector3(horizontalMovement, 0f, 0f), ForceMode.VelocityChange);
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
