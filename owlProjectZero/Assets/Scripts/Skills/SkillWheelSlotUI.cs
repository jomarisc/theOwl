using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// This class is in charge of updating the skill wheel UI when necessary
[RequireComponent(typeof(Image))]
public class SkillWheelSlotUI : MonoBehaviour
{
    [SerializeField] private EquippedSkills equippedSkills = null;
    private Image myIcon;
    public int slotNumber;
    public static event SkillEquip OnSkillEquip;
    public delegate void SkillEquip();

    void Awake()
    {
        myIcon = gameObject.GetComponent<Image>();
    }
    
    void OnEnable()
    {
        myIcon.sprite = equippedSkills.skills[slotNumber - 1].GetIcon();
    }

    public void EquipSkill()
    {
        equippedSkills.currentSkill = equippedSkills.skills[slotNumber - 1];
        OnSkillEquip?.Invoke();
    }
}
