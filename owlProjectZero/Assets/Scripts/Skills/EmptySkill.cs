using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySkill : Skill
{
    EmptySkill()
    {
        type = SkillType.None;
    }
    // Start is called before the first frame update
    new private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
    }

    public override void UseSkill()
    {

    }

    public override void DeactivateSkill()
    {
        
    }
}
