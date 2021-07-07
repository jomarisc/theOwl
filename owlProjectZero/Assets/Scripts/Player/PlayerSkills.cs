using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
    //private readonly playerControl player;

    // public List<Skill> unlockedSkillTypeList;

    void Awake()
    {
        // Temporary, until we turn off shield until he gets the suit.
        GlobalVars.unlockedSkills[0] = true;


    }
    

    // public PlayerSkills()
    // {
    //     unlockedSkillTypeList = new List<Skill>();
    // }

    public void UnlockSkill(Skill skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            // unlockedSkillTypeList.Add(skillType);
            switch(skillType)
            {
                case Shield s1:
                    GlobalVars.unlockedSkills[0] = true;
                    break;

                case Kamehameha s2:
                    GlobalVars.unlockedSkills[1] = true;
                    break;
                default:
                    Debug.Log("Skill not implemented yet. Sorry.");
                    break;
            }

            for(int i = 0; i < GlobalVars.unlockedSkills.Length; i++)
            {
                Debug.Log("Skill " + i + " " + GlobalVars.unlockedSkills[i]);
            }
        }
        else
        {
            Debug.Log("Skill already unlocked!");
        }
    }

    public bool IsSkillUnlocked(Skill skillType)
    {
        // return unlockedSkillTypeList.Contains(skillType);

        switch(skillType)
            {
                case Shield s1:
                    return true;
                    break;

                case Kamehameha s2:
                    return true;
                    break;
                default:
                    Debug.Log("Skill hasn't been unlocked yet. Boo you.");
                    break;
            }

    }
    
}
