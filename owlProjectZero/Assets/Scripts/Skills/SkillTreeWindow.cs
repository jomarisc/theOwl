using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SkillTreeWindow : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private GameObject player;
    private playerControl playerScript;
    private Collectable currency;
    private LevelWindow levelWindow;
    private GameObject currentSelectedGameObjectPrevious;
   
    public GameObject currentSelectedGameObject;
    public GameObject lastSelectedGameObject;
    public GameObject skillTreeWindow;
    public GameObject resumeButton;
    public bool isDisplaying;

    // Old code
    //public GameObject skillButton;
    //public GameObject shieldButton;

    public void Start()
    {
        isDisplaying = true;
        player = GameObject.Find("player");
        playerScript = player.GetComponent<playerControl>();
        playerSkills = playerScript.GetPlayerSkills();
        currency = GameObject.Find("collectables").transform.Find("currency").gameObject.GetComponent<Collectable>();
        levelWindow = GameObject.Find("LevelWindow").GetComponent<LevelWindow>();

        // Old code
        //skillButton = GameObject.Find("Canvas").transform.Find("ShieldButton").gameObject.GetComponent<>();
        //EventSystem.current.SetSelectedGameObject(resumeButton);
        //skillTreeButton = canvas.transform.Find("ResumeButton");
        //.GetComponent<ResumeButton>();
        //"tranform.()FindObjectOfType<ResumeGame>().gameObject;
    }

    public void Update()
    {
        currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
        GetLastGameObjectSelected();
    }
    

    public void DisplaySkillTree()
    {
        if (isDisplaying)
        {
            skillTreeWindow.SetActive(true);
            isDisplaying = false;
        }
        else
        {
            skillTreeWindow.SetActive(false);
            isDisplaying = true;
        }
      
    }
    
    public void WindowUnlockSkill()
    {
        // When SkillButton is clicked
        
        // DEBUG
        //Debug.Log("Player Currency: " + playerScript.GetCurrency());
        //Debug.Log("Player Level: " + playerScript.GetLevelSystem().GetLevelNumber());
        //Debug.Log("Shield Unlocked: " + playerScript.GetPlayerSkills().IsSkillUnlocked(PlayerSkills.SkillType.Shield));

        if (playerScript.GetCurrency() >= 0)
        {
            if (playerScript.GetCurrency() >= 20 && playerScript.levelSystem.GetLevelNumber() >= 2
                && !(playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Shield)))
                //&& (EventSystem.current.currentSelectedGameObject == shieldButton))
            {
                Debug.Log("Skill Unlocked!");
                playerSkills.UnlockSkill(PlayerSkills.SkillType.Shield);
                playerScript.SubtractCurrency(20);
                currency.currencyText.text = "Currency: " + playerScript.GetCurrency();
                Debug.Log("Player Currency (AFTER): " + playerScript.GetCurrency());

              
            }
            else //if (playerScript.GetCurrency) // Further define the else condition - 8/31/2020
            {
                Debug.Log("Not enough currency or level");
            }
        }

        // Other ways to use SetSelectedGameObject
        //EventSystem.current.SetSelectedGameObject(skillTreeButton);
        //eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(currentSelectedGameObjectPrevious);
        /*
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
        */
        //EventSystem.current.SetSelectedGameObject(lastSelectedGameObject);
    }

    
    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
    }

    // Additional function(s)
    public void GetLastGameObjectSelected()
    {
        
        if (EventSystem.current.currentSelectedGameObject != currentSelectedGameObjectPrevious)
        {
            lastSelectedGameObject = currentSelectedGameObjectPrevious;
            currentSelectedGameObjectPrevious = EventSystem.current.currentSelectedGameObject;
        }
        
    }
   
}
