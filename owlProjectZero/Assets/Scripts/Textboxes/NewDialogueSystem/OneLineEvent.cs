// This script is for firing a Unity event after one line of dialogue

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneLineEvent : MonoBehaviour
{
    [SerializeField] private DialogueManager txtManager = null;
    public UnityEvent performThese = null;

    private void OnEnable()
    {
        txtManager.OnNextMessage += FireEvent;
    }

    private void OnDisable()
    {
        txtManager.OnNextMessage -= FireEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireEvent()
    {
        performThese.Invoke();
    }

    public void OpenOneLiner(TextAsset csv)
    {
        string startArgument = "start";
        txtManager.gameObject.SetActive(true);
        
        txtManager.LoadNewDialogueText(csv, startArgument);
        txtManager.SetMessageIndex(0);
        txtManager.StartDialogue();
    }
}
