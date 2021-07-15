using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaCharge : IState
{
    private readonly Character user;
    private GameObject chargedEnergy;
    private float initialChargedEnergyScale;
    private float chargedEnergyScaleDelta;
    private Attack beam;
    private SpriteRenderer beamRootSprite;
    private float initialChargeDuration;
    private float chargeDuration;
    private float growthRate;
    
    public KamehamehaCharge(Character c, GameObject ce, Attack b, SpriteRenderer br, float cd, float gr)
    {
        user = c;
        chargedEnergy = ce;
        beam = b;
        beamRootSprite = br;
        initialChargeDuration = cd;
        chargeDuration = cd;
        growthRate = gr;
    }

    public void Enter()
    {
        int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        user.animator.Play("KamehamehaCharge", animationLayer);
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
        if(chargeDuration % (initialChargeDuration / 4) == 0)
        {
            Vector3 initialScale = chargedEnergy.transform
            .localScale.normalized * (initialChargedEnergyScale * 2 / 3);
            chargedEnergy.transform.localScale += initialScale;
        }
        Debug.Log(chargeDuration);
    }

    public IState Update()
    {
        if(chargeDuration > 0f)
        {
            return null;
        }
        // return new KamehamehaBlast(user);
        return new KamehamehaBlast(user, beam, beamRootSprite, growthRate);
    }
}
