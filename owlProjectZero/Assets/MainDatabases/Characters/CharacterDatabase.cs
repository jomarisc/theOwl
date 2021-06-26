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
    [SerializeField] Dictionary<CharacterObject, CharacterArcPoints> characterDict;
    [SerializeField] List<CharacterObject> npcList;
    //[SerializeField] Dictionary<CharacterObject, Vector2> characterArcRange;
    [SerializeField] List<RandomPosition> spawnPositionPool;
    private List<CharacterObject> activeCharactersList; //characterList + npcList
    public Dictionary<CharacterObject,  CharacterArcPoints> CharacterDict{
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
        List<CharacterObject> characterObjectList = new List<CharacterObject>(this.characterDict.Keys);
        var allChars = characterObjectList.Union(npcList).ToList();
        activeCharactersList = allChars;
    }

    //returns dict with character names as keys instead
    public Dictionary<string, CharacterObject> CharacterNameDict(){
        Dictionary<string, CharacterObject> returnDict = new Dictionary<string, CharacterObject>();
        foreach(CharacterObject chara in CharacterList()){
            returnDict.Add(chara.CharName, chara);
            Debug.Log(returnDict);
        }
        return returnDict;
    }

    public CharacterObject GetCharacterObject(string characterObject){
        foreach(KeyValuePair<CharacterObject, CharacterArcPoints> characterSlot in characterDict){
            if(characterSlot.Key.CharName == characterObject){
                return characterSlot.Key;
            }
        }
        Debug.LogWarning("Get Character Object - No such character exists!");
        return null;
    }

    public List<CharacterObject> CharacterList(){
        List<CharacterObject> returnList = new List<CharacterObject>(this.characterDict.Keys);
        return returnList;
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
        foreach(KeyValuePair<CharacterObject, CharacterArcPoints> vnChar in characterDict){
            //if the character's arc is at a state where it's done
            //arc progression = arcProgression + pending
            int arcState = vnChar.Key.arcProgression;
            if(arcState > vnChar.Value.arcEndPoint){
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
        foreach(KeyValuePair<CharacterObject, CharacterArcPoints> slot in characterDict){
            slot.Key.arcProgressionStart = slot.Value.arcStartPoint;
            slot.Key.arcEndPoint = slot.Value.arcEndPoint;
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
