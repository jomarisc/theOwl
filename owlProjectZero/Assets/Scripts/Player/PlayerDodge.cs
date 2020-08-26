using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDodge : IState
{
    private readonly playerControl player;
    private Renderer playerRenderer;
    private Rigidbody playerBody;
    private PlayerInputs input;

    private Animator animator;
    

    public PlayerDodge(playerControl p)
    {
        player = p;
        playerRenderer = p.gameObject.GetComponent<Renderer>();
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        animator = p.gameObject.GetComponent<Animator>();
        input = p.input;
    }
    public void Enter()
    {
        // use ground dodge animation here:

        playerRenderer.material.SetColor("_Color", Color.black);
        player.data.dodgeDuration = player.DODGE_DURATION;
        player.data.numDodges--;

        playerBody.useGravity = false;
        playerBody.velocity = Vector3.zero;
        playerBody.drag = 1.0f;
        float direction = (player.data.isFacingRight) ? 1f : -1f;
        playerBody.AddForce(new Vector3(direction * 10f, 0f, 0f), ForceMode.VelocityChange);
        animator.SetBool("dodging", true);

        player.Dodge();
    }

    public void Exit()
    {
        playerRenderer.material.SetColor("_Color", Color.red);
        playerBody.useGravity = true;
        playerBody.drag = 1.0f;
        player.data.dodgeDuration = -1f;
        animator.SetBool("dodging", false);

        player.Dodge();
    }

    public void FixedUpdate()
    {
        // player.Dodge();
    }

    public IState Update()
    {
        // -1 <= dodgeDuration <= DODGE_DURATION
        // Decrement dodgeDuration until it reaches below 0
        if(player.data.dodgeDuration >= 0f)
        {
            player.data.dodgeDuration -= Time.deltaTime;
            return null;
        }

        // Check for glide input
        if(input.Gameplay.Glide.triggered)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        // If the player has jumped and is still airborne
        // Should be changed to a airborne walk state instead
        // to avoid burning another jump automatically
        if(player.data.maxSpeed == player.data.airSpeed)
        {
            return new PlayerWalk(player, true);
        }
        return new PlayerIdle(player);
    }
}
