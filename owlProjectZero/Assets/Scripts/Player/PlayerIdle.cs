using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Idle State
public class PlayerIdle : IState
{
    private readonly playerControl player;
    private PlayerInputs.IdleActions idleInput;
    private float waitTime = 30f; // Time until the "no input" animation kicks in

    public PlayerIdle(playerControl p)
    {
        player = p;
        idleInput = p.input.Idle;
    }
    public void Enter()
    {
        // Enter idle animation code here:

        // idleInput.Enable();
        Debug.Log(player.input.Moving.enabled);
    }

    public void Exit()
    {
        // idleInput.Disable();
    }

    public void FixedUpdate()
    {
        // Constantly stay in place
        player.MoveCharacter(0f);
    }

    public IState Update()
    {
        // Debug.Log(idleInput.Walk.ReadValue<float>());
        
        // Check input for horizontal movement
        if(idleInput.Walk.ReadValue<float>() != 0f)
        {
            return new PlayerWalk(player, false);
        }

        // Check input for changing skills




        // Check input for dodging
        // if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
        if(idleInput.Dodge.triggered && player.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        // if(Input.GetButtonDown("Jump"))
        if(idleInput.Jump.triggered)
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        // if(Input.GetButtonDown("Fire1"))
        if(idleInput.Melee.triggered)
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player, 0f);
        }

        // Check input for shooting with a projectile
        // if(Input.GetButtonDown("Fire2"))
        if(idleInput.ShootProjectile.triggered)
        {
            return new PlayerShoot(player);
        }

        // Check idle for a while
        if(waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            // Begin "no input" animation
        }
        return null;
    }
}
