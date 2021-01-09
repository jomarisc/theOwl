using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public struct CutsceneAction
{
    public Character actor;
    public AnimationClip action;
}

[System.Serializable]
public struct CutsceneSequence
{
    // public Vector3 cameraPosition;
    // public Vector3 cameraAngle;
    public CutsceneAction[] directions;
}

public class CutsceneManager : MonoBehaviour
{
    private int currentStageDirection = 0;
    private CutsceneCollider localCutsceneCollider;
    private Character[] characters;
    private Canvas gameplayCanvas;
    private Canvas cutsceneCanvas;
    public PlayerInputs input;
    public CutsceneSequence[] stageDirections; // The cutscene manager will iterate through this
                                               // array as the player progresses through the text

    void Awake()
    {
        // Get all character objects in the scene
        characters = GameObject.FindObjectsOfType<Character>();
        input = new PlayerInputs();
    }

    void OnEnable()
    {
        input.Enable();
        input.UI.Activate.started += NextSequence;
    }

    void OnDisable()
    {
        input.UI.Activate.started -= NextSequence;
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
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySequence(int stageDirection)
    {
        CutsceneAction[] directions = stageDirections[stageDirection].directions;
        foreach (CutsceneAction direction in directions)
        {
            string myAction = direction.action.name;
            Animator myAnimator = direction.actor.animator;
            if(myAnimator == null)
                Debug.Break();
            myAnimator.Play(myAction);
            Debug.Log(myAnimator.gameObject.name + " is performing " + myAction);
        }
        // for(int i = 0; i < directions.Length; i++)
        // {
        //     string action = directions[i].action.name;
        //     directions[i].actor.GetComponent<Animator>().Play(action);
        // }
    }

    private void NextSequence(InputAction.CallbackContext context)
    {
        if(currentStageDirection == stageDirections.Length)
            this.enabled = false;
        else
        {
            PlaySequence(currentStageDirection);
            currentStageDirection++;
        }
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
