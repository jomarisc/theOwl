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
    public bool hasFinishedDialogueTutorial;

    // Player
    DialogueManager dialogueManager;
    playerControl playerController;

    // Start is called before the first frame update
    void Start()
    {
        hasFinishedDialogueTutorial = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerController = GameObject.Find("player").GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // Within DialogueManager.cs hasFinishedDialogueTutorial will be set to true
        if (hasFinishedDialogueTutorial)
        {
            // Player controller is unfrozen and respective controls are restored
            playerController.UnFreeze();
            playerController.input.Gameplay.MoveX.Enable();
            playerController.input.Gameplay.Jump.Enable();
            playerController.input.Gameplay.Glide.Enable();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out playerControl p) && !hasFinishedDialogueTutorial) // Will enter if colliding and has not entered before
        {
            // Set this to true when the dialogue manager finishes the last piece of text so that the player controls and input may be restored
            // hasFinishedDialogueTutorial = true;
            Debug.Log("Constantly in InstantDialogue trigger!");

            // Freeze player and left, right, up and down controls
            playerController.Freeze();
            playerController.input.Gameplay.MoveX.Disable();
            playerController.input.Gameplay.Jump.Disable();
            playerController.input.Gameplay.Glide.Disable();

            // Setup and start specific tutorial dialogue file
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
