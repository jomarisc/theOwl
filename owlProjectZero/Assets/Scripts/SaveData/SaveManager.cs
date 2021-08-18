using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    public string filePath;
    public string newGameScene;
    public int newGameSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/saveFile.owl";
        newGameScene = "Alley";
        newGameSceneIndex = CheckpointsHandler.checkpointScene;
    }

    public void saveGame()
    {
        Debug.Log("SAVING DATA...");
        SaveSystem.saveData();
    }

    public void clearGame()
    {
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        for(int i = 0; i < GlobalVars.unlockedSkills.Length; i++)
        {
            GlobalVars.unlockedSkills[i] = false;
        }
        GlobalVars.currentSkill = 0;
        GlobalVars.playerHasUnlockedSuit = false;

        CheckpointsHandler.checkpointScene = 2;
        for(int i = 0; i < CheckpointsHandler.playerPosition.Length; i++)
        {
            CheckpointsHandler.playerPosition[i] = 0f;
        }
        CheckpointsHandler.isDead = false;

    }

    // If there's a file, load it. Otherwise, start a new game.
    public void loadGame()
    {
        if(File.Exists(filePath))
        {
            Debug.Log("LOADING DATA...");
            SaveClass newData = SaveSystem.loadData();

            GlobalVars.unlockedSkills = newData.unlockedSkills;
            for(int i = 0; i < GlobalVars.unlockedSkills.Length; i++)
            {
                GlobalVars.unlockedSkills[i] = newData.unlockedSkills[i];
            }
            GlobalVars.currentSkill = newData.currentSkill;
            GlobalVars.playerHasUnlockedSuit = newData.playerHasUnlockedSuit;

            // CheckpointsHandler Variables
            CheckpointsHandler.checkpointScene = newData.checkpointScene;
            CheckpointsHandler.playerPosition = new float[3];
            for(int i = 0; i < CheckpointsHandler.playerPosition.Length; i++)
            {
                CheckpointsHandler.playerPosition = newData.playerPosition;
            }
            CheckpointsHandler.isDead = newData.isDead;
            SceneManager.LoadScene(CheckpointsHandler.checkpointScene);
        }
        // else
        // {
        //     clearGame();
        //     SceneManager.LoadScene(newGameScene);
        // }
    }
}
