using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySkill : Skill
{
    EmptySkill()
    {
        type = SkillType.None;
    }
    public override bool UseSkill() { return false; }
    public override void DeactivateSkill() {}
}
