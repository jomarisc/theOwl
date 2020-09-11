﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// This class is in charge of updating the skill wheel UI when necessary
[RequireComponent(typeof(Image))]
public class SkillWheelSlotUI : MonoBehaviour
{
    [SerializeField] private PlayerSkills equippedSkills;
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
        myIcon.sprite = equippedSkills.unlockedSkillTypeList[slotNumber - 1].GetIcon();
    }

    public void EquipSkill()
    {
        Debug.Log($"Slot {slotNumber} equipped");
        equippedSkills.currentSkill = equippedSkills.unlockedSkillTypeList[slotNumber - 1];
        OnSkillEquip?.Invoke();
    }
}
