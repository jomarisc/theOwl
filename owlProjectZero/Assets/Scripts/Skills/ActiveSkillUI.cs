using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is in charge of updating the active skill UI when necessary
[RequireComponent(typeof(Image))]
public class ActiveSkillUI : MonoBehaviour
{
    [SerializeField] private EquippedSkills equippedSkills = null;
    private Image currentSkillIcon;
    void Awake()
    {
        currentSkillIcon = gameObject.GetComponent<Image>();
    }
    void OnEnable()
    {
        // SkillWheelUI.OnSkillEquip += SetSkillIcon;
        EquippedSkills.OnCurrentSkillChanged += SetSkillIcon;
        SkillWheelSlotUI.OnSkillEquip += SetSkillIcon;
    }
    void OnDisable()
    {
        // SkillWheelUI.OnSkillEquip -= SetSkillIcon;
        EquippedSkills.OnCurrentSkillChanged -= SetSkillIcon;
        SkillWheelSlotUI.OnSkillEquip -= SetSkillIcon;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSkillIcon.sprite = equippedSkills.currentSkill.GetIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSkillIcon()
    {
        currentSkillIcon.sprite = equippedSkills.currentSkill.GetIcon();
    }
}
