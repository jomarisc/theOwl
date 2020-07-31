using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGlide : IState
{
    private readonly playerControl player;
    private PlayerInputs.GlidingActions glideInput;
    private const float newGravity = -2.0f;
    private float horizontalMovement = 0f;
    private glideType method = 0;
    public enum glideType {Jump, Down}

    public PlayerGlide(playerControl p, glideType glideMethod)
    {
        player = p;
        glideInput = p.input.Gliding;
        method = glideMethod;
    }
    public void Enter()
    {
        // use glide animation here:

        player.GetComponent<Rigidbody>().useGravity = false;

        // Halt vertical movement
        float xMovement = glideInput.Fly.ReadValue<float>();
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
        // Check input for tether
        if(player.activeTetherPoint != null &&
        //    Input.GetKeyDown(KeyCode.T) &&
           glideInput.Tether.phase == InputActionPhase.Started &&
           player.transform.position.y <= player.activeTetherPoint.transform.position.y)
        {
            return new PlayerTether(player);
        }

        // Check input for changing skills




        // Check input for dodging
        // if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
        if(glideInput.Dodge.triggered && player.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        // if(Input.GetButtonDown("Jump"))
        if(glideInput.Jump.triggered)
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        // if(Input.GetButtonDown("Fire1"))
        if(glideInput.Melee.triggered)
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        // if(Input.GetButtonDown("Fire2"))
        if(glideInput.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }

        // Check input for exiting glide state while airborne
        if(method == glideType.Jump)
        {
            // if(Input.GetButtonUp("Jump"))
            if(glideInput.Jump.phase == InputActionPhase.Canceled)
            {
                return new PlayerWalk(player, true);
            }
        }
        else
        {
            // if(Input.GetKeyUp(KeyCode.DownArrow) ||
            //    Input.GetKeyUp(KeyCode.S))
            if(glideInput.Glide.phase == InputActionPhase.Canceled)
            {
                return new PlayerWalk(player, true);
            }
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
        horizontalMovement = glideInput.Fly.ReadValue<float>();
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        return null;
    }
}
