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

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
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

        if (Input.GetButtonDown("Fire3"))
        {
            Dodge();
        }

        if (Input.GetButtonUp("Fire3"))
        {
            Physics.IgnoreLayerCollision(9, 10, false); // Player x Enemies
            Physics.IgnoreLayerCollision(9, 12, false); // Player x Enemies' Attacks
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
