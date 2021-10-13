using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StopFlashing : MonoBehaviour
{
    public Animation[] menuButtons;
    public SaveManager saveManager;

    public void FlashPlay()
    {
        menuButtons[0].Stop();
        menuButtons[0].Play();
        StartCoroutine(FlashFinish(menuButtons[0], 0));
    }

    public void FlashNewGame()
    {
        menuButtons[1].Stop();
        menuButtons[1].Play();

        StartCoroutine(FlashFinish(menuButtons[1], 1));
    }

    public void FlashOptions()
    {
        menuButtons[2].Stop();
        menuButtons[2].Play();
    }

    public void FlashQuit()
    {
        menuButtons[3].Stop();
        menuButtons[3].Play();

        StartCoroutine(FlashFinish(menuButtons[3], 3));
    }

    IEnumerator FlashFinish(Animation FlashButton, int menuButton)
    {
        while(FlashButton.isPlaying)
        {
            Debug.Log("here in isplaying");
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("here outside isplaying");

        if(menuButton == 0)
        {
            Debug.Log("here1");
            saveManager.loadGame();
        }
        else if(menuButton == 1)
        {
            Debug.Log("here2");
            saveManager.clearGame();
        }
        else
        {
            Debug.Log("here3");
            saveManager.quitGame();
        }
    }
}
