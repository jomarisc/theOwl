using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGlide : IState
{
    private readonly playerControl player;
    private PlayerInputs input;
    private const float newGravity = -2.0f;
    private float horizontalMovement = 0f;
    private glideType method = 0;
    public enum glideType {Jump, Down}

    public PlayerGlide(playerControl p, glideType glideMethod)
    {
        player = p;
        input = p.input;
        method = glideMethod;
    }
    public void Enter()
    {
        // use glide animation here:

        player.GetComponent<Rigidbody>().useGravity = false;

        // Halt vertical movement
        float xMovement = input.Gameplay.MoveX.ReadValue<float>();
        player.GetComponent<Rigidbody>().velocity = new Vector3(xMovement, 0f, 0f);
    }

    public void Exit()
    {
        // Reset gravity
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    public void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, newGravity, 0f));
        player.MoveCharacter(horizontalMovement);
    }

    public IState Update()
    {
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
        if(input.Gameplay.Dodge.triggered && player.numDodges > 0)
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
        if(player.maxSpeed == player.groundSpeed &&
           player.numJumps == playerControl.MAX_JUMPS)
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
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        return null;
    }
}
