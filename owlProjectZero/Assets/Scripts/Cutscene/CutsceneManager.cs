using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CutsceneAction
{
    public Character actor;
    public AnimationClip action;
}

[System.Serializable]
public struct CutsceneSequence
{
    public CutsceneAction[] directions;
}

public class CutsceneManager : MonoBehaviour
{
    private CutsceneCollider localCutsceneCollider;
    private Character[] characters;
    private Canvas gameplayCanvas;
    private Canvas cutsceneCanvas;
    public CutsceneSequence[] stageDirections; // The cutscene manager will iterate through this
                                               // array as the player progresses through the text

    void Awake()
    {
        // Get all character objects in the scene
        characters = GameObject.FindObjectsOfType<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Continue from here: 12/30/2020
        localCutsceneCollider = GetComponent<CutsceneCollider>();
        gameplayCanvas = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        cutsceneCanvas = GameObject.Find("CutsceneCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This freeze/unfreezes Game Object Behaviors
    public void ToggleCharacterBehaviors(bool active)
    {
        foreach (Character actor in characters)
            actor.enabled = active;
    }

    // This swaps the HUD from GameplayCanvas to CutsceneCanvas and vice-versa
    public void SwapCanvas()
    {
        // The two canvases should never be active at the same time,
        // so toggling both canvases should funciton the same as a swap
        gameplayCanvas.enabled = !gameplayCanvas.enabled;
        cutsceneCanvas.enabled = !cutsceneCanvas.enabled;
    }

    // This enables the CutsceneCanvas and disables the GameplayCanvas
    public void UseCutsceneCanvas()
    {
        gameplayCanvas.enabled = false;
        cutsceneCanvas.enabled = true;
    }
    
    // This enables the GameplayCanvas and disables the CutsceneCanvas
    public void UseGameplayCanvas()
    {
        cutsceneCanvas.enabled = false;
        gameplayCanvas.enabled = true;
    }
}
