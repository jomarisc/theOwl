using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class EquippedSkills : MonoBehaviour
{
    [Header("Necessary Attachments")]
    [SerializeField] private playerControl player = null;
    public SkillWheelUI skillWheel;
    public Skill currentSkill;
    public Skill[] skills = new Skill[4];
    public static event CurrentSkillChanged OnCurrentSkillChanged;
    public delegate void CurrentSkillChanged();

    private void OnEnable()
    {
        player.input.Gameplay.UseActiveSkill.started += UseCurrentSkill;

        // switch(GlobalVars.currentSkill)
        // {
        //     case 0:
        //         currentSkill = transform.parent.GetComponentInChildren<AllSkills>().AllSkillsList[0].GetComponent<Skill>();
        //         break;
        //     case 1: 
        //         currentSkill = transform.parent.GetComponentInChildren<AllSkills>().AllSkillsList[1].GetComponent<Skill>();
        //         break;
        //     default:
        //         currentSkill = transform.parent.GetComponentInChildren<AllSkills>().AllSkillsList[2].GetComponent<Skill>();
        //         break;
        // }
        int activeSkillSlot = GlobalVars.currentSkill;
        currentSkill = skills[activeSkillSlot];

        SkillWheelUI.OnSkillEquip += UpdateCurrentSkill;

    }

    private void OnDisable()
    {
        player.input.Gameplay.UseActiveSkill.started -= UseCurrentSkill;
        SkillWheelUI.OnSkillEquip -= UpdateCurrentSkill;
    }

    public void UpdateCurrentSkill()
    {
        // Debug.Log("Updating current skill...");
        int activeSkillSlot = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<SkillWheelSlotUI>().slotNumber - 1;
        currentSkill = skills[activeSkillSlot];

        // switch(activeSkillSlot)
        // {
        //     case Shield s1:
        //         GlobalVars.currentSkill = 0;
        //         break;
        //     case Kamehameha s2:
        //         GlobalVars.currentSkill = 1;
        //         break;
        //     default:
        //         // 2 is null for now
        //         GlobalVars.currentSkill = 2;;
        //         break;
        // }

        GlobalVars.currentSkill = activeSkillSlot;

        OnCurrentSkillChanged?.Invoke();
    }

    // Use the current skill if unused and ready. Turn off current skill otherwise.
    public void UseCurrentSkill(InputAction.CallbackContext context)
    {
        if(currentSkill.isActive)
            currentSkill.DeactivateSkill();
        else
        {
            if(player.data.remainingStamana >= currentSkill.usageCost)
            {
                if(currentSkill.UseSkill())
                    player.data.remainingStamana -= currentSkill.usageCost;
            }
            else
                Debug.Log("Not enough stamana!");
        }
    }
}
