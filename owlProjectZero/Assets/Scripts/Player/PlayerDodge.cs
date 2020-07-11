using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : IState
{
    private readonly playerControl player;

    public PlayerDodge(playerControl p)
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
