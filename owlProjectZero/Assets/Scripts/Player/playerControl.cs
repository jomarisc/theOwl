using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class playerControl : Character
{
    SphereCollider sphereCollider;

    [SerializeField]
    private GameObject projectile = null;
    private float acceleration;
    private float xSpeed;
    public const int MAX_JUMPS = 3;
    public const float DODGE_DURATION = 1.5f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        dodgeDuration = -1f;
    }

    // Update is called once per frame
    private void Update()
    {
        acceleration = Input.GetAxis("Horizontal");
        if(Mathf.Abs(acceleration) > 0)
        {
            isFacingRight = (acceleration < 0) ? false : true;
        }
        
        if (Input.GetButtonDown("Jump") && numJumps > 0)
        {
            Jump();
            numJumps--;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            meleeAttack.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            SpawnProjectile();
        }

        if (Input.GetButtonDown("Fire3") && dodgeDuration < 0f)
        {
            // Dodge();
            var myRenderer = GetComponent<Renderer>();
            myRenderer.material.SetColor("_Color", Color.black);
            dodgeDuration = DODGE_DURATION;
        }

        // if (Input.GetButtonUp("Fire3"))
        // {
        //     Physics.IgnoreLayerCollision(9, 10, false); // Player x Enemies
        //     Physics.IgnoreLayerCollision(9, 12, false); // Player x Enemies' Attacks
        // }

        // -1 <= dodgeDuration <= DODGE_DURATION
        // Decrement dodgeDuration until it reaches below 0
        if(dodgeDuration >= 0f)
        {
            dodgeDuration -= Time.deltaTime;
            Debug.Log("dodge duration: " + dodgeDuration);
        }
    }

    private void FixedUpdate()
    {
        xSpeed = rb.velocity.x;
        MoveCharacter(acceleration);
        if(meleeAttack.activeSelf)
        {
            Attack();
        }
        // Only dodge if the dodge duration is >= -1
        if(dodgeDuration >= -1f)
        {
            Dodge();
        }
    }

    public void SpawnProjectile()
    {
        projectile.gameObject.SetActive(true);
        ProjectileAttack projAtk = projectile.GetComponent<ProjectileAttack>();
        Rigidbody projBody = projectile.GetComponent<Rigidbody>();
        Vector3 spawnOffset = (isFacingRight) ? new Vector3(0.5f, 0f, 0f) : new Vector3(-0.5f, 0f, 0f);
        projBody.position = transform.position + spawnOffset;
        projAtk.speed = (isFacingRight) ? ProjectileAttack.INITIAL_SPEED : -ProjectileAttack.INITIAL_SPEED;
    }
}
