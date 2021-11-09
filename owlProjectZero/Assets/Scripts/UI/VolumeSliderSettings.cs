using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliderSettings : MonoBehaviour
{
    public AudioMixer volumeMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setmusicVolume(float volume)
    {   
        float logVolume = Mathf.Log10(volume) * 20;
        volumeMixer.SetFloat("musicVolume", logVolume);
        saveMusicVolume(logVolume);

    }

    public void setsfxVolume(float volume)
    {   
        float logVolume = Mathf.Log10(volume) * 20;
        volumeMixer.SetFloat("sfxVolume", logVolume);
        saveSFXVolume(logVolume);
    }

    private void saveMusicVolume(float savedVolume)
    {
        PlayerPrefs.SetFloat("musicVolume", savedVolume);
        Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
        PlayerPrefs.Save();
    }

    private void saveSFXVolume(float savedVolume)
    {
        PlayerPrefs.SetFloat("sfxVolume", savedVolume);
        Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));
        PlayerPrefs.Save();
    }
}
