using System.Collections;
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
    //References to animator and sprite renderer.
    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerTether(playerControl p)
    {
        player = p;
        playerRB = p.GetComponent<Rigidbody>();
        tetherDirection = p.activeTetherPoint.transform.position - playerRB.position;
        tetherLength = tetherDirection.magnitude;
        angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
        //Set those references.
        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
        input = p.input;
    }
    public void Enter()
    {
        // Enter tether animation code here:


        player.tether.SetActive(true);
        playerRB.velocity = Vector3.zero;
        playerRB.drag = 0f;
        animator.SetBool("tethered", true);

        input.Gameplay.Tether.started += player.Untether;
        input.Gameplay.Glide.started += player.Untether;
    }

    public void Exit()
    {
        playerRB.drag = 1f;
        player.tether.SetActive(false);
        animator.SetBool("tethered", false);

        input.Gameplay.Tether.started -= player.Untether;
        input.Gameplay.Glide.started -= player.Untether;
    }

    public void FixedUpdate()
    {
        if(player.activeTetherPoint != null)
        {
            tetherDirection = player.activeTetherPoint.transform.position - playerRB.position;
            angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
            player.TetherSwing(tetherLength, tetherDirection, angle);
        }
    }

    public IState Update()
    {
        //Checking velocity to change sprite direction.
        if (playerRB.velocity.x > 0)
        {
            spriterenderer.flipX = false;
        }
        else if (playerRB.velocity.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else
        {

        }

        // Check input for dodging
        if(input.Gameplay.Dodge.triggered && player.data.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        if(input.Gameplay.Jump.triggered)
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        if(input.Gameplay.Melee.triggered)
        {
            return new PlayerMelee(player, 0f);
        }

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }

        // Check for glide input
        if(input.Gameplay.Glide.ReadValue<float>() > 0.8f &&
           input.Gameplay.Glide.phase == InputActionPhase.Started)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        if(player.activeTetherPoint == null ||
           player.transform.position.y > player.activeTetherPoint.transform.position.y)
        {
            return new PlayerWalk(player, true); // Specify the airborne version later
        }

        // Update tether position, size, and rotation
        if(player.activeTetherPoint != null)
        {
            Vector3 tetherPos = tetherDirection / 2;
            player.tether.transform.localPosition = tetherPos;

            Quaternion tetherRotation = new Quaternion();
            float tetherAngle = -angle * Mathf.Rad2Deg;
            tetherRotation.eulerAngles = new Vector3(0f, 0f, tetherAngle);
            player.tether.transform.rotation = tetherRotation;

            Vector3 tetherScale = player.tether.transform.localScale;
            tetherScale[1] = tetherDirection.magnitude / 2;
            player.tether.transform.localScale = tetherScale;
        }

        return null;
    }
}
