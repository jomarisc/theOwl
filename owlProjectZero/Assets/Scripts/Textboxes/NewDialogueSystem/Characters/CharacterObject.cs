//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;



public enum CharacterState{
    Neutral = 0,
    Happy = 1,
    Disappointed = 2,
    Surprised = 3,
    Embarassed = 4,
    Angry = 5,
    Smug = 6
}


[CreateAssetMenu(menuName = "Data/Character")]
[System.Serializable]
public class CharacterObject : ScriptableObject
{
    [Header("General")]
    public string charName;
    public string displayName;

    [Header("Arc Progression")]
    //[SerializeField] public Dictionary<string, TextAsset> filesForDay; // Until you can find a more sustainable way to store multiple TextAssets, for now just use one TextAsset
    public TextAsset dialogueFile; 
    public int RandomSceneCount = 3;

    //[HorizontalGroup("Active Days", 300)]
    //[LabelWidth(300)]
    public int arcProgressionStart = 1;

    [HideInInspector] public int arcProgression;
    //[HorizontalGroup("Active Days", 300)]
    //[LabelWidth(300)]
    public int arcEndPoint = 4;
    [HideInInspector] public int arcLength;
    

    //public CharSchedule schedule;
    public Dictionary<int, NPCStatus> week1Schedule;
    public Dictionary<int, NPCStatus> schedule =  new Dictionary<int, NPCStatus>();

    [Header("VN")]

    public Dictionary<string, SpriteVN> spritesVN;

    public Sprite blinkOverlaySprite;
    public CharacterVoice characterVoice;

    public Color characterColor = Color.white;

    [Header("Overworld")]

    public List<Sprite> spritesOverworld;

    public List<LockPosition> lockedPositions; //for positions that are hard locked for specific days
    //public List<RandomPosition> positionPool; //possible random positions if no base position

    public string CharName{
        get {return charName;}
    }
    public Dictionary<string, SpriteVN> SpritesVN{
        get {return spritesVN;}
    }
    public List<Sprite> SpritesOverworld{
        get {return spritesOverworld;}
    }

    public List<LockPosition> LockedPositions{
        get {return lockedPositions;}
    }

    /*
    public List<RandomPosition> PositionPool{
        get {return positionPool;}
    }*/

    public CharacterDatabase characterDatabase;

    // MOCHA MAGIC CODE
    // public void SetupVN(){
    //     if(SaveGame.loadedFromSave){
    //         //SaveObject saveObject = JsonUtility.FromJson<SaveObject>(SaveSystem.LoadSave(SaveGame.loadedSlot, "arcProgression"));
    //         //arcProgression = saveObject.arcProgressions[charName];
    //         string arcJSON = SaveSystem.LoadSave(SaveGame.loadedSlot, "arcProgression");
    //         Dictionary<string, int> characterProgress = JsonConvert.DeserializeObject<Dictionary<string, int>>(arcJSON);
    //         arcProgression = characterProgress[charName];
    //         /*string scheduleJSON = SaveSystem.LoadSave(SaveGame.loadedSlot, "charSchedule");
    //         Dictionary<string, Dictionary<int, NPCStatus>> characterSchedules = 
    //             JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, NPCStatus>>>(scheduleJSON);
    //         schedule = characterSchedules[charName];*/
    //     }else{
    //         arcProgression = arcProgressionStart;
    //         /*schedule.Clear();
    //         foreach(KeyValuePair<int, NPCStatus> item in week1Schedule){
    //             schedule.Add(item.Key, item.Value);
    //         }*/
    //         //schedule.Append(currentSchedule);
    //     }
    //     arcLength = arcEndPoint;
    // }
    
    // public void SetupNPC(){
    //     if(SaveGame.loadedFromSave){
    //         //SaveObject saveObject = JsonUtility.FromJson<SaveObject>(SaveSystem.LoadSave(SaveGame.loadedSlot, "arcProgression"));
    //         //arcProgression = saveObject.arcProgressions[charName];
    //         /*string arcJSON = SaveSystem.LoadSave(SaveGame.loadedSlot, "arcProgression");
    //         Dictionary<string, int> characterProgress = JsonConvert.DeserializeObject<Dictionary<string, int>>(arcJSON);
    //         arcProgression = characterProgress[charName];*/
    //         string scheduleJSON = SaveSystem.LoadSave(SaveGame.loadedSlot, "charSchedule");
    //         Dictionary<string, Dictionary<int, NPCStatus>> characterSchedules = 
    //             JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, NPCStatus>>>(scheduleJSON);
    //         schedule = characterSchedules[charName];
    //     }else{
    //         //arcProgression = arcProgressionStart;
    //         schedule.Clear();
    //         foreach(KeyValuePair<int, NPCStatus> item in week1Schedule){
    //             schedule.Add(item.Key, item.Value);
    //         }
    //         //schedule.Append(currentSchedule);
    //     }
    //     //arcLength = arcEndPoint;
    // }

}



[System.Serializable]
public class SpriteVN
{
    public Sprite spriteImage;
    public bool canBlink = true;
}
//this is currently unused after dict so commenting it out

[System.Serializable]
public class LockPosition
{
    public int positionDay;
    public Vector3 basePos;
    public spriteDirection direction;
    public bool repeatWeekly;
}

[System.Serializable]
public class RandomPosition
{
    public Vector3 randPos;
    public spriteDirection direction;
}


[System.Serializable]
public class CharacterVoice
{
    [SerializeField] string voiceClipString;
    private SoundLibrary soundLibrary;
    [SerializeField] float interval;

    public string VoiceClipString{
        get{return voiceClipString;}
    }
    public AudioClip VoiceClip(SoundLibrary soundLibrary){
        AudioClip data;
        if (!soundLibrary.AudioDict.TryGetValue(voiceClipString, out data)) {
            Debug.LogError(message: $"<size=16><color=orange> soundLibrary.AudioDict doesn't have the value: {voiceClipString} </color></size>");
        }
        else
        {
            //do whatever you were planning to do
            return soundLibrary.AudioDict[voiceClipString];
        }
        Debug.LogError(message: $"<size=16><color=orange> soundLibrary.AudioDict[voiceClipString] ended as NULL </color></size>");
        return null;
    }
    public float Interval{
        get{ return interval;}
    }
}

[System.Serializable]
public class CharSchedule
{
    /*
    [SerializeField] bool sunday;
    [SerializeField] bool monday;
    [SerializeField] bool tuesday;
    [SerializeField] bool wednesday;
    [SerializeField] bool thursday;
    [SerializeField] bool friday;
    [SerializeField] bool saturday;

    public bool Sunday{
        get{ return sunday;}
    }
    public bool Monday{
        get{ return monday;}
    }
    public bool Tuesday{
        get{ return tuesday;}
    }
    public bool Wednesday{
        get{ return wednesday;}
    }
    public bool Thursday{
        get{ return thursday;}
    }
    public bool Friday{
        get{ return friday;}
    }
    public bool Saturday{
        get{ return saturday;}
    }
    */

    [SerializeField] NPCStatus sunday;
    [SerializeField] NPCStatus monday;
    [SerializeField] NPCStatus tuesday;
    [SerializeField] NPCStatus wednesday;
    [SerializeField] NPCStatus thursday;
    [SerializeField] NPCStatus friday;
    [SerializeField] NPCStatus saturday;

    public NPCStatus Sunday{
        get{ return sunday;}
    }
    public NPCStatus Monday{
        get{ return monday;}
    }
    public NPCStatus Tuesday{
        get{ return tuesday;}
    }
    public NPCStatus Wednesday{
        get{ return wednesday;}
    }
    public NPCStatus Thursday{
        get{ return thursday;}
    }
    public NPCStatus Friday{
        get{ return friday;}
    }
    public NPCStatus Saturday{
        get{ return saturday;}
    }

}

public enum spriteDirection{
    Left,
    Right
}


public enum NPCStatus{
    Absent,
    Customer,
    Visitor,
    AbsentOrVisitor,
    AbsentOrCustomer,
    CustomerOrVisitor,
    Any,
}