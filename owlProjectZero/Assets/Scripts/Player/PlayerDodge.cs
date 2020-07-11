using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : IState
{
    private readonly playerControl player;
    private Renderer playerRenderer;
    private Rigidbody playerBody;

    public PlayerDodge(playerControl p)
    {
        player = p;
        playerRenderer = p.gameObject.GetComponent<Renderer>();
        playerBody = p.gameObject.GetComponent<Rigidbody>();
    }
    public void Enter()
    {
        // use ground dodge animation here:

        playerRenderer.material.SetColor("_Color", Color.black);
        player.dodgeDuration = playerControl.DODGE_DURATION;

        float direction = (player.isFacingRight) ? 1f : -1f;
        playerBody.AddForce(new Vector3(direction * 5f, 0f, 0f), ForceMode.Impulse);
    }

    public void Exit()
    {
        playerRenderer.material.SetColor("_Color", Color.red);
        player.dodgeDuration = -1f;
    }

    public void FixedUpdate()
    {
        player.Dodge();
    }

    public IState Update()
    {
        // -1 <= dodgeDuration <= DODGE_DURATION
        // Decrement dodgeDuration until it reaches below 0
        if(player.dodgeDuration >= 0f)
        {
            player.dodgeDuration -= Time.deltaTime;
            return null;
        }
        return new PlayerIdle(player);
    }
}
