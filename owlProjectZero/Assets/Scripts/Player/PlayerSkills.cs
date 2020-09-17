using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
    //private readonly playerControl player;

    public List<Skill> unlockedSkillTypeList;
    
    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<Skill>();
    }

    public void UnlockSkill(Skill skillType)
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

    public bool IsSkillUnlocked(Skill skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }
    
}
