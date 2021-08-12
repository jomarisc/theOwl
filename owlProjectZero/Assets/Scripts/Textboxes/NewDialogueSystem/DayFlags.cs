using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
using System.Linq;

//[CreateAssetMenu(menuName = "Story/DayFlags")]
public class DayFlags : ScriptableObject
{
    public int day;

    public string description;

    public List<StoryScenes> scenesToLoad;

    public List<StoryScenes> scenesInDay; // [ReadOnly]

    public List<StoryFlag> mandatoryFlags;

    public int maxGenericNPCs = 6;

    public void Setup(){
        //Debug.Log("refreshing data");
        scenesInDay.Clear();
        scenesInDay.AddRange(scenesToLoad);
    }
}

[System.Serializable]
public class StoryScenes{
    //[HorizontalGroup("Scene Data", LabelWidth = 250)]
    public string sceneFlag;
    //[HorizontalGroup("Scene Data", LabelWidth = 120)]
    public bool repeatable;
    //[HorizontalGroup("Script Data")]
    public TextAsset sceneContent;
    //[HorizontalGroup("Script Data")]
    public string sceneStart;

    public StoryScenes(string sceneFlag, TextAsset sceneContent, string sceneStart, bool repeatable){
        this.sceneFlag = sceneFlag;
        this.sceneContent = sceneContent;
        this.sceneStart = sceneStart;
        this.repeatable = repeatable;
    }
    
}

[System.Serializable]
public class StoryFlag{
    //[HorizontalGroup("Scene Data", LabelWidth = 250)]
    public string flagTrigger;
    //[HorizontalGroup("Scene Data", LabelWidth = 120)]
    public int timesActivated;
}