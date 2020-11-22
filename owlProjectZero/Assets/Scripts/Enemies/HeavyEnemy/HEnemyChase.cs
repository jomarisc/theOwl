using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyChase : IState
{
    private readonly HeavyEnemy character;
    private const float TIME_BETWEEN_STEPS = 0.5f;
    private float stepTime;
    private const float MAX_CHASE_DURATION = 3f;
    private float horizontalMovement;
    private float chaseDuration;
    private bool playerIsInSight;
    private bool playerIsInAttackRange;
    
    public HEnemyChase(Enemy myself)
    {
        character = (HeavyEnemy)myself;
    }

    public void Enter()
    {
        // Enter grounded enemy chase animation here:
        character.animator.Play("HeavyWalk");
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        stepTime = TIME_BETWEEN_STEPS;
        chaseDuration = MAX_CHASE_DURATION;
        playerIsInSight = true;
        playerIsInAttackRange = false;
    }

    public void Exit()
    {
        // Nothing so far
    }

    public void FixedUpdate()
    {
        // character.MoveCharacter(horizontalMovement);
        if(stepTime <= 0f)
        {
            character.MoveCharacter(horizontalMovement);
            stepTime = TIME_BETWEEN_STEPS;
        }

        playerIsInSight = character.SeesPlayer();

        if(playerIsInSight)
            playerIsInAttackRange = character.PlayerInAttackRange(character.basicAttack.transform.localPosition.x); // 2f comes from scaleY from hitbox's transform component
    }
    
    public IState Update()
    {
        if(character.isOnEnvironmentEdge())
            return new HEnemyIdle(character);

        if(playerIsInAttackRange)
            return new HEnemyAttackPrep(character);

        if(!playerIsInSight)
            return new HEnemyIdle(character);

        stepTime -= Time.deltaTime;
        chaseDuration -= Time.deltaTime;
        return null;
    }
}
