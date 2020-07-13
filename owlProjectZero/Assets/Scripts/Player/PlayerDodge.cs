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
        player.numDodges--;

        playerBody.useGravity = false;
        playerBody.velocity = Vector3.zero;
        playerBody.drag = 1.0f;
        float direction = (player.isFacingRight) ? 1f : -1f;
        playerBody.AddForce(new Vector3(direction * 10f, 0f, 0f), ForceMode.VelocityChange);
    }

    public void Exit()
    {
        playerRenderer.material.SetColor("_Color", Color.red);
        playerBody.useGravity = true;
        playerBody.drag = 0.0f;
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

        // If the player has jumped and is still airborne
        // Should be changed to a glide state instead
        // to avoid burning another jump automatically
        if(player.maxSpeed == player.airSpeed &&
           player.numJumps < playerControl.MAX_JUMPS)
        {
            return new PlayerJump(player);
        }
        return new PlayerIdle(player);
    }
}
