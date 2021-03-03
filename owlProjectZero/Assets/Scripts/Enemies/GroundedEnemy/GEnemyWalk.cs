using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyWalk : IState
{
    private readonly GroundedEnemy character;
    private Animator animator;
    private const float WALK_TIME = 3f;
    private float horizontalMovement;
    private float waitTime;
    private bool playerFound;
    
    public GEnemyWalk(GroundedEnemy myself)
    {
        character = myself;
        animator = myself.GetComponent<Animator>();
    }

    public void Enter()
    {
        // Enter grounded enemy walk animation here:
        animator.SetBool("walking", true);
        // Debug.Log("Walking: " + animator.GetBool("walking"));
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        waitTime = WALK_TIME;
        playerFound = false;
    }

    public void Exit()
    {
        animator.SetBool("walking", false);
    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
        character.MoveCharacter(horizontalMovement);
    }
    
    public IState Update()
    {
        if(character.isOnEnvironmentEdge())
            return new GEnemyIdle(character);

        if(playerFound)
            return new GEnemyChase(character);

        if(waitTime >= 0f)
        {
            waitTime -= Time.deltaTime;
            return null;
        }
        return new GEnemyIdle(character);
    }
}
