using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    private Vector3 lookingDirection;
    [SerializeField]
    private float eyePrescription = 0f;
    public LayerMask targetLayer;
    public Enemy(int maxJumps, int maxDodges, float dodgeDuration) : base(maxJumps, maxDodges, dodgeDuration)
    {
        lookingDirection = Vector3.zero;
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }

    new protected void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool SeesPlayer()
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        Debug.DrawRay(rb.position, rb.position + lookingDirection * eyePrescription, Color.white);
        return Physics.Raycast(rb.position, lookingDirection, eyePrescription, targetLayer);
    }

    public bool PlayerInAttackRange()
    {
        lookingDirection.x = (data.isFacingRight) ? 1f : -1f;
        Debug.DrawRay(rb.position, rb.position + lookingDirection * Mathf.Abs(meleeAttack.transform.localPosition.x), Color.red);
        return Physics.Raycast(rb.position, lookingDirection, Mathf.Abs(meleeAttack.transform.localPosition.x), targetLayer);
    }
}
