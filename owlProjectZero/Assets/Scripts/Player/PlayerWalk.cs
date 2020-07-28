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

    // Maybe add another argument in constructor that determines
    // whether the player is grounded or not bc I'm considering having this
    // state govern strictly horizontal movement; grounded or otherwise
    public PlayerWalk(playerControl p)
    {
        player = p;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
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
        player.MoveCharacter(horizontalMovement, verticalMovement);
    }

    public IState Update()
    {
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

        horizontalMovement = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalMovement) > 0)
        {
            player.isFacingRight = (horizontalMovement < 0) ? false : true;
        }
        
        if(Input.GetAxis("Vertical") < 0 &&
           player.maxSpeed == player.airSpeed &&
           playerBody.velocity.y < 0 &&
           playerBody.velocity.y > -2f &&
           playerBody.velocity.y != fastFallSpeed)
        {
            Debug.Log("Fastfalling?");
            verticalMovement = fastFallSpeed;
        }
        else
        {
            verticalMovement = playerBody.velocity.y;
        }
        return null;
    }
}
