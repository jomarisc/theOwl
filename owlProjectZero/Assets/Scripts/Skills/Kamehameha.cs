using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : Skill
{
    [Header("Necessary Attachments")]
    [SerializeField] private Character user;
    [SerializeField] private GameObject beamCharge;
    [SerializeField] private MeleeAttack beamAttack;
    [Tooltip("The number of frames it takes to charge a Kamehameha")]
    [SerializeField] private float chargeDuration;

    public override bool UseSkill()
    {
        if(cooldown >= maxCooldown)
        {
            IState kamehamehaCharge = new KamehamehaCharge(user, beamCharge, beamAttack, chargeDuration);
            user.GoToState(kamehamehaCharge);
        }
        else
        {
            isActive = false;
            Debug.Log("Kamehameha is still in cooldown!");
        }

        return isActive;
    }

    public override void DeactivateSkill()
    {
        
    }
}
