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
        SkillWheelUI.OnSkillEquip += UpdateCurrentSkill;
    }

    private void OnDisable()
    {
        player.input.Gameplay.UseActiveSkill.started -= UseCurrentSkill;
        SkillWheelUI.OnSkillEquip -= UpdateCurrentSkill;
    }

    private void UpdateCurrentSkill()
    {
        Debug.Log("Updating current skill...");
        currentSkill = skills[EventSystem.current.currentSelectedGameObject.GetComponentInChildren<SkillWheelSlotUI>().slotNumber - 1];
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
                player.data.remainingStamana -= currentSkill.usageCost;
                currentSkill.UseSkill();
            }
            else
                Debug.Log("Not enough stamana!");
        }
    }
}
