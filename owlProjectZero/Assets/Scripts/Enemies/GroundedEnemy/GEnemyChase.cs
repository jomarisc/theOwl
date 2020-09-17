using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyChase : IState
{
    private readonly GroundedEnemy character;
    private const float MAX_CHASE_DURATION = 3f;
    private float horizontalMovement;
    private float chaseDuration;
    private bool playerIsInSight;
    private bool playerIsInAttackRange;
    
    public GEnemyChase(Enemy myself)
    {
        character = (GroundedEnemy)myself;
    }

    public void Enter()
    {
        // Enter grounded enemy chase animation here:
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
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
        character.MoveCharacter(horizontalMovement);
        playerIsInSight = character.SeesPlayer();

        if(playerIsInSight)
            playerIsInAttackRange = character.PlayerInAttackRange(character.basicAttack.transform.localPosition.x);
    }
    
    public IState Update()
    {
        if(playerIsInAttackRange || chaseDuration < 0f)
            return new GEnemyAttack(character, horizontalMovement);

        if(!playerIsInSight)
            return new GEnemyIdle(character);

        chaseDuration -= Time.deltaTime;
        return null;
    }
}
