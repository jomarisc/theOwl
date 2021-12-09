using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossIdle : IState
{
    private readonly MiniBoss character;
    private Animator animator;
    private string myAnimationState;
    private const float IDLE_TIME = 3f;
    private float waitTime;
    private bool playerFound;
    
    public MiniBossIdle(MiniBoss myself)
    {
        character = myself;
        animator = myself.GetComponent<Animator>();
    }

    public void Enter()
    {
        // Enter Grounded enemy idle animation here:
        myAnimationState = "MiniBossIdle";
        animator.Play(myAnimationState);

        waitTime = IDLE_TIME;
        playerFound = false;
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
        playerFound = character.SeesPlayer();
    }
    
    public IState Update()
    {
        if(playerFound)
        {
            return new MiniBossChase(character);
        }

        if(waitTime >= 0f)
        {
            waitTime -= Time.deltaTime;
            return null;
        }
        else
        {
            // Turn around and walk
            character.data.isFacingRight = !character.data.isFacingRight;
            return new MiniBossIdle(character);
        }
    }
}
