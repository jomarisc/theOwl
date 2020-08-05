using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Tether State
public class PlayerTether : IState
{
    private readonly playerControl player;
    private Rigidbody playerRB;
    private Vector3 tetherDirection;
    private float tetherLength;
    private float angle;

    public PlayerTether(playerControl p)
    {
        player = p;
        playerRB = p.GetComponent<Rigidbody>();
        tetherDirection = p.activeTetherPoint.transform.position - playerRB.position;
        tetherLength = tetherDirection.magnitude;
        angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
    }
    public void Enter()
    {
        // Enter tetherDirection animation code here:


        // player.GetComponent<Rigidbody>().useGravity = false;
        player.tether.SetActive(true);
        playerRB.velocity = Vector3.zero;
        playerRB.drag = 0f;
    }

    public void Exit()
    {
        // playerRB.useGravity = true;
        player.tether.SetActive(false);
    }

    public void FixedUpdate()
    {
        if(player.activeTetherPoint != null)
        {
            tetherDirection = player.activeTetherPoint.transform.position - playerRB.position;
            angle = Vector3.SignedAngle(tetherDirection, Vector3.up, Vector3.forward) * Mathf.Deg2Rad;
            // Debug.Log(angle);
            player.TetherSwing(tetherLength, tetherDirection, angle);
        }
    }

    public IState Update()
    {
        // Check input for dodging
        if(Input.GetButtonDown("Fire3") && player.data.numDodges > 0)
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

        // Check for glide input
        if(Input.GetAxis("Vertical") < 0)
        {
            return new PlayerGlide(player, PlayerGlide.glideType.Down);
        }

        if(player.activeTetherPoint == null ||
           Input.GetKeyDown(KeyCode.T) ||
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
