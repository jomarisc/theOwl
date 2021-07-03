//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Sound Library")]
public class SoundLibrary : ScriptableObject
{
    [SerializeField] Dictionary<string, AudioClip> audioDict;
    public AudioClip soundClip1;

    public void AddSoundClip(AudioClip s1)
    {
        audioDict.Add(s1.name, s1);
    }

    // Designed to work with one sound clip at the moment - 7/3/2021
    public void Start()
    {
        AddSoundClip(soundClip1);
    }

    public Dictionary<string, AudioClip> AudioDict{
        get{return audioDict;}
    }
}
