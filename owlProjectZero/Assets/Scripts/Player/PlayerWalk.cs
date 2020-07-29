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
    private bool isFastFalling = false;

    // Maybe add another argument in constructor that determines
    // whether the player is grounded or not bc I'm considering having this
    // state govern strictly horizontal movement; grounded or otherwise
    public PlayerWalk(playerControl p)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        verticalMovement = playerBody.velocity.y;
    }
    public void Enter()
    {
        if(player.maxSpeed == player.groundSpeed)
        {
            // Use walking animation here
        }
        else
        {
            // use descending animation here:
        }
    }

    public void Exit()
    {
        // Nothing so far
    }

    public void FixedUpdate()
    {
        verticalMovement = (isFastFalling) ? fastFallSpeed : playerBody.velocity.y;
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
        
        if(player.maxSpeed == player.airSpeed &&
           (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            if(playerBody.velocity.y < 0 &&
               playerBody.velocity.y > -2f &&
               !isFastFalling)
            {
                Debug.Log("Fastfalling?");
                isFastFalling = true;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.S))
            {
                return new PlayerGlide(player, PlayerGlide.glideType.Down);
            }
        }
        
        horizontalMovement = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }

        return null;
    }
}
