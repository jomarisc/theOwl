﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaCharge : IState
{
    private readonly Character user;
    private GameObject chargedEnergy;
    private float initialChargedEnergyScale;
    private float chargedEnergyScaleDelta;
    private MeleeAttack blast;
    private float initialChargeDuration;
    private float chargeDuration;
    
    public KamehamehaCharge(Character c, GameObject ce, MeleeAttack b, float cd)
    {
        user = c;
        chargedEnergy = ce;
        blast = b;
        initialChargeDuration = cd;
        chargeDuration = cd;
    }

    public void Enter()
    {
        chargedEnergy.SetActive(true);
        user.Attack(chargedEnergy);
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
        chargeDuration--;
        Debug.Log(chargeDuration);
    }

    public IState Update()
    {
        if(chargeDuration % (initialChargeDuration / 4) == 0)
        {
            Vector3 initialScale = chargedEnergy.transform
            .localScale.normalized * (initialChargedEnergyScale / 2);
            chargedEnergy.transform.localScale += initialScale;
        }
        if(chargeDuration > 0f)
        {
            return null;
        }
        // return new KamehamehaBlast(user);
        return new KamehamehaBlast(user, blast);
    }
}
