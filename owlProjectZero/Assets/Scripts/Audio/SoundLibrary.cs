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
        //Debug.Log(message: $"<color=blue><size=16> s1 name: {s1.name} </size></color>");
        audioDict.Add(s1.name, s1);
    }

    // Designed to work with one sound clip at the moment - 7/3/2021
    public void Start()
    {
        Debug.Log(message: $"<color=blue><size=16> souncClip1 name: {soundClip1.name} </size></color>");
        AddSoundClip(soundClip1);
    }

    public Dictionary<string, AudioClip> AudioDict{
        get{return audioDict;}
    }
}
