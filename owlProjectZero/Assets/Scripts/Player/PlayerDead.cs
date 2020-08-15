using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : IState
{
    private readonly playerControl player;

    public PlayerDead(playerControl p)
    {
        player = p;
    }

    public void Enter()
    {
        player.Dodge();
        player.data.deadDuration = player.DEAD_DURATION;
    }

    public void Exit()
    {
        player.GetRekt();// Nothing so far
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        if (player.data.deadDuration >= 0f)
        {
            player.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
            return null;
        }

        return new PlayerIdle(player);
    }

        // Remember to handle collision between player and enemy
}
