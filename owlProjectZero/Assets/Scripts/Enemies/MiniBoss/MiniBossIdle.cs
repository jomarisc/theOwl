﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossIdle : IState
{
    private readonly MiniBoss character;
    private const float IDLE_TIME = 3f;
    private float waitTime;
    private bool playerFound;
    
    public MiniBossIdle(MiniBoss myself)
    {
        character = myself;
    }

    public void Enter()
    {
        // Enter Grounded enemy idle animation here:

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
