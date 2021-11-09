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
        volumeMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    public void setsfxVolume(float volume)
    {
        volumeMixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }
}
