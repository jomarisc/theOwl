using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// This class is in charge of updating the skill wheel UI when necessary
[RequireComponent(typeof(Image))]
public class SkillWheelSlotUI : MonoBehaviour
{
    [SerializeField] private PlayerSkills equippedSkills;
    [SerializeField] private int slotNumber;
    private Image myIcon;

    void Awake()
    {
        myIcon = gameObject.GetComponent<Image>();
    }
    
    void OnEnable()
    {
        myIcon.sprite = equippedSkills.unlockedSkillTypeList[slotNumber - 1].GetIcon();
        if(slotNumber == 1)
            EventSystem.current.SetSelectedGameObject(this.gameObject.GetComponentInParent<Button>().gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
