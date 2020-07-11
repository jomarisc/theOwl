using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : IState
{
    private readonly playerControl player;

    public PlayerWalk(playerControl p)
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
