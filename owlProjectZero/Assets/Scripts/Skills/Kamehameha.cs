using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : Skill
{
    [Header("Necessary Attachments")]
    [SerializeField] private Character user = null;
    [SerializeField] private GameObject beamCharge = null;
    [SerializeField] private Attack beamAttack = null;
    [Header("Level Designer Variables")]
    [Tooltip("The number of frames it takes to charge a Kamehameha")]
    [SerializeField] private float chargeDuration = 0f;

    Kamehameha()
    {
        type = SkillType.Offensive;
    }

    public override bool UseSkill()
    {
        if(cooldown >= maxCooldown)
        {
            IState kamehamehaCharge = new KamehamehaCharge(user, beamCharge, beamAttack, chargeDuration);
            user.GoToState(kamehamehaCharge);
            // isActive = true;
            return true;
        }
        // else
        // {
            // isActive = false;
        Debug.Log("Kamehameha is still in cooldown!");
        return false;
        // }

        // return isActive;
    }

    public override void DeactivateSkill()
    {
        // Play Kamehameha cancelled animation?
        isActive = false;
        cooldown = 0f;
    }
}
