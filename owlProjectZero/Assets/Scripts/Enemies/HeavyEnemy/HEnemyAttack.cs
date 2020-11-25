using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyAttack : IState
{
    private readonly HeavyEnemy character;
    private Rigidbody characterBody;
    private GameObject meleeAttack;

    public AudioSource heavyMelee;
    
    public HEnemyAttack(Enemy myself)
    {
        character = (HeavyEnemy)myself;
        characterBody = myself.GetComponent<Rigidbody>();
        meleeAttack = myself.basicAttack.gameObject;
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        character.animator.Play("HeavyAttack");
        
        meleeAttack.SetActive(true);
        character.Attack();
        heavyMelee.Play();
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
            return new HEnemyIdle(character);
        }
        
        return null;
    }
}
