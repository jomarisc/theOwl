using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Testing : MonoBehaviour
{

    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private playerControl player;
    public LevelSystem levelSystem;
   
    private void Awake()
    {
        //levelSystem = new LevelSystem();
        //Debug.Log(levelSystem.GetLevelNumber());
        //levelSystem.AddExperience(50);
        //Debug.Log(levelSystem.GetLevelNumber());
        //levelSystem.AddExperience(60);
        //Debug.Log(levelSystem.GetLevelNumber());
        
        //levelWindow.SetLevelSystem(levelSystem);
        //player.SetLevelSystem(levelSystem);
    }

}
