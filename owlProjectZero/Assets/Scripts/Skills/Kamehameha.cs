using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : Skill
{
    [Header("Necessary Attachments")]
    [SerializeField] private Character user = null;
    [SerializeField] private GameObject beamCharge = null;
    [SerializeField] private Attack beamAttack = null;
    [SerializeField] private SpriteRenderer beamRootSprite = null;
    [Header("Level Designer Variables")]
    [Tooltip("The number of frames it takes to charge a Kamehameha")]
    [SerializeField] private float chargeDuration = 0f;
    [Tooltip("The rate at which the beam grows in length")]
    [Min(0f)]
    [SerializeField] private float growthRate = 0.1f;

    Kamehameha()
    {
        type = SkillType.Offensive;
    }

    protected override void Start()
    {
        base.Start();
        user = GetComponentInParent<Character>();
    }

    public override bool UseSkill()
    { 
        if(cooldown >= maxCooldown)
        {
            IState kamehamehaCharge = new KamehamehaCharge(user, beamCharge, beamAttack, beamRootSprite, chargeDuration, growthRate);
            user.GoToState(kamehamehaCharge);
            isActive = true;
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
        if(isActive)
        {
            // Play Kamehameha cancelled animation?
            isActive = false;
            cooldown = 0f;
            user.GoToState(user.defaultState);
        }
    }
}
