using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDictionary : MonoBehaviour
{
    public CharacterObject SampleCharacter;
    public Dictionary<CharacterObject, int> characterLocalDict;
    public int testNumber = 1;

    // Every time this script starts up, the follow code is run
    public void Awake()
    {
        characterLocalDict.Add(SampleCharacter, testNumber); // Testing pigeon character
    }

}
