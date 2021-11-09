using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenuSettings : MonoBehaviour
{
    public GameObject navButtons;
    public GameObject settingsMenu;
    public GameObject musicSlider;

    public TMP_Text Title;
    [SerializeField] private string menuTitle;
    [SerializeField] private string settingsTitle;

    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject lastButton;

    private bool navButtonsActive;
    private bool settingsMenuActive;

    void Awake()
    {
        navButtonsActive = true;
        settingsMenuActive =  false;
    }

    void Start()
    {
        // navButtons.SetActive(navButtonsActive);
        for(int i = 0; i < navButtons.transform.childCount; i++)
        {
            navButtons.transform.GetChild(i).gameObject.SetActive(navButtonsActive);
        }

        settingsMenu.SetActive(settingsMenuActive);
    }

    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(optionsButton);
        }
        else
        {
            lastButton = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void setMainMenu()
    {
        navButtonsActive = !navButtonsActive;
        settingsMenuActive = !settingsMenuActive;

        // navButtons.SetActive(navButtonsActive);
        for(int i = 0; i < navButtons.transform.childCount; i++)
        {
            navButtons.transform.GetChild(i).gameObject.SetActive(navButtonsActive);
        }

        settingsMenu.SetActive(settingsMenuActive);

        if(settingsMenuActive)
        {
            EventSystem.current.SetSelectedGameObject(musicSlider);
            Title.text = settingsTitle;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(optionsButton);
            Title.text = menuTitle;
        }
    }
}
