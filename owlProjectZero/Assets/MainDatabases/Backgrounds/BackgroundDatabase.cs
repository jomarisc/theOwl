//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Background Library")]
public class BackgroundDatabase : ScriptableObject
{
    [SerializeField] Dictionary<string, Sprite> vnBackgroundDict;

    [SerializeField] Dictionary<string, Sprite> overworldBackgroundDict;

    [SerializeField] Dictionary<string, Sprite> cgDict;

    public Dictionary<string, Sprite> VNBackgroundDict{
        get{return vnBackgroundDict;}
    }

    public Dictionary<string, Sprite> OverworldBackgroundDict{
        get{return overworldBackgroundDict;}
    }

    public Dictionary<string, Sprite> CGDict{
        get{return cgDict;}
    }
}
