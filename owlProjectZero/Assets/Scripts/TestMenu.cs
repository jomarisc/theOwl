using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestMenu : MonoBehaviour
{
    [SerializeField] private int nextScene;
    private playerControl player;

    //public string exitPoint;

    public void Start()
    {
        //player = FindObjectOfType<playerControl>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(nextScene);
        //playerControl player = GameObject.FindObjectOfType<playerControl>();
        //player.startPoint = "Alley";
        //Debug.Log("player.startPoint from Test Menu: " + player.startPoint);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
