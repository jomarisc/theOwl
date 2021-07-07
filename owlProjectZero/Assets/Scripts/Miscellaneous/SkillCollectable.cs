﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollectable : Collectable
{
    private PlayerSkills unlockedSkills;
    private EquippedSkills equippedSkills;
    // [SerializeField] private Skill skillToUnlock;
    [SerializeField] private GameObject skillToUnlock = null;

    void Awake()
    {
        GameObject player = GameObject.Find("player");
        unlockedSkills = player.GetComponentInChildren<PlayerSkills>();
        equippedSkills = player.GetComponentInChildren<EquippedSkills>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        // Add the skill to the player's list of unlocked skills
        unlockedSkills.UnlockSkill(skillToUnlock.GetComponent<Skill>());

        replaceEquippedSkill(skillToUnlock.GetComponent<Skill>());

        Destroy(this.gameObject);
    }

    public static void replaceEquippedSkill(Skill skillType)
    {
        GameObject newUnlock = Instantiate(skillType, unlockedSkills.transform);
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
