﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDodge : IState
{
    private readonly playerControl player;
    private Renderer playerRenderer;
    private Rigidbody playerBody;
    private PlayerInputs.DodgingActions dodgeInput;

    public PlayerDodge(playerControl p)
    {
        player = p;
        playerRenderer = p.gameObject.GetComponent<Renderer>();
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        dodgeInput = p.input.Dodging;
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

        dodgeInput.Enable();
        Debug.Log(player.input.Moving.enabled);
    }

    public void Exit()
    {
        playerRenderer.material.SetColor("_Color", Color.red);
        playerBody.useGravity = true;
        playerBody.drag = 0.0f;
        player.dodgeDuration = -1f;

        dodgeInput.Disable();
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

        // Check for glide input
        // if(Input.GetAxis("Vertical") < 0)
        if(dodgeInput.Glide.triggered)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        
        // Debug.Log("Dodge: " + dodgeInput.Walk.ReadValue<float>());
        // Debug.Break();
        // If the player has jumped and is still airborne
        // Should be changed to a airborne walk state instead
        // to avoid burning another jump automatically
        if(player.maxSpeed == player.airSpeed &&
           dodgeInput.Walk.triggered)
        {
            return new PlayerWalk(player, true);
        }
        return new PlayerIdle(player);
    }
}
