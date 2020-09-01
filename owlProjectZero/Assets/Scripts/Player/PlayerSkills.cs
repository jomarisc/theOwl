using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
    
    //private readonly playerControl player;

    public enum SkillType
    {
        Shield,
    }

    public List<SkillType> unlockedSkillTypeList;
    
    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
        }
        else
        {
            Debug.Log("Skill already unlocked!");
        }
    }

    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }
    
}
