using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyAttack : IState
{
    private readonly GroundedEnemy character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;
    private Collider hitbox;
    private float horizontalMovement;
    
    public GEnemyAttack(Enemy myself, float hm)
    {
        character = (GroundedEnemy)myself;
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.meleeAttack.gameObject;
        hitbox = meleeAttack.GetComponent<Collider>();
        horizontalMovement = hm;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        
        characterBody.velocity = Vector3.zero;
        character.Attack();
        meleeAttack.SetActive(true);
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
            return new GEnemyIdle(character);
        }
        
        return null;
    }
}
