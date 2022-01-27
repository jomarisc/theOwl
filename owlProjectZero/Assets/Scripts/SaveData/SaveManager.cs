using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private string filePath;
    private int alleyScene;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/saveFile.owl";
        alleyScene = 2;
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
        GlobalVars.hasReachedTheElevator = false;
        GlobalVars.playerHasUnlockedSuit = false;

        CheckpointsHandler.checkpointScene = alleyScene;
        for(int i = 0; i < CheckpointsHandler.playerPosition.Length; i++)
        {
            CheckpointsHandler.playerPosition[i] = 0f;
        }

        Vector3 playerPos = new Vector3(-6.12f, 1f, 0f);
        CheckpointsHandler.playerPosition[0] = playerPos.x;
        CheckpointsHandler.playerPosition[1] = playerPos.y;
        CheckpointsHandler.playerPosition[2] = playerPos.z;

        CheckpointsHandler.isDead = false;
        int openingScene = 10;
        startGame(openingScene);
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
        }
        startGame(CheckpointsHandler.checkpointScene);
    }

    public void startGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void quitGame()
    {
        Application.Quit();
    }    
}
