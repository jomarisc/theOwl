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

    public Slider mSlider;
    public Slider sSlider;
    public float defaultVolume;

    public TMP_Text Title;
    [SerializeField] private string menuTitle;
    [SerializeField] private string settingsTitle;

    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject lastButton;

    private bool navButtonsActive;
    private bool settingsMenuActive;

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    void Start()
    {
        navButtonsActive = true;
        settingsMenuActive =  false;

        // Debug.Log("IN MAIN MENU: ");
        // Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
        // Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
        // Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));
        // Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));

        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Debug.Log("PlayerPrefs musicVolume does exist");
            float getVolume = PlayerPrefs.GetFloat("musicVolume");
            // Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
            mSlider.value = Mathf.Pow(10, getVolume / 20);
            musicMixer.SetFloat("musicVolume", getVolume);
            // Debug.Log("getVolume is " + getVolume);
            // Debug.Log("music slider value is " + mSlider.value);
        }
        else
        {
            Debug.Log("PlayerPrefs musicVolume does not exist");
            PlayerPrefs.SetFloat("musicVolume", defaultVolume);
            PlayerPrefs.Save();
        }

        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            float getVolume = PlayerPrefs.GetFloat("sfxVolume");
            // Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));
            sSlider.value = Mathf.Pow(10, getVolume / 20);
            sfxMixer.SetFloat("sfxVolume", getVolume);
            // Debug.Log("sfx slider value is " + sSlider.value);
        }
        else
        {
            PlayerPrefs.SetFloat("sfxVolume", defaultVolume);
            PlayerPrefs.Save();
        }

        // navButtons.SetActive(navButtonsActive);
        for(int i = 0; i < navButtons.transform.childCount; i++)
        {
            navButtons.transform.GetChild(i).gameObject.SetActive(navButtonsActive);
        }

        settingsMenu.SetActive(settingsMenuActive);
    }

    // void Start()
    // {
    //     // navButtons.SetActive(navButtonsActive);
    //     for(int i = 0; i < navButtons.transform.childCount; i++)
    //     {
    //         navButtons.transform.GetChild(i).gameObject.SetActive(navButtonsActive);
    //     }

    //     settingsMenu.SetActive(settingsMenuActive);
    // }

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
