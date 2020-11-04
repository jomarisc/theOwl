using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        // Note: When sound is needed, uncomment this code
        talkingAudioSource = transform.Find("messageSound").GetComponent<AudioSource>();
        
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

        messageArray = new string[]
        {
            "Oh yeah no worries, help get the food. Ok. Gonna make a new scene with visuals of the text box. Ok Bye. bye",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.",
            "Hey there!",
            "This is a really cool and useful effect",
            "The textbox is typing itself",
            "Did you know that this text is typing itself?",
        };

        message = messageArray[Random.Range(0, messageArray.Length)];

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
                message = messageArray[Random.Range(0, messageArray.Length)];
                // Note: When sound is needed uncomment this code
                //talkingAudioSource.Play();
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.025f, true, true, StopTalkingSound);
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

    void Start()
    {
        input = GameObject.Find("player").GetComponent<playerControl>().input;
        //messageText.text = "Hello world!";
        //textWriter.AddWriter(messageText, "Hello World!", 1f);
        //textWriter.AddWriter(messageText, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.", .1f, true);
        //TextWriter.AddWriter_Static(messageText, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pretium mi id consequat imperdiet. Curabitur blandit odio dolor, at pellentesque nibh porttitor sit amet. In fringilla vestibulum felis sed facilisis.", .1f, true);
    }
}
