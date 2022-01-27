﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.UI;

public class PauseMenu : MonoBehaviour
{
    private bool pcWasEnabled = true;
    private GameObject previouslySelectedGameObject = null;
    public GameObject pausemenu = null;
    public GameObject resumebutton;
    public playerControl pc;
    public GameObject player;
    public bool isPaused;

    public PlayerInputs input;


    public void Awake()
    {
        input = new PlayerInputs();
    }

    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        player = GameObject.Find("player");
        pc = player.GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Gameplay.Pause.triggered)
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }

        if(isPaused && input.UI.Cancel.triggered)
            ResumeGame();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Gameplay.OpenSkillWheel.Disable();
        input.Gameplay.OpenSkillWheel2.Disable();
    }

    private void OnDisable()
    {
        input.Gameplay.OpenSkillWheel.Enable();
        input.Gameplay.OpenSkillWheel2.Enable();
        input.Disable();
    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        pcWasEnabled = pc.enabled;
        pc.enabled = false;
        Time.timeScale = 0f;
        isPaused = true;

        previouslySelectedGameObject = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(resumebutton);
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(input.UI.Navigate);
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        pc.enabled = pcWasEnabled;
        Time.timeScale = 1f;
        isPaused = false;

        EventSystem.current.SetSelectedGameObject(previouslySelectedGameObject);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
