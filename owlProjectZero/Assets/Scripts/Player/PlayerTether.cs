﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Tether State
public class PlayerTether : IState
{
    private readonly playerControl player;
    private Rigidbody playerRB;
    private PlayerInputs input;
    private Vector3 tetherDirection;
    private float tetherLength;
    private float angle;
    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerTether(playerControl p)
    {
        player = p;
        playerRB = p.GetComponent<Rigidbody>();
        tetherDirection = p.tetherAbility.activeTetherPoint.transform.position - playerRB.position;
        tetherLength = tetherDirection.magnitude;
        angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
        input = p.input;
    }
    public void Enter()
    {
        // Enter tether animation code here:
        int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        animator.Play("PlayerTether", animationLayer);

        // player.tetherAbility.GetComponent<Renderer>().enabled = true;
        foreach (SpriteRenderer link in player.tetherAbility.chainLinks)
        {
            link.enabled = true;
        }
        player.tetherAbility.GetComponent<Collider>().enabled = true;
        playerRB.velocity = Vector3.zero;
        playerRB.drag = 0f;

        input.Gameplay.Tether.started += player.tetherAbility.Untether;
        input.Gameplay.Glide.started += player.tetherAbility.Untether;
    }

    public void Exit()
    {
        playerRB.drag = 1f;
        // player.tetherAbility.GetComponent<Renderer>().enabled = false;
        foreach (SpriteRenderer link in player.tetherAbility.chainLinks)
        {
            link.enabled = false;
        }
        player.tetherAbility.GetComponent<Collider>().enabled = false;

        input.Gameplay.Tether.started -= player.tetherAbility.Untether;
        input.Gameplay.Glide.started -= player.tetherAbility.Untether;
    }

    public void FixedUpdate()
    {
        if(player.tetherAbility.activeTetherPoint != null)
        {
            tetherDirection = player.tetherAbility.activeTetherPoint.transform.position - playerRB.position;
            angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
            player.tetherAbility.TetherSwing(tetherLength, tetherDirection, angle);
        }
    }

    public IState Update()
    {
        //Checking velocity to change sprite direction.
        if (playerRB.velocity.x > 0)
            spriterenderer.flipX = false;
        else if (playerRB.velocity.x < 0)
            spriterenderer.flipX = true;
        else {}

        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
            return new PlayerDodge(player);

        // Check input for jumping
        if(input.Gameplay.Jump.triggered)
            return new PlayerJump(player);

        // Check input for melee attacking
        if(input.Gameplay.Melee.triggered)
            return new PlayerMelee(player, 0f);

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
            return new PlayerShoot(player);

        // Check for glide input
        if(input.Gameplay.Glide.ReadValue<float>() > 0.8f &&
           input.Gameplay.Glide.phase == InputActionPhase.Started)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        if(player.tetherAbility.activeTetherPoint == null ||
           player.transform.position.y > player.tetherAbility.activeTetherPoint.transform.position.y)
        {
            return new PlayerMove(player, true); // Specify the airborne version later
        }

        // Update tether position, size, and rotation
        if(player.tetherAbility.activeTetherPoint != null)
        {
            Vector3 tetherPos = tetherDirection;
            // player.tetherAbility.transform.localPosition = tetherPos;

            Quaternion tetherRotation = new Quaternion();
            float tetherAngle = -angle * Mathf.Rad2Deg;
            tetherRotation.eulerAngles = new Vector3(0f, 0f, tetherAngle);
            player.tetherAbility.transform.rotation = tetherRotation;

            Vector3 tetherScale = player.tetherAbility.transform.localScale;
            tetherScale[1] = tetherDirection.magnitude / 2;
            // player.tetherAbility.transform.localScale = tetherScale;

            for(int i = 0; i < player.tetherAbility.chainLinks.Length; i++)
            {
                // Debug.Log("(" + (i + 1) + ") / " + player.tetherAbility.chainLinks.Length + " * " + tetherPos);
                float fractionOfLength = (float)((i + 1) / (float)(player.tetherAbility.chainLinks.Length + 1));
                Vector3 linkPos = new Vector3(0f, fractionOfLength * tetherDirection.magnitude, 0f);
                // Debug.Log("fraction of length: " + fractionOfLength);
                player.tetherAbility.chainLinks[i].transform.localPosition = linkPos;
                // Debug.Log("= " + player.tetherAbility.chainLinks[i].transform.localPosition);
                // player.tetherAbility.chainLinks[i].transform.rotation = tetherRotation;
            }
            // Debug.Break();
        }

        return null;
    }
}
