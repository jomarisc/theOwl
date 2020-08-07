using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : IState
{
    private readonly playerControl player;
    private Rigidbody playerBody;
    private const float fastFallSpeed = -10f;
    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;
    private bool isFlying = false;
    private bool isFastFalling = false;
    // Maybe add another argument in constructor that determines
    // whether the player is grounded or not bc I'm considering having this
    // state govern strictly horizontal movement; grounded or otherwise
    public PlayerWalk(playerControl p, bool isAirborne)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        isFlying = isAirborne;
        verticalMovement = (isAirborne) ? playerBody.velocity.y : 0f;
    }
    public void Enter()
    {
        if(isFlying)
        {
            // use descending animation here:
        }
        else
        {
            // Use walking animation here
        }
    }

    public void Exit()
    {
        // Nothing so far
    }

    public void FixedUpdate()
    {

        verticalMovement = (isFlying && isFastFalling) ? fastFallSpeed : playerBody.velocity.y;
        player.MoveCharacter(horizontalMovement, verticalMovement);
    }

    public IState Update()
    {
        if(player.maxSpeed == player.airSpeed &&
           player.activeTetherPoint != null &&
           Input.GetKeyDown(KeyCode.T) &&
           player.transform.position.y <= player.activeTetherPoint.transform.position.y)
        {
            return new PlayerTether(player);
        }

        // Check input for changing skills




        // Check input for dodging
        if(Input.GetButtonDown("Fire3") && player.numDodges > 0)
        {
            return new PlayerDodge(player);
        }

        // Check input for jumping
        if(Input.GetButtonDown("Jump"))
        {
            return new PlayerJump(player);
        }

        // Check input for melee attacking
        if(Input.GetButtonDown("Fire1"))
        {
            // meleeAttack.gameObject.SetActive(true);
            return new PlayerMelee(player, horizontalMovement);
        }

        // Check input for shooting with a projectile
        if(Input.GetButtonDown("Fire2"))
        {
            return new PlayerShoot(player);
        }
        
        // When player is airborne and down key is pressed
        if(isFlying &&
           (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            // If pressed during the fastfall window
            if(Mathf.Abs(playerBody.velocity.y) < 5f &&
               !isFastFalling)
            {
                Debug.Log("Fastfalling?");
                isFastFalling = true;
            }
            // if down was pressed on this frame
            else if(Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.S))
            {
                return new PlayerGlide(player, PlayerGlide.glideType.Down);
            }
        }

        // If landing on a platform
        if(isFlying &&
           player.maxSpeed == player.groundSpeed)
        {
            Debug.Log("Landing");
            return new PlayerWalk(player, false);
        }

        // If leaving a platform
        if(!isFlying &&
           player.maxSpeed == player.airSpeed)
        {
            Debug.Log("Left platform");
            return new PlayerWalk(player, true);
        }

        horizontalMovement = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }

        return null;
    }
}
