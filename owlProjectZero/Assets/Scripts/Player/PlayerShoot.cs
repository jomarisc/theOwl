using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : IState
{
    private readonly playerControl player;

    public PlayerShoot(playerControl p)
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
