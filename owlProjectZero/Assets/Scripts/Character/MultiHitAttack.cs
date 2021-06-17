using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiHitAttack : Hitbox
{
    private int numHits = 0;
    private float rehitTimer;
    [Header("Level Designer Variables")]
    [Tooltip("Rate (in frames) by which the hitbox redamages things")]
    [SerializeField] private int rehitRate = 0; // Should remain constant and untouched in code
    // MultiHitAttack(float dmg, int start, int active, int lag, float gkb, float gAngle, float akb, float aAngle) : base(dmg, start, active, lag, gkb, gAngle, akb, aAngle)
    // {}

    protected override void OnEnable()
    {
        base.OnEnable();

        numHits = 0;
        rehitTimer = (float)rehitRate * Time.fixedDeltaTime;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(activeDuration > 0f)
            rehitTimer -= Time.fixedDeltaTime;
    }

    private void OnTriggerStay(Collider col)
    {
        // Debug.Log("OnTriggerStay");
        // // rehitTimer -= Time.fixedDeltaTime;
        // rehitTimer--;
        // Debug.Log(rehitTimer);
        // if(rehitTimer % rehitRate == 0f)
        // {
        //     // OnTriggerEnter(col);
        // rehitTimer -= Time.fixedDeltaTime;
        // float timerFloor = Mathf.Floor(rehitTimer);
        // Debug.Log(rehitTimer);
        if((int)rehitTimer % 60 == 0)
        {
            numHits++;
            Debug.Log(numHits);
            ApplyHitboxInteraction(col);
        }
            // rehitTimer = rehitRate;
        // }
    }
}
