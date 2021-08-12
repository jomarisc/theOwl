using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollectable : Collectable
{
    // private GameObject player;
    private PlayerSkills unlockedSkills;
    private EquippedSkills equippedSkills;
    // [SerializeField] private Skill skillToUnlock;
    [SerializeField] private GameObject skillToUnlock = null;

    protected override void Start()
    {
        base.Start();
        unlockedSkills = player.GetComponentInChildren<PlayerSkills>();
        equippedSkills = player.GetComponentInChildren<EquippedSkills>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        // Add the skill to the player's list of unlocked skills
        if(unlockedSkills == null)
            unlockedSkills = player.GetComponentInChildren<PlayerSkills>();
        unlockedSkills.UnlockSkill(skillToUnlock.GetComponent<Skill>());

        unlockedSkills.ReplaceEquippedSkill(skillToUnlock);

        Destroy(this.gameObject);
    }
}
