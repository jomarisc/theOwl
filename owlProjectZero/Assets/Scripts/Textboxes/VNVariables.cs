//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Data/VN Variables")]
public class VNVariables : ScriptableObject
{

    [Header("String Variables that the player can put in!")]
    public Dictionary<string, string> userVariables;
    [Header("String Variables that the VN knows!")]
    public Dictionary<string, string> stringVariables;

    private void Awake(){
        // Setup();
        
    }  

    public void Setup(){
        //Debug.Log("<b>setting up dictionary!");
        refreshDictionary();
        AddUserVariables(); 
    }

    private void refreshDictionary(){
        stringVariables.Clear();
    }

    private void AddUserVariables(){
        Dictionary<string, string> newDict = 
            stringVariables.Union(userVariables.Where(k => !stringVariables.ContainsKey(k.Key))).ToDictionary(k => k.Key, v => v.Value);
        // Manual addition - 8/3/2021, Re-factor this
        userVariables.Add("c", "d");
        newDict.Add("a", "b");
        stringVariables = newDict;
    }



}

