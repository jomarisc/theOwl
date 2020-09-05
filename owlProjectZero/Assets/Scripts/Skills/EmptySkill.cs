using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySkill : Skill
{
    EmptySkill()
    {
        type = SkillType.None;
    }
    public override void UseSkill() {}
    public override void DeactivateSkill() {}
}
