﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    [SerializeField] private DialogueManager txtManager = null;
    public float defaultVolume = 0f;
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public PlayerInputs input;
    public GameObject dialogue;
    public CutsceneSequence[] stageDirections; // The cutscene manager will iterate through this
                                               // array as the player progresses through the text     
    public static event AudioFadeOut OnAudioFadeOut;
    public delegate void AudioFadeOut(float duration);

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
        // txtManager.OnNextMessage += NextSequence; // Moved to BeginDialogue()
    }

    void OnDisable()
    {
        // input.Cutscene.Proceed.started -= NextSequence;
        if(txtManager != null)    
            txtManager.OnNextMessage -= NextSequence;
        // input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Continue from here: 12/30/2020
        localCutsceneCollider = GetComponent<CutsceneCollider>();
        gameplayCanvas = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        cutsceneCanvas = GameObject.Find("CutsceneCanvas").GetComponent<Canvas>();
        // this.enabled = false;

        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Debug.Log("PlayerPrefs musicVolume does exist");
            float getVolume = PlayerPrefs.GetFloat("musicVolume");
            // Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
            musicMixer.SetFloat("musicVolume", getVolume);
            // Debug.Log("getVolume is " + getVolume);
            // Debug.Log("music slider value is " + mSlider.value);
            Debug.Log("music volume is " + PlayerPrefs.GetFloat("musicVolume"));
        }
        else
        {
            Debug.Log("PlayerPrefs musicVolume does not exist");
            PlayerPrefs.SetFloat("musicVolume", defaultVolume);
            PlayerPrefs.Save();
        }

        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            float getVolume = PlayerPrefs.GetFloat("sfxVolume");
            // Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));
            sfxMixer.SetFloat("sfxVolume", getVolume);
            // Debug.Log("sfx slider value is " + sSlider.value);
            Debug.Log("sfx volume is " + PlayerPrefs.GetFloat("sfxVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("sfxVolume", defaultVolume);
            PlayerPrefs.Save();
        }
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
        {
            this.gameObject.SetActive(false); // this.enabled = false;
            UseGameplayCanvas();
            ToggleCharacterBehaviors(true);
        }
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
            if(actor != null)
                actor.enabled = active;
    }

    // This swaps the HUD from GameplayCanvas to CutsceneCanvas and vice-versa
    public void SwapCanvas()
    {
        // The two canvases should never be active at the same time,
        // so toggling both canvases should funciton the same as a swap
        gameplayCanvas.gameObject.SetActive(!gameplayCanvas.gameObject.activeInHierarchy);
        cutsceneCanvas.gameObject.SetActive(!cutsceneCanvas.gameObject.activeInHierarchy);
    }

    // This enables the CutsceneCanvas and disables the GameplayCanvas
    public void UseCutsceneCanvas()
    {
        if(gameplayCanvas != null && gameplayCanvas.gameObject.activeInHierarchy)
            gameplayCanvas.gameObject.SetActive(false);
        if(cutsceneCanvas != null)
            cutsceneCanvas.gameObject.SetActive(true);
        NextSequence();
    }
    
    // This enables the GameplayCanvas and disables the CutsceneCanvas
    public void UseGameplayCanvas()
    {
        if(cutsceneCanvas != null && cutsceneCanvas.gameObject.activeInHierarchy)
            cutsceneCanvas.gameObject.SetActive(false);
        if(gameplayCanvas != null)
            gameplayCanvas.gameObject.SetActive(true);
    }

    public void BeginDialogue(TextAsset dialogueScript)
    {
        string startArgument = "start";
        txtManager.OnNextMessage += NextSequence;
        txtManager.LoadNewDialogueText(dialogueScript, startArgument);
        txtManager.SetMessageIndex(0);
        txtManager.StartDialogue();
    }

    public void SpawnNewDialogue()
    {
        GameObject newDialogue = Instantiate(dialogue);
        newDialogue.transform.SetParent(GameObject.Find("DialogueCanvas").transform);
        newDialogue.name = "Dialogue (" + dialogue.name + ")";
        DialogueManager dialogueManager = newDialogue.GetComponentInChildren<DialogueManager>();
        txtManager = dialogueManager;
        txtManager.OnNextMessage += NextSequence;
        newDialogue.SetActive(true);
    }

    public void SignalAudioFadeOut(float duration)
    {
        OnAudioFadeOut?.Invoke(duration);
    }
}
