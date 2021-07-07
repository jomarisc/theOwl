using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
    //private readonly playerControl player;

    public List<Skill> unlockedSkillTypeList;

    void Awake()
    {

    }
    
    void Update()
    {
        // for(int i = 0; i < unlockedSkillTypeList.Count; i++){
        //     Debug.Log(unlockedSkillTypeList[i]);
        // }
    }

    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<Skill>();
    }

    public void UnlockSkill(Skill skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
            GlobalVars.unlockedSkills.Add(skillType);
            for(int i = 0; i < GlobalVars.unlockedSkills.Count; i++){
            Debug.Log(GlobalVars.unlockedSkills[i]);
        }
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
