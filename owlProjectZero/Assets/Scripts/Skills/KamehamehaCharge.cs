using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaCharge : IState
{
    private readonly Character user;
    private GameObject chargedEnergy;
    private float initialChargedEnergyScale;
    private float chargedEnergyScaleDelta;
    private MeleeAttack blast;
    private float chargeDuration;
    
    public KamehamehaCharge(Character c, GameObject ce, MeleeAttack b, float cd)
    {
        user = c;
        chargedEnergy = ce;
        blast = b;
        chargeDuration = cd;
    }

    public void Enter()
    {
        chargedEnergy.SetActive(true);
        // chargedEnergy.transform.localScale *= chargedEnergyScale;
        initialChargedEnergyScale = chargedEnergy.transform.localScale.magnitude;
    }

    public void Exit()
    {
        Vector3 localScale = chargedEnergy.transform.localScale;
        chargedEnergy.transform.localScale = localScale.normalized * initialChargedEnergyScale;
        chargedEnergy.SetActive(false);
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        if(chargeDuration >= 0f)
        {
            chargeDuration -= Time.fixedDeltaTime;
            return null;
        }
        // return new KamehamehaBlast(user);
        return new KamehamehaBlast(user, blast);
    }
}
