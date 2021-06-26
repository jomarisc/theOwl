using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StopFlashing : MonoBehaviour
{
    public Animation[] menuButtons;

    public void FlashPlay()
    {
        menuButtons[0].Stop();
        menuButtons[0].Play();
    }

    public void FlashOptions()
    {
        menuButtons[1].Stop();
        menuButtons[1].Play();
    }

    public void FlashQuit()
    {
        menuButtons[2].Stop();
        menuButtons[2].Play();
    }
}
