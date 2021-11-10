using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryFlags {hasReachedTheElevator, playerHasUnlockedSuit, hasKamehameha}
public class LockContent : MonoBehaviour
{
    [SerializeField] private StoryFlags flag;
    [SerializeField] private GameObject[] contentToLock;

    // Start is called before the first frame update
    void Start()
    {
        LockGameplay(flag);
    }

    private void LockGameplay(StoryFlags myFlag)
    {
        switch(myFlag)
        {
            case StoryFlags.hasReachedTheElevator:
                if(GlobalVars.hasReachedTheElevator)
                {
                    // Set default scene to Alley scene
                    CheckpointsHandler.checkpointScene = 2;
                    LockThemContent();
                }
                break;
            case StoryFlags.playerHasUnlockedSuit:
                throw new Exception("Not yet sure what content to lock/unlock if the player has/hasn't unlocked the suit");
            case StoryFlags.hasKamehameha:
                if(GlobalVars.unlockedSkills[1])
                    LockThemContent();
                break;
            default:
                Debug.LogError("What are you even using this script for? lol");
                break;
        }
    }

    private void LockThemContent()
    {
        // Lock certain content
        foreach (GameObject content in contentToLock)
            content.SetActive(false);
    }
}
