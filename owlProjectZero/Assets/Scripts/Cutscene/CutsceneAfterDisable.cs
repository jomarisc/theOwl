using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneAfterDisable : MonoBehaviour
{
    [SerializeField] private CutsceneManager cutsceneManager = null;
    void OnDisable()
    {
        Debug.Log("Triggering cutscene");
        cutsceneManager.enabled = true;
        cutsceneManager.ToggleCharacterBehaviors(false);
        cutsceneManager.UseCutsceneCanvas();
    }
}
