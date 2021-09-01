using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

public class NPCBehavior : MonoBehaviour
{

    public CharacterObject character;
    [SerializeField] GameObject notificationPopup;
    [SerializeField] SpriteRenderer spriteRenderer;

    public VisitingStatus visitingStatus;

    // Start is called before the first frame update
    public void Setup()
    {
        SetSprite();
        
        //transform.position = character.baseOverworldPos;
        //notificationPopup = this.transform.GetChild(0).gameObject;
        HideNotification();
        
    }

    public void SetSprite(){
        spriteRenderer.sprite = character.spritesOverworld[0];
    }

    void NPCExitScene(){
        this.gameObject.SetActive(false);
    }

    public void ShowNotification(){
        notificationPopup.SetActive(true);
    }

    public void HideNotification(){
        notificationPopup.SetActive(false);
    }
    
}

public enum VisitingStatus{
    Visitor,
    Customer,
    Absent
}
