using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    private CutsceneCollider localCutsceneCollider;
    private Character[] characters;
    private GameObject gameplayCanvas;
    private GameObject cutsceneCanvas;

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
        gameplayCanvas = GameObject.Find("GameplayCanvas");
        cutsceneCanvas = GameObject.Find("CutsceneCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This freeze/unfreezes Game Object Behaviors
    void ToggleCharacterBehaviors(bool active)
    {
        foreach (Character actor in characters)
            actor.enabled = active;
    }

    // This swaps the HUD from GameplayCanvas to CutsceneCanvas and vice-versa
    void SwapCanvas()
    {
        // The two canvases should never be active at the same time,
        // so toggling both canvases should funciton the same as a swap
        gameplayCanvas.SetActive(!gameplayCanvas.activeInHierarchy);
        cutsceneCanvas.SetActive(!cutsceneCanvas.activeInHierarchy);
    }
}
