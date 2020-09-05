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
    // Start is called before the first frame update
    void Start()
    {
        currentSkillIcon = gameObject.GetComponent<Image>();
        currentSkillIcon.sprite = equippedSkills.currentSkill.GetIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
