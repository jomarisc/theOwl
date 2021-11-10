using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDialogue : MonoBehaviour
{

    // Dialogue
    public GameObject Dialogue;
    public TextAsset[] tutorialDialogueFiles;
    public int index;

    // Flag
    private bool hasEnteredBefore;

    // Player
    playerControl playerController;

    // Start is called before the first frame update
    void Start()
    {
        hasEnteredBefore = false;
        playerController = GameObject.Find("player").GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out playerControl p) && !hasEnteredBefore) // Will enter if colliding and has not entered before
        {
            // Has now entered before
            hasEnteredBefore = true;
            playerController.Freeze();

            Debug.Log("Entered into InstantDialogue OnTriggerEnter2D");
            TextAsset currentDialogue = tutorialDialogueFiles[returnIndex()];

            string startArgument = "start";

            GameObject newDialogue = Instantiate(Dialogue);
            newDialogue.transform.SetParent(GameObject.Find("DialogueCanvas").transform);
            newDialogue.name = "Dialogue (" + currentDialogue.name + ")"; // dialogue
            DialogueManager dialogueManager = newDialogue.GetComponentInChildren<DialogueManager>();
            newDialogue.SetActive(true);

            dialogueManager.LoadNewDialogueText(currentDialogue, startArgument);
            dialogueManager.SetMessageIndex(0);
            dialogueManager.StartDialogue();

        }
    }

    public int returnIndex()
    {
        return index;
    }
}
