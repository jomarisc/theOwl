using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySkill : Skill
{
    EmptySkill()
    {
        type = SkillType.None;
    }
    public override bool UseSkill()
    {
        Debug.Log("Using Empty Skill");
        return false;
    }
    public override void DeactivateSkill() {}
}
