//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Sound Library")]
public class SoundLibrary : ScriptableObject
{
    [SerializeField] Dictionary<string, AudioClip> audioDict;

    public Dictionary<string, AudioClip> AudioDict{
        get{return audioDict;}
    }
}
