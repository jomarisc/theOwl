using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    //[SerializeField] private TextWriter textWriter;
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private PlayerInputs input;
    public string[] messageArray;
    public string message;
    private int messageIndex;

    private GameObject textbox;
    [SerializeField] private TextAsset messageFile;
    public bool manualActivation;
    public event EventDelegate OnNextMessage;
    public delegate void EventDelegate();
    [SerializeField] private bool canFireNextMessageEvent = true;

    // Start is called before the first frame update
    void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        // New
        textbox = GameObject.Find("message");
        // Note: When sound is needed, uncomment this code
        talkingAudioSource = transform.Find("messageSound").GetComponent<AudioSource>();

        input = new PlayerInputs();
        
        // Code Monkey Reference Code
        //transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
        //if(input.Gameplay.Interact.triggered)
        /*
        {
            string[] messageArray = new string[]
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.",
                "Hey there!",
                "This is a really cool and useful effect",
                "The textbox is typing itself",
                "Did you know that this text is typing itself?",
            };

            string message = messageArray[Random.Range(0, messageArray.Length)];
            TextWriter.AddWriter_Static(messageText, message, 0.1f, true);
        };
        */
        
        /* Old way of loading in a message
        messageArray = new string[]
        {
            "Oh yeah no worries, help get the food. Ok. Gonna make a new scene with visuals of the text box. Ok Bye. bye",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.",
            "Hey there!",
            "This is a really cool and useful effect",
            "The textbox is typing itself",
            "Did you know that this text is typing itself?",
        };
        */

        // New way of loading in a message
        // messageArray = File.ReadAllLines("../owlProjectZero/Assets/Scripts/Textboxes/Dialogue/text_1.txt");
        
        //message = messageArray[Random.Range(0, messageArray.Length)];
        //messageLastIndex = (messageArray.Length) - 1;
        messageIndex = 0;
        // Debug.Log(messageFile);
        messageArray = messageFile.text.Split('\n');
        message = messageArray[messageIndex];
    }

    void OnEnable()
    {
        input.Enable();
        if(!manualActivation)
        {
            SetMessageAndPlay();
        }
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        if (input.Gameplay.Interact.triggered)
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                // Upon pressing interact button, set textbox to active
                textbox.SetActive(true);

                //message = messageArray[Random.Range(0, messageArray.Length)];
                //Debug.Log("messageArray.Length" + messageArray.Length);
                //Debug.Log("BEFORE messageIndex: " + messageIndex);
                //Debug.Log("AFTER messageIndex: " + messageIndex);
                
                
                SetMessageAndPlay();
                if(canFireNextMessageEvent)
                    OnNextMessage?.Invoke();
            }
        }
    }

    // Functions to use once a sound file has been loaded
    private void StartTalkingSound()
    {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }

    public void ToggleCanFireNextMessageEvent(bool enabled)
    {
        canFireNextMessageEvent = enabled;
    }

    public void SetMessageIndex(int index)
    {
        messageIndex = index;
    }

    public void SetMessageAndPlay()
    {
        //Set message to a specific position in the array 
        message = messageArray[messageIndex];
        // Check if current message is not the last message
        if (messageIndex < (messageArray.Length)-1) {
            // Increment position in the array to go to the next message
            messageIndex++;
        // If the current message is the last, reset message to the first message
        } 
        else if (messageIndex == (messageArray.Length)-1) {
            // Reset the message index
            messageIndex = 0;
            // Set textbox to not active after reaching last line
            textbox.SetActive(false);
        }
        
        // Note: When sound is needed uncomment this code
        //talkingAudioSource.Play();
        StartTalkingSound();
        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.025f, true, true, StopTalkingSound);
    }

    void Start()
    {
        // input = GameObject.Find("player").GetComponent<playerControl>().input;
        //messageText.text = "Hello world!";
        //textWriter.AddWriter(messageText, "Hello World!", 1f);
        //textWriter.AddWriter(messageText, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.", .1f, true);
        //TextWriter.AddWriter_Static(messageText, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.", .1f, true);
    }
}
