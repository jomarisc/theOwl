using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
using System.Linq;

[CreateAssetMenu(menuName = "Data/Character Database")]
public class CharacterDatabase : ScriptableObject
{
    [SerializeField] VNVariables gameVariables;
    //[HorizontalGroup("Active Days", LabelWidth = 70)]
    [SerializeField] int startDay;
    //[HorizontalGroup("Active Days")]
    //[SerializeField] DayOfWeek firstDay;
    //[HorizontalGroup("Active Days")]
    [SerializeField] int week1End;
    //[HorizontalGroup("Active Days")]
    [SerializeField] int finalDay;
    //[HorizontalGroup("Active Days")]
    //[SerializeField] List<DayFlags> dayScripts;
    //[BoxGroup("Characters")]
    //[LabelWidth(100)]
    
    // Separating the character dictionary
    public Dictionary<CharacterObject, int> characterDict = new Dictionary<CharacterObject, int>(); // CharacterArcPoints
    //public Dictionary<SerializableDictionary> testDictionary; 
    // Test dictionary
    [SerializeField] public List<CharacterObject> _characterDictKeys;
    [SerializeField] public List<int> _characterDictValues;

    // Manually adding character because we cannot drag and drop without Odin
    [SerializeField] public CharacterObject SampleCharacter; 

    [SerializeField] List<CharacterObject> npcList;
    //[SerializeField] Dictionary<CharacterObject, Vector2> characterArcRange;
    [SerializeField] List<RandomPosition> spawnPositionPool;
    private List<CharacterObject> activeCharactersList; //characterList + npcList, made public
    public Dictionary<CharacterObject, int> CharacterDict{ // CharacterArcPoints
        get{ return characterDict;}
    }
    public List<CharacterObject> NPCList{
        get{ return npcList;}
    }
    
    // public List<DayFlags> DayScripts{
    //     get{ return dayScripts;}
    // }
    
    public List<RandomPosition> SpawnPositionPool{
        get{ return spawnPositionPool;}
    }
    public int StartDay{
        get{return startDay;}
    }
    public int Week1End{
        get{return week1End;}
    }

    public int FinalDay{
        get{return finalDay;}
    }

    // public DayOfWeek FirstDay{
    //     get{return firstDay;}
    // }

    public void CreateActiveCharsList(){
        //List<CharacterObject> characterObjectList = new List<CharacterObject>(characterDict.Keys); // this. // Figure out why this list is not being created properly - 7/21/2021
        List<CharacterObject> characterObjectList = new List<CharacterObject>(_characterDictKeys);
        var allChars = characterObjectList.Union(npcList).ToList();
        activeCharactersList = allChars;
    }

    //returns dict with character names as keys instead
    public Dictionary<string, CharacterObject> CharacterNameDict(){
        Dictionary<string, CharacterObject> returnDict = new Dictionary<string, CharacterObject>();
        foreach(CharacterObject chara in _characterDictKeys){ // CharacterList()
            returnDict.Add(chara.CharName, chara);
            Debug.Log(returnDict);
        }
        return returnDict;
    }

    public CharacterObject GetCharacterObject(string characterObject){
        foreach(KeyValuePair<CharacterObject, int> characterSlot in characterDict){ //CharacterArcPoints
            if(characterSlot.Key.CharName == characterObject){
                return characterSlot.Key;
            }
        }
        Debug.LogWarning("Get Character Object - No such character exists!");
        return null;
    }

    public List<CharacterObject> CharacterList(){
        // foreach (KeyValuePair<CharacterObject, CharacterArcPoints> pair in characterDict)  
        // {  
        //     Debug.Log(message:$"<color=green> <size=16> Key: {pair.Key} , Value: {pair.Value} </size> </color>");  
        // }

        // Dictionary<CharacterObject, int> characterDict
        //Dictionary<CharacterObject, int>.KeyCollection keys = characterDict.Keys;  
        Dictionary<CharacterObject, int> testDictionary = characterDict;        
        /*
        foreach (CharacterObject key in keys)  
        {  
            Debug.Log(message:$"<size=16><color=green> Key: {key.charName} </color></size>");  
        } 
        */

        List<CharacterObject> returnList = new List<CharacterObject>(this.characterDict.Keys);
        // foreach(CharacterObject i in returnList)
        // {
        //     Debug.Log(message:$"<color=yellow><size=16> i.charName: </size></color> <size=16> {i.charName} </size>");
        // }
        return returnList;
        /*
        int searchValueTarget = 1;
        if(characterDict.TryGetValue(SampleCharacter, out searchValueTarget))
        {
            List<CharacterObject> returnList = characterDict.Keys.ToList();
            return returnList;

        } else {
            Debug.Log("Key is " +  SampleCharacter.charName + " in characterDict");
        }
        return null;
        */
    }
    public Dictionary<string, CharacterObject> NPCDict(){
        Dictionary<string, CharacterObject> returnDict = new Dictionary<string, CharacterObject>();
        foreach(CharacterObject chara in new List<CharacterObject>(this.characterDict.Keys)){
            returnDict.Add(chara.CharName, chara);
            Debug.Log(returnDict);
        }
        return returnDict;
    }

    //check if at least one arc is complete
    public bool IsAnArcComplete(){
        foreach(KeyValuePair<CharacterObject, int> vnChar in characterDict){ // CharacterArcPoints
            //if the character's arc is at a state where it's done
            //arc progression = arcProgression + pending
            int arcState = vnChar.Key.arcProgression;
            if(arcState > vnChar.Value){ // .arcEndPoint
                return true;
            }
        }
        return false;

    }

    public CharacterObject npcNamed(string name){
        foreach(CharacterObject npcData in npcList){
            if(npcData.CharName == name){
                return npcData;
            }
        }
        return null;
    }

    public void AssignCharValues(){
        foreach(KeyValuePair<CharacterObject, int> slot in characterDict){ // CharacterArcPoints
            slot.Key.arcProgressionStart = slot.Value; // .arcStartPoint
            slot.Key.arcEndPoint = slot.Value; // .arcEndPoint
        }
    }

    public void Setup(){
        //Debug.Log("creating."); 
        AssignCharValues();
        gameVariables.Setup(); 
        AddToVNVariables();
    }

    public void AddToVNVariables(){
        AddAllCharacterColors();
        AddAllColoredNames();
    }

    //add all character colors as variables
    public void AddAllCharacterColors(){
        CreateActiveCharsList();
        foreach(CharacterObject character in activeCharactersList){
            string colorKey = character.name + "ColorVal";
            gameVariables.stringVariables.Add(colorKey, '#' +ColorUtility.ToHtmlStringRGBA(character.characterColor));
        }
    }
    public void AddAllColoredNames(){
        CreateActiveCharsList();
        foreach(CharacterObject character in activeCharactersList){
            string colorKey = character.name + "Color";
            string colorValue = "<color=" + '#'+ ColorUtility.ToHtmlStringRGBA(character.characterColor) +">"+character.name+"</color>";
            gameVariables.stringVariables.Add(colorKey, colorValue);
        }
    }

    public void AddCurrentDay(int day){
        if(!gameVariables.stringVariables.ContainsKey("currentDay")){
            gameVariables.stringVariables.Add("currentDayNumber", day.ToString());
            gameVariables.stringVariables.Add("currentDay", "Day " + day.ToString());
        }else{
            gameVariables.stringVariables["currentDayNumber"] = day.ToString();
            gameVariables.stringVariables["currentDay"] = "Day " + day.ToString();
        }
        
    }

    public void Awake()
    {
        //CharacterObject sampleCharacter = (CharacterObject) ScriptableObject.CreateInstance("CharacterObject");
        //this.characterDict.Add(SampleCharacter, 1); // Testing pigeon character
        
        // if(characterDict.ContainsKey(SampleCharacter))
        // {
        //     Debug.Log("Character in Dictionary, CharacterDatabase");
        // } 
        // else
        // {
        //     Debug.Log("Character not in Dictionary, CharacterDatabase");
        // }
    }
    
    
}

[System.Serializable]
public class CharacterArcPoints{
    //[BoxGroup("Arc Points")]
    //[LabelWidth(100)] 
    public int arcStartPoint = 1;
    //[BoxGroup("Arc Points")]
    //[LabelWidth(100)]
    public int arcEndPoint = 1;
}

/*
public class SerializableDictionary<CharacterObject, int> : ISerializationCallbackReceiver
{
    [SerializeField] List<CharacterObject> _Keys;
    [SerializeField] List<int> _Values;
}
*/