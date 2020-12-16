using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.UI;

public class PauseMenu : MonoBehaviour
{
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
    }

    private void OnDisable()
    {
        input.Disable();
    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        pc.enabled = false;
        Time.timeScale = 0f;
        isPaused = true;

        EventSystem.current.SetSelectedGameObject(resumebutton);
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(input.UI.Navigate);
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        pc.enabled = true;
        Time.timeScale = 1f;
        isPaused = false;

        EventSystem.current.SetSelectedGameObject(null);

    }

    public void MainMenu()
    {
        pc.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
