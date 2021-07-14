using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestMenu : MonoBehaviour
{
    [SerializeField] private int nextScene = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
