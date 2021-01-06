using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    private CutsceneCollider localCutsceneCollider;
    private Character[] characters;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This freezes Game Object Behaviors
    void StopCharacterBehaviors()
    {
        foreach (Character actor in characters)
        {
            actor.enabled = false;
        }
    }
}
