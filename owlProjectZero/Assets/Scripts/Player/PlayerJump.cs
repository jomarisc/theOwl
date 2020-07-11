using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : IState
{
    private readonly playerControl player;

    public PlayerJump(playerControl p)
    {
        player = p;
    }
    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        return null;
    }
}
