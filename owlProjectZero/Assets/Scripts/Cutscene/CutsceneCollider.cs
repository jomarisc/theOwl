using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCollider : MonoBehaviour
{
    private CutsceneManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<CutsceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter() 
    {
        Debug.Log("Entered CutsceneCollider");
        manager.ToggleCharacterBehaviors(false);
        manager.UseCutsceneCanvas();
    }
}
