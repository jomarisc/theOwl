﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]
public struct CutsceneAction
{
    public Character actor;
    public AnimationClip action;
    public UnityEvent performThese;
}

[System.Serializable]
public struct Jumpcut
{
    public Transform obj;
    public Vector3 coordinates;
    public bool willRotate;
    public Vector3 rotation;
}

[System.Serializable]
public struct CutsceneSequence
{
    // public Vector3 cameraPosition;
    // public Vector3 cameraAngle;
    // public CutsceneAction[] directions;
    public UnityEvent performThese;
    // [Tooltip("This is for when Transform.LookAt() doesn't do the job")]
    // public Jumpcut[] jumpcuts;
}

public class CutsceneManager : MonoBehaviour
{
    private int currentStageDirection = 0;
    private CutsceneCollider localCutsceneCollider;
    private Character[] characters;
    private Canvas gameplayCanvas;
    private Canvas cutsceneCanvas;
    public PlayerInputs input;
    [SerializeField] private TextboxManager txtManager;
    public CutsceneSequence[] stageDirections; // The cutscene manager will iterate through this
                                               // array as the player progresses through the text

    void Awake()
    {
        // Get all character objects in the scene
        characters = GameObject.FindObjectsOfType<Character>();
        input = GameObject.Find("player").GetComponent<playerControl>().input;
    }

    void OnEnable()
    {
        input.Enable();
        // input.Cutscene.Proceed.started += NextSequence;
        txtManager.OnNextMessage += NextSequence;
    }

    void OnDisable()
    {
        // input.Cutscene.Proceed.started -= NextSequence;
        txtManager.OnNextMessage -= NextSequence;
        input.Disable();
        ToggleCharacterBehaviors(true);
        UseGameplayCanvas();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Continue from here: 12/30/2020
        localCutsceneCollider = GetComponent<CutsceneCollider>();
        gameplayCanvas = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        cutsceneCanvas = GameObject.Find("CutsceneCanvas").GetComponent<Canvas>();
        // this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySequence(int stageDirection)
    {
        stageDirections[stageDirection].performThese.Invoke();
        // Jumpcut[] jumpcuts = stageDirections[stageDirection].jumpcuts;
        // foreach(Jumpcut jumpcut in jumpcuts)
        // {
        //     // Teleport/Jumpcut the object to a specified coordinate
        //     jumpcut.obj.position = jumpcut.coordinates;
        //     // Rotate the object if necessary
        //     if(jumpcut.willRotate)
        //         jumpcut.obj.eulerAngles = jumpcut.rotation;
        // }
        // CutsceneAction[] directions = stageDirections[stageDirection].directions;
        // foreach (CutsceneAction direction in directions)
        // {
        //     // string myAction = direction.action.name;
        //     // Animator myAnimator = direction.actor.animator;
        //     // if(myAnimator == null)
        //     //     Debug.Break();
        //     // myAnimator.Play(myAction);
        //     // Debug.Log(myAnimator.gameObject.name + " is performing " + myAction);
        //     direction.performThese.Invoke();
        // }
        // for(int i = 0; i < directions.Length; i++)
        // {
        //     string action = directions[i].action.name;
        //     directions[i].actor.GetComponent<Animator>().Play(action);
        // }
    }

    private void NextSequence()
    {
        if(currentStageDirection == stageDirections.Length)
            this.enabled = false;
        else
        {
            PlaySequence(currentStageDirection);
            currentStageDirection++;
        }
    }

    // Callback function for when you want to proceed to
    // the next cutscene sequence after detecting player input
    private void NextSequence(InputAction.CallbackContext context)
    {
        NextSequence();
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
        NextSequence();
    }
    
    // This enables the GameplayCanvas and disables the CutsceneCanvas
    public void UseGameplayCanvas()
    {
        cutsceneCanvas.enabled = false;
        gameplayCanvas.enabled = true;
    }
}