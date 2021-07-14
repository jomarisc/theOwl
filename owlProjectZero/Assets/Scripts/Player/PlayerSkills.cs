using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
    //private readonly playerControl player;
    private EquippedSkills equippedSkills;

    // public List<Skill> unlockedSkillTypeList;

    void Start()
    {
        // Temporary, until we turn off shield until he gets the suit.
        GlobalVars.unlockedSkills[0] = true;
        playerControl player = GetComponentInParent<playerControl>();
        equippedSkills = player.GetComponentInChildren<EquippedSkills>();

        // for(int i = 0; i < GlobalVars.unlockedSkills.Length; i++)
        // {
        //     if(GlobalVars.unlockedSkills[i] == true)
        //     {
        //         ReplaceEquippedSkill(GetComponent<AllSkills>().AllSkillsList[i]);
        //     }
        // }

        if(GlobalVars.unlockedSkills[1] == true)
        {
            ReplaceEquippedSkill(GetComponent<AllSkills>().AllSkillsList[1]);
        }

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
                return GlobalVars.unlockedSkills[0];

            case Kamehameha s2:
                return GlobalVars.unlockedSkills[1];
            default:
                Debug.Log("Skill hasn't been unlocked yet. Boo you.");
                return false;
        }

    }

    public void ReplaceEquippedSkill(GameObject skillType)
    {
        GameObject newUnlock = Instantiate(skillType, gameObject.transform);
        newUnlock.SetActive(false);

        // If the player hasn't unlocked 4 skills yet
        if(GlobalVars.unlockedSkills.Length < 4)
        {
            for(int i = 0; i < equippedSkills.skills.Length; i++)
            {
                if(equippedSkills.skills[i] is EmptySkill)
                {
                    // Replace the EmptySkill prefab with the new skill
                    Skill[] slots = equippedSkills.gameObject.GetComponentsInChildren<Skill>();
                    Destroy(slots[i].gameObject);
                    GameObject newSkill = Instantiate(skillType, equippedSkills.transform);

                    // Add the skill to the first empty skill slot
                    equippedSkills.skills[i] = newSkill.GetComponent<Skill>();
                    break;
                }
            }
        }
    }
    
}
