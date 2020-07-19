using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Idle State
public class PlayerTether : IState
{
    private readonly playerControl player;
    private Vector3 tether;
    private float angle;

    public PlayerTether(playerControl p)
    {
        player = p;
        tether = p.activeTetherPoint.transform.position - p.GetComponent<Rigidbody>().position;
        angle = Vector3.Angle(-tether, Vector3.down) * Mathf.Deg2Rad;
    }
    public void Enter()
    {
        // Enter tether animation code here:
        // player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().drag = 0f;
        Debug.Log(angle);
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
            tether = player.activeTetherPoint.transform.position - player.GetComponent<Rigidbody>().position;
            angle = Vector3.Angle(Physics.gravity, tether) * Mathf.Deg2Rad;
            player.TetherSwing(tether, angle);
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

        if(player.activeTetherPoint == null || Input.GetKeyDown(KeyCode.T))
        {
            return new PlayerGlide(player);
        }

        return null;
    }
}
