using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : IState
{
    private readonly playerControl player;

    public PlayerMelee(playerControl p)
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
