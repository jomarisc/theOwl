using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is in charge of updating the active skill UI when necessary
[RequireComponent(typeof(Image))]
public class ActiveSkillUI : MonoBehaviour
{
    [SerializeField] private PlayerSkills equippedSkills;
    private Image currentSkillIcon;
    void Awake()
    {
        currentSkillIcon = gameObject.GetComponent<Image>();
    }
    void OnEnable()
    {
        playerControl.OnSkillEquip += SetSkillIcon;
    }
    void OnDisable()
    {
        playerControl.OnSkillEquip -= SetSkillIcon;
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
