using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiHitHitbox : Hitbox
{
    private int numHits = 0;
    private int rehitTimer;
    [Header("Level Designer Variables")]
    [Tooltip("Rate (in frames) by which the hitbox redamages things")]
    [SerializeField] private int rehitRate = 0; // Should remain constant and untouched in code
    // MultiHitAttack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle) : base(dmg, start, active, lag, gkb, gAngle, akb, aAngle)
    // {}

    protected override void OnEnable()
    {
        base.OnEnable();

        numHits = 0;
        rehitTimer = rehitRate;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(activeDuration > 0f)
            rehitTimer -= 1;
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log("Rehit Timer: " + rehitTimer + "\nRehit Rate: " + rehitRate);
        if(rehitTimer % rehitRate == 0)
        {
            numHits++;
            Debug.Log(numHits);
            ApplyHitboxInteraction(col);
        }
    }
}
