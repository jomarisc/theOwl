//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Data/Sound Library")]
public class SoundLibrary : ScriptableObject
{
    [SerializeField] Dictionary<string, AudioClip> audioDict;
    [SerializeField] public List<string> _audioKeys;
    [SerializeField] public List<AudioClip> _audioValues;
    public AudioClip soundClip1;

    public Dictionary<string, AudioClip> AddingAudioIntoNewDict() // AudioClip s1
    {
        Dictionary<string, AudioClip> returnDict = new Dictionary<string, AudioClip>();
        //Debug.Log(message: $"<color=blue><size=16> s1 name: {s1.name} </size></color>");
        // Disabled until adding to the dictionary is reliable
        //audioDict.Add(s1.name, s1);

        // Iterating through List to form a dictionary of audio clips
        //Dictionary<string, CharacterObject> returnDict = new Dictionary<string, CharacterObject>();
        foreach(AudioClip audioClip in _audioValues){
            Debug.Log(message: $"<color=blue><size=16> audioClip name: {audioClip.name} </size></color>");
            returnDict.Add(audioClip.name, audioClip);
        }
        return returnDict;
    }

    public void TestAddingAudioIntoNewDict() // AudioClip s1
    {
        Dictionary<string, AudioClip> returnDict = new Dictionary<string, AudioClip>();
        //Debug.Log(message: $"<color=blue><size=16> s1 name: {s1.name} </size></color>");
        
        // Printing out what is in _audioValues
        foreach(AudioClip audioClip in _audioValues){
            Debug.Log(message: $"<color=blue><size=16> audioClip name: {audioClip.name} </size></color>");
        }
    }

    public void SettingAudioIntoLocalDict()
    {
        Dictionary<string, AudioClip> newDict = AddingAudioIntoNewDict();
        audioDict = mergeDictionaries(newDict, audioDict);
    }

    public Dictionary<string, AudioClip> mergeDictionaries(Dictionary<string, AudioClip> newDict, Dictionary<string, AudioClip> localDict)
    {
        Dictionary<string, AudioClip> resultDict = new Dictionary<string, AudioClip>();
        
        // Union() approach
        //foreach (Dictionary<string, AudioClip> dict in input)
        //{
            //resultDict = resultDict.Union(dict).GroupBy(g => g.Key).ToDictionary(pair => pair.Key, pair => pair.First().Value);
        //}

        // Starting case when local dictionary has 
        if (localDict == null)
        {
            Debug.Log("localDict is null");
            localDict = new Dictionary<string, AudioClip>(newDict);
            resultDict = localDict;

        } else {

            Debug.Log("localDict is NOT null");
            resultDict = newDict.Union(localDict).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);

        }

        AudioClip data;
        if (localDict.TryGetValue("ProjectileShootSFX", out data)) 
        {    
            Debug.Log(message: $"<size=16><color=green> soundLibrary.AudioDict has the value ProjectileShootSFX </color></size>");
        } 
        else
        {
            Debug.Log(message: $"<size=16><color=orange> soundLibrary.AudioDict doesn't have the value ProjectileShootSFX </color></size>");
        }
                
        // LINQ approach
        //resultDict.SelectMany(x => x).GroupBy(d => d.Key).ToDictionary(x => x.Key, y => y.First().Value);

        return resultDict;
    }

    // Designed to work with one sound clip at the moment - 7/3/2021
    public void Start()
    {
        // Debug.Log(message: $"<color=blue><size=16> souncClip1 name: {soundClip1.name} </size></color>");
        //AddSoundClip(soundClip1);
        //AddSoundClips();
        //SettingAudioIntoLocalDict();
    }

    public Dictionary<string, AudioClip> AudioDict{
        get{return audioDict;}
    }
}
