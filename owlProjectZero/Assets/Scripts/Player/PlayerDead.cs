using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : IState
{
    private readonly playerControl player;
    
    public PlayerDead(playerControl p)
    {
        player = p;
    }

    public void Enter()
    {
        player.GetComponent<SpriteRenderer>().color = Color.red;

        player.Dodge(); // Prevents collision with other enemies

        player.data.deadDuration = player.DEAD_DURATION;
    }

    public void Exit()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;

        // Old code
        //player.GetRekt();// Nothing so far
        //SceneManager.LoadScene("MainMenu");
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
