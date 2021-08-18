using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass
{
    public bool[] unlockedSkills;
    public int currentSkill;
    public bool playerHasUnlockedSuit;
    public int checkpointScene;
    public float[] playerPosition;
    public bool isDead;

    public SaveClass()
    {

        // GlobalVars Variables
        unlockedSkills = new bool[3];
        for(int i = 0; i < unlockedSkills.Length; i++)
        {
            unlockedSkills[i] = GlobalVars.unlockedSkills[i];
        }
        currentSkill = GlobalVars.currentSkill;
        playerHasUnlockedSuit = GlobalVars.playerHasUnlockedSuit;

        // CheckpointsHandler Variables
        checkpointScene = CheckpointsHandler.checkpointScene;
        playerPosition = new float[3];
        for(int i = 0; i < playerPosition.Length; i++)
        {
            playerPosition = CheckpointsHandler.playerPosition;
        }

        isDead = CheckpointsHandler.isDead;

    }
}
