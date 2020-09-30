using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossChase : IState
{
    private readonly MiniBoss character;
    private const float TIME_BETWEEN_STEPS = 0.5f;
    private float stepTime;
    private const float MAX_CHASE_DURATION = 3f;
    private float horizontalMovement;
    private float chaseDuration;
    private bool playerIsInSight;
    private bool playerIsInAttackRange;
    IState atkState = null;
    int atkPattern;
    
    public MiniBossChase(Enemy myself)
    {
        character = (MiniBoss)myself;
    }

    public void Enter()
    {
        // Enter grounded enemy chase animation here:
        
        horizontalMovement = (character.data.isFacingRight) ? 1f : -1f;
        stepTime = TIME_BETWEEN_STEPS;
        chaseDuration = MAX_CHASE_DURATION;
        playerIsInSight = true;
        playerIsInAttackRange = false;
        atkPattern = Random.Range(0, 2);
        switch(atkPattern)
        {
            case 0:
                atkState = new MiniBossPunch(character, horizontalMovement);
                break;
            default:
                atkState = new MiniBossJump(character);
                break;
        }
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
        {
            playerIsInAttackRange = character.PlayerInAttackRange(character.basicAttack.transform.localPosition.x + character.basicAttack.transform.localScale.x / 2); // 2f comes from scaleY from hitbox's transform component
        }
    }
    
    public IState Update()
    {
        if(playerIsInAttackRange)
        {
            return atkState;
        }

        if(!playerIsInSight)
            return new MiniBossIdle(character);

        stepTime -= Time.deltaTime;
        chaseDuration -= Time.deltaTime;
        return null;
    }
}
