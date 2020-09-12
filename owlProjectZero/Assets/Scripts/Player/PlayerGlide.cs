using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGlide : IState
{
    private readonly playerControl player;
    private PlayerInputs input;
    // private const float newGravity = -2.0f;
    private float horizontalMovement = 0f;
    private glideType method = 0;
    public enum glideType {Jump, Down}

    //Get references to both animator and sprite renderer. -Joel
    private Animator animator;
    private SpriteRenderer spriterenderer;

    public PlayerGlide(playerControl p, glideType glideMethod)
    {
        player = p;
        input = p.input;
        method = glideMethod;

        //Assign those references. -Joel

        animator = p.gameObject.GetComponent<Animator>();
        spriterenderer = p.gameObject.GetComponent<SpriteRenderer>();
    }
    public void Enter()
    {
        // use glide animation here:

        player.GetComponent<Rigidbody>().useGravity = false;

        // Halt vertical movement
        float xMovement = input.Gameplay.MoveX.ReadValue<float>();
        player.GetComponent<Rigidbody>().velocity = new Vector3(xMovement, 0f, 0f);
        animator.SetBool("gliding", true);
    }

    public void Exit()
    {
        // Reset gravity
        player.GetComponent<Rigidbody>().useGravity = true;
        animator.SetBool("gliding", false);
    }

    public void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, player.GLIDE_GRAVITY, 0f));
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
        //Check for direction of movement to flip sprite. - Joel
        if (horizontalMovement > 0) { spriterenderer.flipX = false; }
        else if (horizontalMovement < 0) { spriterenderer.flipX = true; }
        else { }

        // Check input for changing skills



        // Check input for exiting glide state while airborne
        if(method == glideType.Jump)
        {
            // if(Input.GetButtonUp("Jump"))
            if(input.Gameplay.Jump.ReadValue<float>() == 0f)
            {
                return new PlayerWalk(player, true);
            }
        }
        else
        {
            if(input.Gameplay.Glide.ReadValue<float>() == 0f)
            {
                return new PlayerWalk(player, true);
            }
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
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        if(input.Gameplay.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }

        // If jumps get refreshed, i.e. landing on a platform
        if(player.data.maxSpeed == player.data.groundSpeed &&
           player.data.numJumps == player.CONSTANTS.MAX_JUMPS)
        {
            return new PlayerIdle(player);
        }

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //  This Chunk of code is also in PlayerWalk                       //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////
        // horizontalMovement = Input.GetAxis("Horizontal");
        horizontalMovement = input.Gameplay.MoveX.ReadValue<float>();
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            // player.data.isFacingRight = (horizontalMovement < 0) ? false : true;
            player.data.isFacingRight = !spriterenderer.flipX;
        }
        return null;
    }
}
