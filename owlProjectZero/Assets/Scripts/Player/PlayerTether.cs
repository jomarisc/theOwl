using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Idle State
public class PlayerTether : IState
{
    private readonly playerControl player;
    private Vector3 tetherDirection;
    private float tetherLength;
    private float angle;

    public PlayerTether(playerControl p)
    {
        player = p;
        tetherDirection = p.activeTetherPoint.transform.position - p.GetComponent<Rigidbody>().position;
        tetherLength = tetherDirection.magnitude;
        angle = Vector3.Angle(-tetherDirection, Vector3.down) * Mathf.Deg2Rad;
    }
    public void Enter()
    {
        // Enter tetherDirection animation code here:
        // player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().drag = 0f;
    }

    public void Exit()
    {
        // Nothing so far
        // player.GetComponent<Rigidbody>().useGravity = true;
    }

    public void FixedUpdate()
    {
        if(player.activeTetherPoint != null)
        {
            tetherDirection = player.activeTetherPoint.transform.position - player.GetComponent<Rigidbody>().position;
            angle = Vector3.Angle(-tetherDirection, Vector3.down) * Mathf.Deg2Rad;
            // Debug.Log(angle);
            player.TetherSwing(tetherLength, tetherDirection, angle);
        }
    }

    public IState Update()
    {
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
            return new PlayerMelee(player, 0f);
        }

        // Check input for shooting with a projectile
        if(Input.GetButtonDown("Fire2"))
        {
            return new PlayerShoot(player);
        }

        if(player.activeTetherPoint == null ||
           Input.GetKeyDown(KeyCode.T) ||
           player.transform.position.y > player.activeTetherPoint.transform.position.y)
        {
            return new PlayerGlide(player);
        }

        return null;
    }
}
