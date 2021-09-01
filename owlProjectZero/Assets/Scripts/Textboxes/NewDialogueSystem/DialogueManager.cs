
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //must be imported to use textmeshpro
using UnityEngine.EventSystems;
//using Sirenix.OdinInspector;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour 
{
    [SerializeField] bool DebugMode = false; //functions that only activate for debugging purposes.

    [SerializeField] int frameRateLimit = 400; //limit is 300

    [Header("Main")]
    [SerializeField] string[] messageArrayRaw;
    public string[] messageArrayFull;                                                   // Array that holds all the lines of message (complete)
    public string[] messageArraySeg;                                                    // Array that holds all the lines of message (segmented)
    public int messageIndex;                                                            // messageArray's index
    public string messageCurrent;                                                       // Sting that holds onto the current line of messageArray
    public List<string> storyTags;
    private TextWriter.TextWriterSingle textWriterSingle;
    
    // MOCHA MAGIC CODE 
    public CharacterDatabase storyCharacters;
    [SerializeField] public CharacterObject testPigeon;
    public BackgroundDatabase backgroundDatabase;
    public VNVariables variableDatabase;
    
    // MOCHA MAGIC CODE
    private Dictionary<string, CharacterObject> activeCharacters;
    [Header("Dialogue Timing")]

    [SerializeField] float startMessageWait =  0.3f;                                    //how many seconds player needs to wait before they can confirm
    [SerializeField] float endMessageWait =  0.2f;                                      //how long the end message lingers before they confirm button can occur
    public float timePerCharacter = 0.025f;
    private string currentTextSpeed = "normal";

    [SerializeField] float fastTextSpeed = 0.00f;
    [SerializeField] const float normalTextSpeedBase = 0.019f;
    [SerializeField] float normalTextSpeed = normalTextSpeedBase;
    [SerializeField] float slowTextSpeed = 0.058f;
    [SerializeField] float slowerTextSpeed = 0.09f;

    [SerializeField] float autoTextWaitTime = 3.0f;

    private bool startMessageTimerActive = false;
    private bool endMessageTimerActive = false;

    // OWL LONG DAY EXCLUSIVE CODE
    public bool manualActivation;
    public event EventDelegate OnNextMessage;
    public delegate void EventDelegate();
    [SerializeField] private bool canFireNextMessageEvent = true;

    [Header("UI Objects")]
    //changed  textbox, message text and message name to public to avoid null error exceptions 
    [SerializeField] GameObject mainObject;
    [SerializeField] GameObject textbox;                                                // Stores game object called message

    [SerializeField] GameObject MCImage;                                                // Game object that holds the MC image
    [SerializeField] GameObject npcPrefab;                                              // stores prefab for npc sprites
    [SerializeField] GameObject backgroundPrefab;                                       //stores prefab for background images
    public GameObject floatingMarker;                                                   //stores GameObject for end of message marker

    // MOCHA MAGIC CODE
    // OLD CODE:
    // Used for implementing a backlog
    // private BacklogView backlogView; //script for backlog
    [SerializeField] GameObject settingsMenu;

    [SerializeField] Sprite blankImage;

    [SerializeField] Color greyOutColor;
    [SerializeField] Color optionsWhite;
    [SerializeField] Color optionsBlack;
    private GameObject currentBackground;
    private GameObject currentCG;

    // MOCHA MAGIC CODE
    public Dictionary<string, GameObject> npcsInScene = new Dictionary<string, GameObject>();
    
    private List<GameObject> npcsInSceneList = new List<GameObject>();

    [SerializeField]  TMP_Text messageText;                                                       // Game object that hold's the textbox's body text
    [SerializeField]  TMP_Text messageName;                                                       // Game object that holds the textbox's character name
    
    [SerializeField] TMP_Text noVoiceButtonText;
    [SerializeField] TMP_Text autoButtonText;

    [Header("Audio")]

    // OLD CODE:
    // Storing audio files
    //[SerializeField] AudioSource talkingAudioSource;
    private AudioSource talkingAudioSource; //audio source is now attached to the object
    //[SerializeField] Dictionary<string, AudioClip> dialogueAudio;
    //public AudioClip soundClip1;

    public SoundLibrary soundLibrary;
    
    // MOCHA MAGIC CODE
    //private CraftingMusic musicController;

    //other
    private string currentSpeaker;
    private bool textboxVisible;
    private bool canUseTextboxKeys = false;
    private bool canChangeHide = true;
    private bool charaVoicesOn = true;
    private bool autoText = false;
    private bool autoTextTimerOn = false;

    private float hangTime = 0f;

    private bool inHangTime = false;
    private string songToPlay = "";
    private bool playSong;

    [Header("Other")]
    [SerializeField] string MCName = "Machi";

    [SerializeField] string commentLead = "//";

    [SerializeField] private string jumpToLabel = "";
    public static bool isTextFrozen;

    private bool willJumpLabel = false;
    private bool willMakeOrder = false;
    
    // MOCHA MAGIC BEHAVIOR
    //[ReadOnly] [SerializeField] List<ActivatedFlagsDay> storyFlagsActivated; 
    //private StoryActivator storyActivator;
    //private DaySystem daySystem;
    
    // Reference to player script
    //private MCBehavior mcBehavior;
    private PlayerInputs input;

    private string endingType;

    // MOCHA MAGIC CODE
    [SerializeField] List<GameObject> overworldNPCs;

    void Awake()
    {
        //Debug.Log(message: $"<color=blue><size=16>From DIALOGUE MANAGER.CS souncClip1 name: {soundClip1.name} </size></color>");
        
        //textbox.SetActive(false);
        // Commented out recently - 7/28/2021
        HideDialogue(); 
        // Sets variables for interacting with textbox
        //set time per character to mid text speed
        timePerCharacter = normalTextSpeed;
        // Load in sound file for playing 
        talkingAudioSource = this.GetComponent<AudioSource>();
        
        input = new PlayerInputs();

        // MOCHA MAGIC CODE
        //backlogView = transform.Find("backlogHolder/MainPanel").GetComponent<BacklogView>();
        
        messageIndex = 0;

        // OLD CODE:
        // Testing out CreateInstance with a ScriptableObject
        // storyCharacters = (CharacterDatabase) ScriptableObject.CreateInstance("CharacterDatabase");
        
        // OLD CODE:
        // Setting up soundLibrary
        // soundLibrary.AddingAudioIntoNewDict();
        // soundLibrary.TestAddingAudioIntoNewDict();
        soundLibrary.SettingAudioIntoLocalDict();

        // MOCHA MAGIC CODE
        // get active characters through the dictionary retrieval function CharacterNameDict() // Continue from here - 7/23/2021
        // this is of type Dictionary<string,CharacterObject>
        activeCharacters = storyCharacters.CharacterNameDict();
        
        // OLD CODE:
        // Testing if key exists in dictionary
        //Dictionary<string, CharacterObject>.KeyCollection keys = activeCharacters.Keys;
        // if(activeCharacters.ContainsKey("Pigeon Dude")) // storyCharacters._Keys activeCharacters.ContainsKey("Pigeon Dude"), storyCharacters._Keys.Contains(storyCharacters.SampleCharacter)
        // {
        //     Debug.Log("Pigeon Dude key found in dictionary");
        // } else {
        //     Debug.Log("Pigeon Dude key NOT found");
        // }

        // OLD CODE:
        // Trying to print out each string key in a dictionary
        // foreach(string key in keys)
        // {
        //     Debug.Log(message:$"<color=green><size=16> Key: {key} </size></color>");
        // }

        // MOCHA MAGIC CODE
        /*
        GameObject.Find("DaySystem").GetComponent<DaySystem>().TurnUIOff(); //return ui elements
        if(GameObject.Find("MusicGameObject") == null){
            Debug.LogError("No music controller object prefab! Add it please uwu");
        }else if(GameObject.Find("MusicGameObject").transform.GetComponentInChildren<CraftingMusic>() != null){
            musicController = GameObject.Find("MusicGameObject").transform.GetComponentInChildren<CraftingMusic>();
        }        

        storyActivator = GameObject.Find("DaySystem").GetComponent<StoryActivator>();
        daySystem = GameObject.Find("DaySystem").GetComponent<DaySystem>();
        mcBehavior = GameObject.Find("MCGameObjectScene").transform.GetChild(0).GetComponent<MCBehavior>();
        */

        /*for(int i = 0; i < GameObject.Find("NPCGameObjectScene").transform.childCount; i++){
            overworldNPCs.Add(GameObject.Find("NPCGameObjectScene").transform.GetChild(i).gameObject);
        }*/
        
        // MOCHA MAGIC CODE
        //overworldNPCs = GetAllActiveNPCS();
        
        //limit framerate if working in debug mode
        if(DebugMode){
            Application.targetFrameRate = frameRateLimit;
        }
        //UpdateTextSpeedForFramerate();
        /*if(daySystem.currentDay.dayNumber > storyCharacters.FinalDay){
           if(daySystem.endingType == "CG"){

           }else{

           }
        }*/
        
    }

    private List<GameObject> GetAllActiveNPCS(){
        List<GameObject> activeNPCs = new List<GameObject>();
        for(int i = 0; i < GameObject.Find("NPCGameObjectScene").transform.childCount; i++){
            activeNPCs.Add(GameObject.Find("NPCGameObjectScene").transform.GetChild(i).gameObject);
        }
        return activeNPCs;
    }

    public void UpdateTextSpeedForFramerate(){
        int cutoff = 200;
        int cutoff2 = 90;
        float multiplier = normalTextSpeedBase;
        /*if(Application.targetFrameRate <= 80){
            multiplier = multiplier * 0.1f;
        }*/
        /*if(Application.targetFrameRate <= cutoff2){
            multiplier = multiplier * 0.5f;
        }
        if(Application.targetFrameRate <= cutoff3){
            multiplier = multiplier * 0.5f;
        }*/
        for(int i = cutoff2; i > 1.0/Time.deltaTime; i--){
            multiplier = multiplier - 0.001f;
        }
        if(1.0/Time.deltaTime <= cutoff){
            //Debug.LogWarning("damn!!!! this machine so slow!");
            //normalTextSpeed = normalTextSpeedBase * multiplier;
            normalTextSpeed = multiplier;
            UpdateTextSpeed(currentTextSpeed);
        }
        //Debug.Log($"Framerate: {Application.targetFrameRate}");
    }

    // OWL LONG DAY CODE
    // OnEnable() and OnDisable() are potentially used in managing
    // textboxes in Cutscenes
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


    public void Update()
    {
        //first off
        //UpdateVoiceSwitch();

        // Format for Unity New Input System: input.Gameplay.Interact.triggered
        //the click was removed to tie it to the button attached to the textbox, which is why progress story is now its own function
        
        // MOCHA MAGIC CODE
        // Until CreateSettingsMenu is sorted out, comment this check out - 6/26/2021
        // VNBacklog is commented out until further notice.
        //if(!CreateSettingsMenu.VNFreeze){
            if (input.Dialogue.ProgressStory.triggered && textboxVisible) // Old input: Input.GetKeyDown("space") && textboxVisible, Continue working on testing the new input system
            {
                //EventSystem.current.SetSelectedGameObject(null); //unselect all buttons?
                ProgressStory();
            }
            //DEBUG
            if (input.Developer.Debug.triggered && DebugMode) // Input.GetKey("y")
            {
                //StartCoroutine(DestroyingDialoguePrefab());
               
               
               
                //StartCoroutine(DestroyDialogueObject());
            }
            if(input.Dialogue.HideTextbox.triggered && canChangeHide){ //hide from button, Input.GetKeyDown(KeyCode.H)
                if(textboxVisible){
                    HideDialogue();
                }else if(!textboxVisible && canUseTextboxKeys){ //&& !backlogView.BacklogOpen()){ 
                    UnhideDialogue();
                }
            }
            if(input.Dialogue.ToggleVoice.triggered && canUseTextboxKeys && textboxVisible ){ //&& !backlogView.BacklogOpen()){ , Input.GetKeyDown(KeyCode.N)
                CharaVoiceSwitch();
            }
            if(input.Dialogue.ToggleBacklog.triggered && canUseTextboxKeys && textboxVisible){ // Input.GetKeyDown(KeyCode.B)
                // Disabled until Backlog is implemented
                //ToggleBacklog();
            }
            if(input.Dialogue.ToggleAutotext.triggered && canUseTextboxKeys && textboxVisible){ //&& !backlogView.BacklogOpen()){ // Input.GetKeyDown(KeyCode.A)
                AutoTextSwitch();
            }
            /*if(Input.GetKeyDown(KeyCode.S) && canUseTextboxKeys && textboxVisible && !backlogView.BacklogOpen()){
                InstantiateSettingsMenu();
            }*/
            if(input.Dialogue.UnhideWithMouse.triggered && canChangeHide){ //unhide with just mouse, Input.GetMouseButtonDown(0)
                if(!textboxVisible && canUseTextboxKeys){ // && !backlogView.BacklogOpen()){
                    UnhideDialogue();
                }
            }
        //} // This is from the first if statement check

        //auto mode

        //check if game is currently lingering on a complete message
        if(!inHangTime && !(textWriterSingle != null && textWriterSingle.IsActive()) ){ //if not in a wait function, 
            if(autoText && !autoTextTimerOn){ //if auto mode is on...
                StartCoroutine(autoModeTimer()); //start the timer
            }
        }


    }

    IEnumerator autoModeTimer(){
        autoTextTimerOn  =true;
        yield return new WaitForSeconds(autoTextWaitTime + endMessageWait);
        if(autoText){ //did you wait the 3 seconds without turning off?
            StartCoroutine(SetMessageAndPlay()); //congratulations! you can move on
        }
        autoTextTimerOn = false;
    }
    // Creates a text writer to type out text from CSV
    // Automatically sets AutoText to off
    public void ProgressStory(){
        // DEBUG:
        // Debug.Log(message:$"<color=yellow><size=16> Entered here!: </size></color>");
        //UpdateTextSpeedForFramerate();
        AutoTextOff();
        //StartTalkingSound();
        if(!inHangTime){
            if (textWriterSingle != null && textWriterSingle.IsActive()){
            // Currently active TextWriter
            // Writes the rest of the line and then removes writer after finishing
                if(!startMessageTimerActive){ //you need at least 0.3(?) seconds before this can proc
                    textWriterSingle.WriteAllAndDestroy();
                    StartCoroutine(endMessageTimerProc()); //hold on it before you can move on
                }
            }
            else
            {
                StartTalkingSound();
                // Starts a new textbox
                if(!endMessageTimerActive){
                    StartCoroutine(SetMessageAndPlay());
                    if(canFireNextMessageEvent)
                        OnNextMessage?.Invoke();
                }
            }
        }
    }

    // Completes a text message and destroys the textWriterSingle
    public void InterruptMessage(){
        if (textWriterSingle != null && textWriterSingle.IsActive()){
            textWriterSingle.JustDestroy();
        }
        StartCoroutine(SetMessageAndPlay());
    }

    // Plays a sound when textbox starts up
    // Currently commented out until it is needed
    private void StartTalkingSound()
    {
        //talkingAudioSource.Play();
        //PlaySoundEffect("messageOK", PlayerSettings.SFXVolume); // 5/12/2021 - Disabled intentionally for playtesting
        //new sound effect, replace with sfx volume in settings
    }

    IEnumerator startMessageTimerProc(){
        startMessageTimerActive = true;
        yield return new WaitForSeconds(startMessageWait);
        startMessageTimerActive = false;
    }
    IEnumerator endMessageTimerProc(){
        endMessageTimerActive = true;
        yield return new WaitForSeconds(endMessageWait);
        endMessageTimerActive = false;
    }

    public void playStorySoundEffectPublic(string audioReference, float waitTime){
        StartCoroutine(playStorySoundEffect(audioReference, waitTime));
    }

    // MOCHA MAGIC CODE.
    // Until settings menu is resolved this is commented out.
    private IEnumerator playStorySoundEffect(string audioReference, float waitTime){
        yield return new WaitForSeconds(waitTime);
        PlaySoundEffect(audioReference, 0); // Making this a fixed number till PlayerSettings is resolved. Previously: PlayerSettings.SFXVolume
    }
    
    // MOCHA MAGIC CODE. 
    // Return to when music controller is resolved.
    public void UpdateMusicInVN(string newSong){
        //musicController.UpdateSong(newSong);
    }

    // MOCHA MAGIC CODE. 
    // Return to when music controller is resolved.
    public void StopMusicInVN(){
        //musicController.StopSong();
    }

    // Function for playing specific sound
    private void PlaySoundEffect(string soundToPlay, float volume){
        if(soundLibrary.AudioDict.ContainsKey(soundToPlay)){
            AudioSource.PlayClipAtPoint(soundLibrary.AudioDict[soundToPlay], Camera.main.transform.position, volume);
        }else{
            Debug.LogError($"Sound {soundToPlay} not registered!");
        }
    }
    
    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }

    public void SetMessageIndex(int index)
    {
        messageIndex = index;
    }

    //changing this to ienumerator to experiment with something
    IEnumerator SetMessageAndPlay()
    {
        //yield return new WaitForSeconds(0.8f);

        //make the exit condition up here
        if(messageIndex > (messageArraySeg.Length-1)){
            messageIndex = 0;                                           // Reset the message index
            // This destroys the DialogueObject upon completing CSV
            // Watch this carefully to determine if dialogue arc progression is maintained
            StartCoroutine(DestroyDialogueObject());                                                              
            //this.gameObject.SetActive(false);  //i think this is what we need? since we activate this on a trigger we need to deactivate it as well
            //StartCoroutine(DestroyingDialoguePrefab()); //-matt
            
        }else{

            
            // Assume potential character name is nothing
            string potentialCharacterName = ""; 
        
            //loop mesasge index until you get a line with a player
            canUseTextboxKeys = false;
            //Debug.Log($"{messageArraySeg[messageIndex].Substring(0,1)} vs {messageIndex} and {messageArraySeg.Length}");
            while(messageArraySeg[messageIndex].Trim().Substring(0,1) == "@"){ //while the message you get is still a command
                //Debug.Log("<color=green>going ghost!</color>");
                //where the command functions which end go to do their thing
                //Debug.Log($"<color=green>call:{messageArray[messageIndex].Substring(0,1)} at line {messageIndex}</color>"
                
                //there can only be one wait as there can only be one end. if jump happened wait wouldnt be here and hang time would be zero
                
                inHangTime = true;
                yield return new WaitForSeconds(hangTime);
                inHangTime = false;
                hangTime = 0; //reset hangtime

                if(playSong){
                    Debug.Log("Change Music!");
                    UpdateMusicInVN(songToPlay);
                    playSong = false;
                }

                if(willJumpLabel){
                    //rebuild segment to start from new label and end at end

                    //messageArraySeg = new string[](LoadDialogueTextFromStartToEnd(messageArrayFull, jumpToLabel));
                    //Debug.Log($"Jumping in! {jumpToLabel}");
                    messageArraySeg = LoadSegmentedMessageArray(messageArrayFull, jumpToLabel);
                    
                    //LoadDialogueTextFromStartToEnd(messageArrayFull, jumpToLabel);
                    //start back at the top, seg always starts on top
                    messageIndex = 0;
                    willJumpLabel = false;
                }

                /*if(willMakeOrder){
                    mcBehavior.activateDrinkPanel();
                    Debug.Log("Turn them off NOW");
                    willMakeOrder = false;
                    messageIndex++;
                    //Destroy(mainObject);
                }*/

                //load next line of command messages
                messageIndex = AttemptToChangeMessageIndex(messageIndex);

                if(messageIndex > messageArraySeg.Length-1){
                    //messageIndex = messageArraySeg.Length-1;
                    messageIndex = messageArraySeg.Length;
                    //break;
                    messageIndex = 0;                                           // Reset the message index
                    //StartCoroutine(DestroyDialogueObject());                                                              
                    //this.gameObject.SetActive(false);  //i think this is what we need? since we activate this on a trigger we need to deactivate it as well
                    StartCoroutine(DestroyingDialoguePrefab()); //-matt
                }

            }
            canUseTextboxKeys = true;

            messageCurrent = messageArraySeg[messageIndex];                           // Sets message again to a specific position in the array. This may skip over lines with #
        
            // Checks if a colon exists in message and will attempt to update character name
            messageCurrent = AttemptToUpdateCharacterName(messageCurrent, potentialCharacterName);

            //find variables in messageCurrent
            messageCurrent = findAndReplaceVariables(messageCurrent);

            messageIndex++;

            // Change the colors of the sprites
            HighlightSpeaker(currentSpeaker);

            //test
            UnhideDialogue(); //unhides dialogue box (for if first line isn't dialogue (ex:if waiting)). has no effect otherwise bc you wouldn't be here if hidden
            StartCoroutine(startMessageTimerProc());
            textWriterSingle = TextWriter.AddWriter_Static(messageText, messageCurrent, timePerCharacter, true, true, StopTalkingSound, currentSpeaker);
            yield return new WaitForSeconds(0); 
        }
    
    }
    public string findAndReplaceVariables(string messageCur){

        int pointer = 0;
        char frontTag = '{';
        char backTag = '}';
        int count = messageCur.Length;
        while(pointer < messageCur.Length){
            count = messageCur.Length- pointer;
            int findFront = messageCur.IndexOf(frontTag, pointer, count);
            if(findFront == -1){
                break;
            }else{
                count = messageCur.Length - findFront;
                int findBack = messageCur.IndexOf(backTag, findFront, count);
                if(findBack == -1){
                    break;
                }else{
                    //Debug.Log($"from {findFront} to {findBack}...");
                    //Debug.Log($"variable caught! {messageCur.Substring(findFront, findBack-findFront+1)}");
                    string varString = messageCur.Substring(findFront+1, findBack-findFront-1);
                    /*************************************************
                        DISABLED UNTIL WE CAN USE VNVariables
                    *************************************************/
                    //Debug.Log($"variable caught! {varString}");
                    // if(variableDatabase.stringVariables.ContainsKey(varString)){
                    //     Debug.Log("in variable database!");
                    //     string replaceText = variableDatabase.stringVariables[varString];
                    //     messageCur = messageCur.Replace(messageCur.Substring(findFront, findBack-findFront+1), replaceText);
                    // }
                    pointer = findBack+1;
                }
            }

        }
        return messageCur;
    }

    //alternative function to Disable which destroys prefab
    /*private void DestroyDialoguePrefab(){

        if(currentBackground != null){
            DestroyBackground();
        }
        
        GameObject.Find("DaySystem").GetComponent<DaySystem>().TurnUIOn(); //return ui elements

        //put flag in 

        if(willMakeOrder){
            Debug.Log("Order up!");
            mcBehavior.activateDrinkPanel();
        }
        Destroy(transform.parent.gameObject); //destroy parent of dialogue manager
        MCMove.movementUnfreeze();
    }*/

    IEnumerator DestroyingDialoguePrefab(){
        // MOCHA MAGIC CODE, ISOLATED CHUNK PT.1
        // if(daySystem.currentDay.dayNumber > storyCharacters.FinalDay){
        //     if(daySystem.endingType == "CG"){
        //         Destroy(textbox);
        //         yield return new WaitForSeconds(7);
        //         currentCG.GetComponent<Image>().DOColor(Color.black, 2);
        //         yield return new WaitForSeconds(3);
                
        //     }else{
        //         //yield return new WaitForSeconds(1);
                Destroy(textbox);
                yield return new WaitForSeconds(2);
                foreach(var vnCharacter in npcsInScene){
                    DeleteCharacterFromScene(vnCharacter.Key);
                }
                currentBackground.GetComponent<Image>().DOColor(Color.black, 2);
                yield return new WaitForSeconds(3);

        // MOCHA MAGIC CODE, ISOLATED CHUNK PT.2
        //     }
        //     SceneManager.LoadScene("KillScene");
        //     /*Destroy(textbox);
        //     yield return new WaitForSeconds(7);
        //     currentCG.GetComponent<Image>().DOColor(Color.black, 2);
        //     yield return new WaitForSeconds(3);
        //     SceneManager.LoadScene("KillScene");*/
        // }else{
        //     if(currentBackground != null){
        //         DestroyBackground();
        //     }
            
        //     GameObject.Find("DaySystem").GetComponent<DaySystem>().TurnUIOn(); //return ui elements

        //     //put flag in 

        //     if(willMakeOrder){
        //         Debug.Log("Order up!");
        //         mcBehavior.activateDrinkPanel();
        //     }
        //     Destroy(transform.parent.gameObject); //destroy parent of dialogue manager
        //     MCMove.movementUnfreeze();
        //     yield return new WaitForSeconds(0);
        // }

        /*
        if(currentBackground != null){
            DestroyBackground();
        }
        
        GameObject.Find("DaySystem").GetComponent<DaySystem>().TurnUIOn(); //return ui elements

        //put flag in 

        if(willMakeOrder){
            Debug.Log("Order up!");
            mcBehavior.activateDrinkPanel();
        }
        Destroy(transform.parent.gameObject); //destroy parent of dialogue manager
        MCMove.movementUnfreeze();
        yield return new WaitForSeconds(0);
        */
    }

    IEnumerator DestroyDialogueObject(){
        if(currentBackground != null){
            yield return StartCoroutine(FadeBackground());
        }
        
        // MOCHA MAGIC CODE
        //GameObject.Find("DaySystem").GetComponent<DaySystem>().TurnUIOn(); //return ui elements

        //put flag in 

        if(willMakeOrder){
            Debug.Log("Order up!");

            //MOCHA MAGIC CODE
            //mcBehavior.activateDrinkPanel();

            //willMakeOrder = false;
            //messageIndex++;
            //Destroy(mainObject);
        }
        Destroy(transform.parent.gameObject); //destroy parent of dialogue manager
        
        //MOCHA MAGIC CODE
        //MCMove.movementUnfreeze();

        // Location for code to unfreeze player movement
    }

    private int AttemptToChangeMessageIndex(int index, bool waitCommand = false)
    {
        if(messageArraySeg[index].Trim().Substring(0,1) == "@"){
            //commandSwitch();
            //altered to fit with recursion
            
            string[] line = messageArraySeg[index].Split('@');
            string[] commandLines = line[1].Split('=');
            string command = commandLines[0].Trim();

            Debug.Log(message: $"<size=18> <color=orange> command: {command} </color> </size>");

            switch(command){
                case "wait":
                    //break the recursive loop, this is our last line.
                    hangTime = 0;
                    if(commandLines.Length > 1){
                        hangTime = float.Parse(commandLines[1].Trim());
                    }
                    return ++index;
                case "jumpTo":
                    //break the recursive loop, this is our last line. commandLines[1].Trim();
                    //Debug.Log("we have recieved the jump");
                    willJumpLabel = true;
                    jumpToLabel = commandLines[1].Trim();
                    //return ++index;
                    return index;
                case "sfx":
                    string[] soundCommand = commandLines[1].Trim().Split(',');
                    //Debug.Log("sound: " + soundCommand[0]);
                    float waitTime = 0f;
                    if(soundCommand.Length > 1){
                        waitTime = float.Parse(soundCommand[1]);
                    }
                    StartCoroutine(playStorySoundEffect(soundCommand[0], waitTime));
                    break;
                case "music":
                    //Debug.Log($"now playing {commandLines[1].Trim()}");
                    //musicController.UpdateSong(commandLines[1].Trim());
                    //UpdateMusicInVN(commandLines[1].Trim());
                    //break;
                    songToPlay = commandLines[1].Trim();
                    playSong = true;

                    //Debug.Log("Return Music Index - " + index);
                    //index = index+1;
                    return ++index;
                case "stopMusic":
                    StopMusicInVN();
                    break;
                case "icon":
                    changeMCPortrait(commandLines[1].Trim());
                    break;
                case "hideIcon":
                    MCImage.SetActive(false);
                    break;
                case "char":
                    CreateOrUpdateCharacter(commandLines);
                    break;
                case "move":
                    string[] moveArguments = commandLines[1].Trim().Split(',');
                    Vector3 posToMove = new Vector3(
                        float.Parse(moveArguments[1].Trim()), float.Parse(moveArguments[2].Trim()), 0);
                    //Debug.Log($"{npcsInScene[moveArguments[0]]} moves to {posToMove}");
                    MoveCharacterPos(npcsInScene[moveArguments[0]], posToMove, 0.3f);
                    break;
                // MOCHA MAGIC CODE
                // case "orderDrink":
                //     string[] drinkArguments = commandLines[1].Trim().Split(',');
                //     string charName = drinkArguments[0];
                //     List<string> drinkTraits = drinkArguments.OfType<string>().ToList(); // this isn't going to be fast.
                //     drinkTraits.RemoveAt(0);
                //     //remove nulls
                //     drinkTraits  = drinkTraits.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                //     //Debug.Log($"List of size {drinkTraits.Count}");
                //     mcBehavior.AddOrder(charName, drinkTraits);
                //     break;
                // case "serveDrink":
                //     Debug.Log("Serving Drink!");
                //     //mcBehavior.activateDrinkPanel();
                //     willMakeOrder = true;
                //     //return index;
                //     //return ++index;
                //     break;
                // case "drinkStory":
                //     string newDrinkStoryLine = commandLines[1];
                //     AddToDrinkStory(newDrinkStoryLine);
                //     break;
                case "leave":
                    string charToDelete = commandLines[1].Trim();
                    /*if(!npcsInScene.ContainsKey(charToDelete)){
                        Debug.LogError("Cannot make a character not in the scene leave! -Matt");
                        break;
                    }*/
                    DeleteCharacterFromScene(charToDelete);
                    break;
                case "background":
                    UpdateBackground(commandLines, "fade");
                    break;
                case "noFadeBackground":
                    UpdateBackground(commandLines, "noFade");
                    break;
                case "hideBackground":
                    DestroyBackground();
                    break;
                case "hideTextbox":
                    HideTextbox();
                    break;
                case "returnTextbox":
                    RestoreTextbox();
                    break;
                case "CG":
                    NewCG(commandLines, "fade");
                    break;
                case "instantCG":
                    NewCG(commandLines, "noFade");
                    break;
                case "hideCG":
                    DestroyCG();
                    break;
                case "textSpeed":
                    string textSpeed = commandLines[1].Trim();
                    UpdateTextSpeed(textSpeed);
                    break;
                case "despawn":
                    string[] charsToDespawn = commandLines[1].Trim().Split(',');
                    DespawnNPCs(charsToDespawn);
                    break;
                case "despawnNPCs":
                    DespawnAllNPCs();
                    break;
                case "spawn":
                    string[] charsToSpawn = commandLines[1].Trim().Split(',');
                    SpawnNPCs(charsToSpawn, NPCStatus.Customer);
                    break;
                case "spawnVisitor":
                    string[] visitorsToSpawn = commandLines[1].Trim().Split(',');
                    SpawnNPCs(visitorsToSpawn, NPCStatus.Visitor);
                    break;
                //MOCHA MAGIC CODE
                // case "endDay":
                //     EndDay();
                //     break;
                // case "flag":
                //     Debug.Log("Forcing Flag");
                //     ForceFlag(commandLines[1].Trim());
                //     break;
                case "incrementArc":
                    //MOCHA MAGIC CODE
                    // string[] arcsToIncrement = commandLines[1].Trim().Split(',');
                    // foreach(string character in arcsToIncrement){
                    //     daySystem.arcChanges[character]++;
                    // } 
                    
                    break;
                default:
                    Debug.LogWarning("Invalid Script Command!");
                    break;
            }
            

            //RECURSION TIME LETS GOOOOOOO
            //Debug.Log($"<color=red>yone e in: {messageIndex}</color>");
            index++;
            int finalInt = AttemptToChangeMessageIndex(index, waitCommand);
            //Debug.Log($"<color=red>yone e out: {finalInt}</color>");
            return finalInt;
        }else if(messageArraySeg[index].Trim().Substring(0,1) == "#"){ //title
            index++;
            //continute the chain
            int finalInt = AttemptToChangeMessageIndex(index, waitCommand);
            //Debug.Log($"<color=red>yone e out: {finalInt}</color>");
            return finalInt;
        //find flag conditionals
        }else {
            //Debug.Log("<color=red>yone r!</red>");
            return index; //the message is not a command
        }
    }

    /* MOCHA MAGIC CODE

    public void EndDay(){
        storyActivator.activateFlag("giveDrink");
    }

    public void ForceFlag(string flag){
        Debug.Log($"Force Flag - {flag}");
        storyActivator.addToActivatedFlags(flag);
    }
    */

    public void NewCG(string[] bgArgument, string fadeStatus){
        if(currentCG == null){
            //Debug.Log("New Background");
            GameObject newCGImage = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
            newCGImage.transform.SetParent(GameObject.Find("CGScene").transform, false);
            currentCG = newCGImage;
            if(fadeStatus == "noFade"){
                newCGImage.GetComponent<Image>().DOFade(1f, 0.0f);
            }else{
                newCGImage.GetComponent<Image>().DOFade(0f, 0.0f);
                newCGImage.GetComponent<Image>().DOFade(1f, 0.4f);
            }
            
            //Debug.Log("New Background " + currentBackground);
        }
        string newCG;
        if(bgArgument.Length > 1){
            newCG = bgArgument[1].Trim();
        }else{
            newCG = "main";
        }
        
        if(!backgroundDatabase.CGDict.ContainsKey(newCG)){
            //Debug.LogError($"Background {newBackground} not registered!");
        }else{
            currentCG.GetComponent<Image>().sprite = backgroundDatabase.CGDict[newCG];
        }
        
    }

    public void DestroyCG(){
        StartCoroutine(FadeCG());
        //Destroy(currentCG);
        //currentCG = null;
    }

    IEnumerator FadeCG(){
        currentCG.GetComponent<Image>().DOFade(0f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        Destroy(currentCG);
        currentCG = null;
    }

    public void HideTextbox(){
        HideDialogue();
        canChangeHide = false;
    }

    public void RestoreTextbox(){
        messageText.text = "";
        UnhideDialogue();
        canChangeHide = true;
    }

    /* MOCHA MAGIC CODE
    public void AddToDrinkStory(string newStory){
        //mcBehavior.
    }
    */

    public void UpdateBackground(string[] bgArgument, string fadeStatus){
        if(currentBackground == null){
            //Debug.Log("New Background");
            GameObject newBG = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
            //Image newBGImage = newBG.GetComponent<Image>();
            newBG.transform.SetParent(GameObject.Find("VNBackgroundScene").transform, false);
            if(fadeStatus == "noFade"){
                newBG.GetComponent<Image>().DOFade(1f, 0.0f);
            }else{
                newBG.GetComponent<Image>().DOFade(0f, 0.0f);
                newBG.GetComponent<Image>().DOFade(1f, 0.8f);

            }
            

            currentBackground = newBG;
            //Debug.Log("New Background " + currentBackground);
        }
        string newBackground;
        if(bgArgument.Length > 1){
            newBackground = bgArgument[1].Trim();
        }else{
            newBackground = "main";
        }
        
        if(!backgroundDatabase.VNBackgroundDict.ContainsKey(newBackground)){
            //Debug.LogError($"Background {newBackground} not registered!");
        }else{
            currentBackground.GetComponent<Image>().sprite = backgroundDatabase.VNBackgroundDict[newBackground];
        }
        
    }

    // Function relevant for the overworld
    public void DespawnNPCs(string[] charsToDespawn){
        foreach(GameObject NPC in overworldNPCs){
            foreach(string npcToDelete in charsToDespawn){
                if(NPC.GetComponent<NPCBehavior>().character.CharName == npcToDelete){
                    //overworldNPCs.Remove(NPC);
                    //NPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Absent;
                    
                    // MOCHA MAGIC CODE
                    //NPC.GetComponent<NPCBehavior>().character.schedule[daySystem.currentDay.dayNumber] = NPCStatus.Absent;
                    Destroy(NPC);
                    break;
                }
            }
        }
        overworldNPCs = GetAllActiveNPCS();
    }

    // Function relevant for the overworld
    public void DespawnAllNPCs(){
        List<string> allNPCs = new List<string>();
        foreach(GameObject NPC in overworldNPCs){
            //Debug.Log($"Despawining {NPC.GetComponent<NPCBehavior>().character.CharName}");
            //allNPCs.Add(NPC.GetComponent<NPCBehavior>().character.CharName);
            //NPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Absent;
            
            // MOCHA MAGIC CODE
            //NPC.GetComponent<NPCBehavior>().character.schedule[daySystem.currentDay.dayNumber] = NPCStatus.Absent;
            Destroy(NPC);
        }
        //DespawnNPCs(allNPCs.ToArray());
    }

    // Function relevant for the overworld
    public void SpawnNPCs(string[] charsToSpawn, NPCStatus state){
        foreach(string chara in charsToSpawn){
            //int npcCount = gameDatabase.NPCList.Count;
            //for(int i = 0; i < npcCount; i++){

                //CharacterObject currentNPC = gameDatabase.CharacterList[i];
                CharacterObject currentNPC;
                
                // MOCHA MAGIC CODE
                // if(storyCharacters.NPCList.Exists(x => x.CharName == chara )){
                //     currentNPC = storyCharacters.npcNamed(chara);
                // }else{
                //     Debug.LogWarning($"No NPC Named {chara}!");
                //     break;
                // }
                
                //if(isNPCAvailable){ //if npc is available that day

                    //does this day have a locked position?
                    Vector3 npcPosition;
                    spriteDirection npcDirection;

                    //choose random position from character's pool (CHANGE THIS)
                    
                    // MOCHA MAGIC CODE
                    //int randomPick = UnityEngine.Random.Range(0, storyCharacters.SpawnPositionPool.Count);
                    //npcPosition = storyCharacters.SpawnPositionPool[randomPick].randPos;
                    //npcDirection = storyCharacters.SpawnPositionPool[randomPick].direction;

                    //overwrite random with base (wont proc if day isn't a lock day)
                    
                    // MOCHA MAGIC CODE
                    // foreach(LockPosition lockPos in currentNPC.lockedPositions){
                    //     if(lockPos.positionDay == daySystem.currentDay.dayNumber ||
                    //     (lockPos.repeatWeekly && lockPos.positionDay == daySystem.currentDay.dayNumber % 7)){
                    //         npcPosition = lockPos.basePos;
                    //         npcDirection = lockPos.direction;
                    //     }
                    // }

                    // MOCHA MAGIC CODE
                    // //set quarternion according to sprite direction enum
                    // Quaternion objectDirection = new Quaternion();
                    // if(npcDirection == spriteDirection.Left){
                    //     objectDirection.Set(0,0,0,1);
                    // }else if(npcDirection == spriteDirection.Right){
                    //     objectDirection.Set(0,180,0,1);
                    // }

                    // MOCHA MAGIC CODE
                    // GameObject newNPC = Instantiate(daySystem.baseNPC, npcPosition, objectDirection);
                    // newNPC.transform.parent = GameObject.Find("NPCGameObjectScene").transform;
                    // newNPC.name = "NPC (" +chara + ")";
                    // newNPC.GetComponent<NPCBehavior>().character = currentNPC;
                    // newNPC.GetComponent<NPCBehavior>().Setup();
                    // //newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Visitor; //new npcs cannot be custmers yet
                    // //newNPC.GetComponent<NPCBehavior>().character.schedule[daySystem.currentDay.dayNumber] = NPCStatus.Visitor;

                    // storyActivator.RemoveFlagToday("giveDrink", daySystem.currentDay.dayNumber);
                    // newNPC.GetComponent<NPCBehavior>().character.schedule[daySystem.currentDay.dayNumber] = NPCStatus.Customer;
                    
                    // if(state == NPCStatus.Customer){
                    //     newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Customer;
                    // }else{
                    //     newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Visitor;
                    // }

                    // MOCHA MAGIC CODE
                    // //newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Customer;

                    // if(currentNPC.arcProgression <= currentNPC.arcLength){
                    //     daySystem.LoadStoryScene(currentNPC);
                    // }else{
                    //     daySystem.LoadRandomScene(currentNPC);
                    // }
                    // //Debug.Log($"{isNPCCustomer}, {npcAvailability[(int)currentDay.dayOfWeek]} && {diceRoll}");

                    //if(isNPCCustomer){
                    //    newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Customer;
                    //}else if(isNPCVisitor){
                    //    newNPC.GetComponent<NPCBehavior>().visitingStatus = VisitingStatus.Visitor;
                    //}
                //}

            //}
        }
    }
    
    // Function relevant for the overworld
    public void CreateOrUpdateCharacter(string[] charArguments){
        //char arguments - char = Aidyn.Disappointed, 0, 0
        //Debug.Log($"charArguments - {charArguments[1]}");
        string[] stringArguments = charArguments[1].Trim().Split(',');
        
        //string arguments Aidyn,Disappointed,
        string[] expressionCommand = stringArguments[0].Trim().Split('.');
        string expression;
        if(expressionCommand.Length == 1){//instantiate char
            expression = "Neutral"; //default to neutral if nothing given
        }else{
            expression = expressionCommand[1]; //expression is char.expression
        }

        //did they slot in the main character?
        if(expressionCommand[0] == MCName){
            //this is actually just @icon=expression  then.
            changeMCPortrait(expression);
            return;
        }

        float xPos = 0;
        float yPos = 0;
        bool changePos = false;
        if(stringArguments.Length > 1){
            changePos = true;
            if(stringArguments.Length >= 2){
                xPos = float.Parse(stringArguments[1]);
            }
            if(stringArguments.Length >= 3){
                yPos = float.Parse(stringArguments[2]);
            }
            //Debug.Log($"new position - {xPos},{yPos}");
        }

        // *** Commenting this out so that an NPC is not instantiated
        // if( !npcsInScene.ContainsKey(expressionCommand[0]) ){ //if npc isnt already in scene, instantiate it
        //     //Debug.Log($"instantiating {expressionCommand[0]}");
        //     InstantiateNPC(expressionCommand[0], changePos, new Vector3(xPos, yPos, 0));
            
        // }//else just change the sprite

        //npc in scene with character name, character name, assigned expression
        // OLD CODE: AttemptToChangeCharacterPortrait(npcsInScene[expressionCommand[0]], expressionCommand[0], expression);
        // NEW CODE: Attempting to change the MCImage instead to display both the main character and npcs
        Debug.Log(message: $"<size=16><color=green>expressionCommand[0]: {expressionCommand[0]}</color></size>");
        Debug.Log(message: $"<size=16><color=green>expression: {expression}</color></size>");
        AttemptToChangeCharacterPortrait(MCImage, expressionCommand[0], expression);
    }

    public void DestroyBackground(){
        
        currentBackground.GetComponent<Image>().DOFade(0f, 0.5f);
        Destroy(currentBackground);
        currentBackground = null;
        //StartCoroutine(FadeBackground());
    }

    IEnumerator FadeBackground(){
        currentBackground.GetComponent<Image>().DOFade(0f, 0.5f);
        Destroy(currentBackground);
        currentBackground = null;
        yield return new WaitForSeconds(0);
    }

    // Function relevant for the overworld
    public void MoveCharacterPos(GameObject objectToMove, Vector3 newPos, float seconds){
        StartCoroutine(MoveSprite(objectToMove, newPos, seconds));
    }
    
    // Function relevant for creating additional sprites above textbox
    // Currently no longer instantiating NPC because only the MCImage portrait is being used
    public void InstantiateNPC(string npcKey, bool customPos, Vector3 newPos){
        //move existing npcs
        
        //Vector3 startingPosition = Vector3.zero;
        int npcsToMove = npcsInScene.Count+1;
        float[] newXPos = BuildNewVNXPos(npcsToMove);
        Vector3 newCharStart = new Vector3(0,0,0);

        if(!customPos){
            for(int i = 0; i < npcsToMove-1; i++){
                StartCoroutine(MoveSprite(npcsInSceneList[i], new Vector3(newXPos[i] ,0, 0), 0.2f ));
            }
            newCharStart = new Vector3(newXPos[npcsToMove-1], 0,0);
        }else{
            newCharStart = newPos;
        }
        

        GameObject newNPC = Instantiate(npcPrefab, newCharStart, Quaternion.identity);
        //newNPC.GetComponent<Image>().DOFade(0f, 0f);
        npcsInScene.Add(npcKey, newNPC);
        npcsInSceneList.Add(newNPC);
        newNPC.name = npcKey + " (NPC Prefab)";
        newNPC.transform.SetParent(GameObject.Find("NPC Sprites").transform, false);
        newNPC.GetComponent<Image>().DOFade(1f, 0.3f);
    }

    private float[] BuildNewVNXPos(int charCount){
        float[] newXPos = new float[charCount];
        if(charCount == 1){
            newXPos[0] = 0;
        }else if(charCount==2){
            newXPos[0] = -360;
            newXPos[1] = 360;
        }else if(charCount==3){
            newXPos[0] = -480;
            newXPos[1] = 0;
            newXPos[2] = 480;
        }else if(charCount==4){
            newXPos[0] = -560;
            newXPos[1] = -560+373;
            newXPos[2] = 560-373;
            newXPos[3] = 560;
        }else if(charCount==5){
            newXPos[0] = -640;
            newXPos[1] = -320;
            newXPos[2] = 0;
            newXPos[3] = 320;
            newXPos[4] = 640;
        }else if(charCount==6){
            newXPos[0] = -720;
            newXPos[1] = -720+288;
            newXPos[2] = -720+(288*2);
            newXPos[3] = 720-(288*2);
            newXPos[4] = 720-288;
            newXPos[5] = 720;
        }else if(charCount != 0){
            Debug.LogError("wait, HOW many people are here? i'm only allowing 6 npcs in a scene at most!");
        }
        return newXPos;
    }

    private List<GameObject> npcInXOrderList (List<GameObject> currentNPCs){
        List<GameObject> tempList = new List<GameObject>(currentNPCs);
        List<GameObject> returnList = new List<GameObject>();
        for(int i = 0; i < currentNPCs.Count; i++){
            if((i%2)==0){ //even
                //Debug.Log($"added {tempList[0]}");
                returnList.Add(tempList[0]); //add first of currentNPCs
                tempList.RemoveAt(0);
            }else{ //odd
                //Debug.Log($"added {tempList[tempList.Count-1]}");
                returnList.Add(tempList[tempList.Count-1]); //last in list
                tempList.RemoveAt(tempList.Count-1);
            }
        }
        return returnList;
    }

    IEnumerator MoveSprite(GameObject objectToMove, Vector3 newPos, float seconds){
        float elapsedTime = 0;
        Vector3 currentPos = objectToMove.transform.localPosition;
        while(elapsedTime < seconds){
            objectToMove.transform.localPosition = Vector3.Lerp(currentPos, newPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.localPosition = newPos;
    }
    

    public void UpdateTextSpeed(string textSpeed){
        switch(textSpeed){
            case "slower":
                timePerCharacter = slowerTextSpeed;
                currentTextSpeed = "slower";
                break;
            case "slow":
                timePerCharacter = slowTextSpeed;
                currentTextSpeed = "slow";
                break;
            case "normal":
                timePerCharacter = normalTextSpeed;
                currentTextSpeed = "normal";
                break;
            case "fast":
                timePerCharacter = fastTextSpeed;
                currentTextSpeed = "fast";
                break;
            default:
                Debug.Log("Warning: unknown text speed applied.");
                break;
        }
    }

    // Function relevant for creating additional sprites above textbox
    public void DeleteCharacterFromScene(string charToDelete){
        //npcsInSceneList = npcInXOrderList(npcsInSceneList);
        if(!npcsInScene.ContainsKey(charToDelete)){
            //Debug.LogError("Cannot make a character not in the scene leave! -Matt");
            return;
        }

        
        //npcsInScene[charToDelete].GetComponent<Image>().DOFade(0f, 0.3f);

        //npcsInSceneList.Remove(npcsInScene[charToDelete]);
        //Destroy(npcsInScene[charToDelete]); //delete npc prefab
        //npcsInScene.Remove(charToDelete); //remove npc from scene dictionary
        
        //float[] newXPos = BuildNewVNXPos(npcsInScene.Count);
        //for(int i = 0; i < newXPos.Length; i++){
        //    StartCoroutine(MoveSprite(npcsInSceneList[i], new Vector3(newXPos[i] ,0, 0), 0.2f ));
        //}
        
        StartCoroutine(FadeOutCharacter(charToDelete));
    }

    // Function relevant for creating additional sprites above textbox
    IEnumerator FadeOutCharacter(string charToDelete){
        npcsInScene[charToDelete].GetComponent<Image>().DOFade(0f, 0.3f);

        npcsInSceneList.Remove(npcsInScene[charToDelete]);
        //npcsInScene.Remove(charToDelete); //remove npc from scene dictionary


        float[] newXPos = BuildNewVNXPos(npcsInSceneList.Count);
        for(int i = 0; i < newXPos.Length; i++){
            StartCoroutine(MoveSprite(npcsInSceneList[i], new Vector3(newXPos[i] ,0, 0), 0.2f ));
        }
        yield return new WaitForSeconds(0.3f);
        //npcsInSceneList.Remove(npcsInScene[charToDelete]);
        
        Destroy(npcsInScene[charToDelete]); //delete npc prefab
        npcsInScene.Remove(charToDelete); //remove npc from scene dictionary
        //npcsInScene.Remove(charToDelete); //remove npc from scene dictionary
        
        //float[] newXPos = BuildNewVNXPos(npcsInScene.Count);
        
        //for(int i = 0; i < newXPos.Length; i++){
        //    StartCoroutine(MoveSprite(npcsInSceneList[i], new Vector3(newXPos[i] ,0, 0), 0.2f ));
        //}
        
    }

    // Function for changing the top left portrait of textbox
    public void changeMCPortrait(string newIcon){
        MCImage.SetActive(true);
        AttemptToChangeCharacterPortrait(MCImage, MCName, newIcon);
    }

    public List<string> allTitles(string[] stringArray){
        List<string> templist = new List<string>();
        foreach(string line in stringArray){
            if(IsLineTitle(line)){
                templist.Add(line);
            }
        }
        return templist;
    }

    // Main function for changing the sprite of a game object
    private void AttemptToChangeCharacterPortrait(GameObject charPrefab, string characterName, string expression){
        expression = expression.Trim();
        //break loop early if character or character's sprite doesn't exist
        if(!activeCharacters.ContainsKey(characterName)){
            //Debug.LogError($"Character {characterName} not registered in the Database Object!");
            return;
        }else if(Array.Exists(activeCharacters[characterName].spriteKeys, element => element == expression) == true){ // !activeCharacters[characterName].SpritesVN.ContainsKey(expression)
            //Debug.LogError($"Sprite {expression} not registered to character!");
            // Debug.Log(message: $"<size=16><color=blue>Here PT1</color></size>");
            charPrefab.GetComponent<Image>().sprite = activeCharacters[characterName].spriteValues[Array.IndexOf(activeCharacters[characterName].spriteKeys, expression)];
            return;
            // ***After returning the rest of the code is not executed!
        }
        
        //set npc image to assigned sprite
        //charPrefab.GetComponent<Image>().sprite = activeCharacters[characterName].SpritesVN[expression].spriteImage;
        //Array.IndexOf(activeCharacters[characterName].spriteKeys, expression) == true)
        if(Array.Exists(activeCharacters[characterName].spriteKeys, element => element == expression) == true) // Checks if the expression exists in the spriteKeys array
        {
            // Attempts to get the index of the sprite for the specific character
            //Debug.Log(message: $"<size=16><color=blue>Here PT2</color></size>");
            //charPrefab.GetComponent<Image>().sprite = activeCharacters[characterName].spriteValues[Array.IndexOf(activeCharacters[characterName].spriteKeys, expression)];
        }

        Image blinkOverlay = charPrefab.transform.Find("BlinkOverlay").GetComponent<Image>();
        
        //disable blinking on specific sprites
        if(activeCharacters[characterName].SpritesVN[expression].canBlink){ //if the sprite is one which can blink
            blinkOverlay.sprite = activeCharacters[characterName].blinkOverlaySprite;
        }else{
            blinkOverlay.sprite = blankImage;
        }
       
    }

    private bool IsLineComment(string line){
        bool newlineIsComment = ((line.Length >= 2) && line.Substring(0,2) == "//") || 
        ((line.Length >= 3) && line.Substring(0,3) == "://" ) ||
        ((line.Length >= 4) && line.Substring(0,4) == ":" + '"' + "//");
        return newlineIsComment;
    }

    private bool IsLineTitle(string line){
        bool newlineIsTitle = (line.Length >= 1) && line.Substring(0,1) == "#";
        return newlineIsTitle;
    }

    private bool IsLineConditional(string line){
        bool newlineIsTitle = (line.Length >= 2) && line.Substring(0,2) == "[#";
        return newlineIsTitle;
    }

    private bool IsLineCommand(string line){
        bool newlineIsCommand = (line.Length >= 1) && line.Substring(0,1) == "@";
        return newlineIsCommand;
    }

    private bool IsLineNonSpeaking(string line){ //if line is any of the above (including a blank!)
        if(line != "" && line[0] == '"' && line[line.Length-1] == '"'){
            line = line.Substring(1, line.Length-2);
        }
        bool newlineIsNonspeaking = IsLineCommand(line) || IsLineComment(line) || IsLineTitle(line) || IsLineConditional(line)/* || line == ""*/;
        return newlineIsNonspeaking;
    }

    // Function related to interpreting CSV files
    private string AttemptToUpdateCharacterName(string messageCur, string potenCharName)
    {
        // Checks if the message has a colon
        if(messageCur.IndexOf(":") != -1) //-1 is what appears when : is nowhere
        {     
            string[] line = messageCur.Split(':');     // ***Important note: After split, line is ["Stuff before colon", "Stuff after colon"]
                                                    //                    This means, line is an array of size 2.

                                                    // Colon was found so check if the isolated first element is a character name
            //potenCharName = line[0];
            //CheckCharacterName(line[0]);
            if(line[0].Trim() != "*"){ //if speaker is not the same speaker
                currentSpeaker = line[0];
            }else{
                //Debug.Log("Same Speaker!");
                //urrentSpeaker = line[0];
            }
            
            //Debug.Log(message: $"Current Speaker: {currentSpeaker}");
            
            if(activeCharacters.ContainsKey(currentSpeaker)){
                messageName.text = "<color=#" + ColorUtility.ToHtmlStringRGBA(activeCharacters[currentSpeaker].characterColor)+ ">" + currentSpeaker + "</color>"; //uses rich text
                Debug.Log(message:$"<color=green><size=16> Entered messageName.text modification </size></color>");
                //messageName.text = currentSpeaker;
            }else{

                // Disabled custom names text

                // string testString = line[0].Substring(1, line[0].Length-2);
                // bool containsCustomVar = line[0].Length >=2 && variableDatabase.stringVariables.ContainsKey(line[0].Substring(1, line[0].Length-2));
                // bool isCustomVariable = line[0].Length >=2 && line[0][0] == '{' && line[0][line[0].Length-1] == '}' && containsCustomVar;
                
                // Debug.Log($"boolean check {testString}: {containsCustomVar} && {isCustomVariable}");

                // if(containsCustomVar && isCustomVariable){
                //     currentSpeaker = variableDatabase.stringVariables[line[0].Substring(1, line[0].Length-2)];
                //     //Debug.Log(currentSpeaker);
                //     messageName.text = "<color=#" + ColorUtility.ToHtmlStringRGBA(activeCharacters[currentSpeaker].characterColor)+ ">" + currentSpeaker + "</color>"; //uses rich text
                // }else{
                //     messageName.text = findAndReplaceVariables(line[0]); //uses vanilla text
                // }
                
            }
            return line[1];

        } else {
            currentSpeaker = "Narration";
            messageName.text = "";
            //get rid of quotes
            //string text = messageCur.Split(':')[1];
           //text = text.Substring(1, text.Length-2);
            //return messageCur;                         // No colon found, so do nothing to message
            return messageCur;
        }
    }

    public bool OnlyOneCharInString(string line, char a){
        if(line.Length <= 0){
            //Debug.Log("line length less than zero!");
            return true;
        }
        for(int i =0; i < line.Length; i++){
            if(line[i] != a){
                return false;
            }
        }
        return true;
    }

    // Originates from StoryActivator.cs
    public void StartDialogue(){
        StartCoroutine(SetMessageAndPlay());
        // MOCHA MAGIC CODE
        //MCMove.movementFreeze();
        // ***Location for freezing player movement
    }
    
    // Main function for inputting new CSVs
    public void LoadNewDialogueText(TextAsset newText, string startArgument = "start"){
        //Debug.Log("loading " + newText.name);
        messageIndex = 0;
        messageArrayRaw = newText.text.Split('\n');

        //turn csv into regular text file
        //if(messageArrayRaw[0].Replace(",","") == "CSV"){ //if first line (with no commas is CSV)
        if(messageArrayRaw[0].Substring(0,3) == "CSV"){
            
            messageArrayRaw = CSVFormatToTxtFormat();
            Debug.Log($"Translating - {newText.name}");
        }

        messageArrayFull = LoadFullMessageArray(messageArrayRaw); //get rid of comments and blanks
        Debug.Log($"Starting scene from {startArgument}");
        messageArraySeg = LoadSegmentedMessageArray(messageArrayFull, startArgument); //put it between #START and #END
        //birth of segmented array
        
        messageCurrent = messageArraySeg[messageIndex];
    }

    public string[] CSVFormatToTxtFormat(){
        //Debug.Log("Loading CSV file!");
        //int columnCount = (messageArrayRaw[1].Split(',').Length)-2; //how many columns, besides the two blanks?
        int columnCount = 3; //name, text, everything else
        List<string> csvToText = new List<string>(); //all but first two lines
        for(int i = 0; i < messageArrayRaw.Length-2; i++){

            //assume all have three columns for now
            string newLine = messageArrayRaw[i+2];

            if(OnlyOneCharInString(newLine, ',')){ //if line is just commas
                //skip it
                //i++;
                Debug.Log($"found a blank! line {i+2} - {newLine}");
                newLine = ""; //make sure blank has no power for split
            }
            
            if(newLine.Contains(",,,")){ //check if at three commas exist in a row
                Debug.LogWarning($"nononono. PLEASE don't end or start a csv line with a comma!!!! line - {newLine}"); 
            }
            string[] commaSplitLine = newLine.Split(new string[] {",,"}, StringSplitOptions.None); //split by double comma
            //string newLine = messageArrayRaw[i+2];
        
            //if(newLine.Contains(",,,")){ //check if at three commas exist in a row
            //    Debug.LogWarning($"nononono. PLEASE don't end or start a csv line with a comma!!!! line - {newLine}"); 
            //}
            
            //check for runons
            int posDiver = 0;
            while(i+2+posDiver < messageArrayRaw.Length){ //keep an eye on this.
                //Debug.Log($"Diving in! {commaSplitLine.Length} < {columnCount}");
                if(commaSplitLine.Length < columnCount){
                    posDiver++;

                    if(i+2+posDiver >= messageArrayRaw.Length){
                        Debug.LogWarning("watch out this is gonna cause an error");
                    }

                    string diveLine = messageArrayRaw[i+2+posDiver];
                    

                    if(OnlyOneCharInString(diveLine, ',')){ //if line is just commas
                        //skip it
                        //no change in newLine
                        //i++;
                        Debug.Log($"found a blank! line {i+2+posDiver} - {newLine}");
                        diveLine = ""; //make sure blank has no power for split
                    }

                    newLine = newLine + diveLine;
                    
                    if(newLine.Contains(",,,")){ //check if at three commas exist in a row
                        Debug.LogWarning($"nononono. PLEASE don't end or start a csv line with a comma!!!! line - {newLine}"); 
                    }
                    commaSplitLine = newLine.Split(new string[] {",,"}, StringSplitOptions.None); //split by double comma
                    
                    
                }else{
                    //Debug.Log($"Complete! Full line: {newLine}");
                    i = i+posDiver;
                    break;
                }
            }
        

            string passLine = "";
            if(commaSplitLine.Length > 1 && commaSplitLine[0] == "" && commaSplitLine[1] == ""){//line is blank
                passLine = "";
            }else if(commaSplitLine.Length > 1 && IsLineNonSpeaking(commaSplitLine[1])){ //is the second line a nonspeaking
                if(commaSplitLine[1][0] == '"' && commaSplitLine[1][commaSplitLine[1].Length-1] == '"'){
                    commaSplitLine[1] = commaSplitLine[1].Substring(1, commaSplitLine[1].Length-2);
                    Debug.Log("commaSplitLine - " + commaSplitLine[1]);
                }
                passLine = commaSplitLine[1];
            }else{ //speaking line
                if(commaSplitLine.Length == 1){
                    passLine = commaSplitLine[0];
                }else if(commaSplitLine.Length > 1){
                    passLine = commaSplitLine[0] + ":" + commaSplitLine[1];
                }
            }

            csvToText.Add(passLine);
            
        }

        //set messaga array raw back to csv
        return csvToText.ToArray();
    }

    public string[] LoadSegmentedMessageArray(string[] messageArray, string startArgument = "start"){
        //string StartCommand = "#start";
        //List<string> newMessageArray = new List<string>();
        string StartCommand = "#" + startArgument;
        //Debug.Log($"starting argument: {StartCommand}");
        string EndCommand = "#end";
        int startingIndex = 0;
        int endingIndex = messageArray.Length-1;
        bool startFound = false;
        bool endFound = false;       
        //Debug.Log($"Sending {messageArray.Length} units");

        //find start index
        for(int i = 0; i < messageArray.Length; i++){
            //Debug.Log($"start: {messageArray[i].ToLower().Trim()} == {StartCommand.ToLower().Trim()}");
            if(messageArray[i].ToLower().Trim() == StartCommand.ToLower().Trim()){
                if(messageArray[i+1].ToLower().Trim()  == EndCommand.ToLower().Trim()){
                    startingIndex = 0;
                    Debug.LogError("Segment has no content!");
                }else{
                    startingIndex = i+1;
                }
                
                startFound = true;
                Debug.Log($"<color=blue>found start at {startingIndex} - {messageArray[startingIndex]}!</color>");
                break;
            }
        }

        //find end index
        for(int i = startingIndex; i < messageArray.Length; i++){
            //Debug.Log($"end: {messageArray[i].ToLower().Trim()} == {EndCommand.ToLower().Trim()}");
            if(messageArray[i].Substring(0,EndCommand.Length).ToLower().Trim()  == EndCommand.ToLower().Trim()){   
                endingIndex = i;
                endFound = true;
                Debug.Log($"<color=blue>found end at {endingIndex} - {messageArray[endingIndex]}!</color>");
                break;
            }
        }

        //from end index, find last viable line
        for(int i = endingIndex; i > startingIndex; i--){
            bool lineIsMessage = messageArray[i].Split(':').Length > 1;
            //bool lineIsWaitCommand = messageArray[i].Split('@').Length > 1 && messageArray[i].Split('@')[1].Split('=')[0] == "wait";

            //bool lineIsJumpToCommand = messageArray[i].Split('@').Length > 1 && messageArray[i].Split('@')[1].Split('=')[0] == "jumpTo";
            //bool lineIsWaitCommand = messageArray[i].Split('@').Length > 1 && messageArray[i].Split('@')[1].Split('=')[0] == "wait";
            //bool lineIsServeDrinkCommand = messageArray[i].Split('@').Length > 1 && messageArray[i].Split('@')[1].Split('=')[0] == "serveDrink";

            if(!lineIsMessage && !isCommand(messageArray[i], "wait") && !isCommand(messageArray[i], "jumpTo") && !isCommand(messageArray[i], "music")){
                endingIndex = i;
            }else{
                break;
            }
        }

        if(endingIndex <= startingIndex){
            //Debug.LogError($"Chosen segment {startingIndex} to {endingIndex} is a blank, and has no viable ending points!");
        }

        //check for errors
        if(!endFound){
            endingIndex = messageArray.Length; //no end so last line doesnt skip
            //Debug.LogWarning("endingLine is undefined, be careful!");
        }
        if(!startFound){
            //Debug.LogWarning("startingLine is undefined, be careful!");
    
        }

        //get rid of any conditionals that don't work
        //build the array
        List<string> newMessageArray = new List<string>();
        List<bool> layersOfTruth = new List<bool>(){true};
        newMessageArray = checkNextSegLine(startingIndex, endingIndex, 0, messageArray, newMessageArray, layersOfTruth);
        string[] appendedArray = appendedLines(newMessageArray.ToArray());
        //return newMessageArray.ToArray();
        return appendedArray;
    }

    private bool isCommand(string line, string command){
        bool isThisCommand = line.Split('@').Length > 1 && line.Split('@')[1].Split('=')[0] == command;
        return isThisCommand;
    }

    //recursive function to build segmented array (recursive bc of conditional loops)
    //this took me an embarassingly long time to remember how to do OOPS
    private List<string> checkNextSegLine(int start, int end, int layer, string[] stringArray, List<string> tempMessageArray, List<bool> truthLayers){
        //Debug.Log($"recusive loop at layer {layer} begin!");
        //List<string> newMessageArray = new List<string>();

        if(start < end){
            if(IsLineConditional(stringArray[start])){
                if(stringArray[start].IndexOf(']') != -1){
                    
                    int endIndex = stringArray[start].IndexOf(']')-1;
                    string flagString = stringArray[start].Substring(2, endIndex-1).Trim();
                    if(flagString.ToLower() == "endBlock".ToLower()){
                        if(layer > 0){
                            //pop highest truth layer
                            truthLayers.RemoveAt(layer);
                            layer--;
                            //Debug.Log($"<b>Lowering Cond Layer: {conditionalLayer}</b>");
                        }else{
                            //Debug.LogError("Don't call an end if statement before the flag, or bad things could happen!");
                        }
                        
                    }else{
                        string[] flagCommand = flagString.Split('=');
                        if(flagCommand.Length <= 1){
                            //Debug.LogWarning("flag can find no arguments");
                        }
                        
                        //flagArguments = flagCommand[1].Trim().Split(',');
                        bool flagHasOccured;
                        switch(flagCommand[0].Trim().ToLower()){ //no case sensitivity
                            case "else":
                                if(truthLayers.Count < layer){ //layer has exceeded the amount of items in list
                                    //Debug.LogError("Cannot define an else statement before a conditional!");
                                }else{
                                    if(truthLayers[layer-1]){
                                        //flip value of layer?
                                        truthLayers[layer] = !truthLayers[layer];
                                    }
                                }
                                break;
                            // MOCHA MAGIC CODE
                            // case "flag": //if flag is present
                            //     string[] flagArguments = flagCommand[1].Trim().Split(',');;
                            //     layer++;
                            //     flagHasOccured = hasFlagOccured(flagArguments);
                            //     if(flagHasOccured && truthLayers[layer-1]){ //if a layer above this one is false, it can never be true
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }
                            //     break;
                            // case "noflag": //if flag is not present
                            //     string[] noflagArguments = flagCommand[1].Trim().Split(',');;
                            //     layer++;
                            //     flagHasOccured = hasFlagOccured(noflagArguments);
                            //     if(!flagHasOccured && truthLayers[layer-1]){ //if a layer above this one is false, it can never be true
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }
                            //     break;
                            // case "present":
                            //     string[] presentArguments = flagCommand[1].Trim().Split(',');
                            //     layer++;

                            //     bool areAllCharsInScene = true;
                            //     foreach(string argument in presentArguments){
                            //         if(!isCharInScene(argument)){ //if char is not in scene
                            //             areAllCharsInScene = false;
                            //         }
                            //     }
                            //     if(areAllCharsInScene){
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }
                            //     break;
                            // case "notpresent":
                            //     string[] notPresentArguments = flagCommand[1].Trim().Split(',');
                            //     layer++;

                            //     bool areAllCharsAbsent = true;
                            //     foreach(string argument in notPresentArguments){
                            //         if(isCharInScene(argument)){
                            //             areAllCharsAbsent = false;
                            //         }
                            //     }
                            //     if(areAllCharsAbsent){
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }
                            //     break;

                            // MOCHA MAGIC CODE
                            // case "drinkis":
                            //     string[] drinkIsArguments = flagCommand[1].Trim().Split(',');
                            //     layer++;

                            //     bool drinkHasQualities = true;
                            //     foreach(string quality in drinkIsArguments){
                            //         if(!mcBehavior.drinkYouServed.Contains(quality)){
                            //             drinkHasQualities = false;
                            //         }
                            //     }
                            //     if(drinkHasQualities){
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }

                            //     break;
                            // case "drinkisnt":
                            //     string[] drinkIsntArguments = flagCommand[1].Trim().Split(',');
                            //     layer++;

                            //     bool drinkLacksQualities = true;
                            //     foreach(string quality in drinkIsntArguments){
                            //         if(mcBehavior.drinkYouServed.Contains(quality)){
                            //             drinkLacksQualities = false;
                            //         }
                            //     }
                            //     if(drinkLacksQualities){
                            //         truthLayers.Add(true);
                            //     }else{
                            //         truthLayers.Add(false);
                            //     }
                            //     break;
                            case "rand":
                                int randomRange = 1;
                                int randomPool = 1;
                                int diceRoll = 0;
                                layer++;
                                string[] randArguments = flagCommand[1].Trim().Split(',');;
                                System.Random random = new System.Random();
                                switch(randArguments.Length){
                                    case 0:
                                        Debug.LogError($"No viable arguments passed into conditional on line {start}");
                                        break;
                                    case 1: //1 out of argument
                                        if(!int.TryParse(randArguments[0], out randomPool)){ //tryparse assigns this to randompool
                                            Debug.LogError($"{randArguments[0]} on line {start} isn't a number LOL");
                                        }
                                        diceRoll = random.Next(1, randomPool);
                                        if(diceRoll <= randomRange && truthLayers[layer-1]){ //did it hit the range?
                                            //hit the range!
                                            truthLayers.Add(true);
                                        }else{
                                            truthLayers.Add(false);
                                        }
                                        break;
                                    case 2: //argument1 out of argument2
                                        if(!int.TryParse(randArguments[0], out randomRange)){ //tryparse assigns this to randompool
                                            Debug.LogError($"{randArguments[0]} on line {start} isn't a number LOL");
                                        }
                                        if(!int.TryParse(randArguments[1], out randomPool)){ //tryparse assigns this to randompool
                                            Debug.LogError($"{randArguments[1]} on line {start} isn't a number LOL");
                                        }
                                        diceRoll = random.Next(1, randomPool);
                                        if(diceRoll <= randomRange && truthLayers[layer-1]){ //did it hit the range?
                                            //hit the range!
                                            truthLayers.Add(true);
                                        }else{
                                            truthLayers.Add(false);
                                        }
                                        break;
                                    default:
                                        Debug.LogError($"Unknown amount of numbers passed in on line {start}");
                                        break;
                                }
                                //layer++;
                                if(randomPool < randomRange){
                                    //Debug.LogError("Your range was bigger than your pool. That's not logically possible.");
                                }
                                break;
                            default:
                                Debug.LogWarning($"unknown argument being passed into conditional.");
                                break;
                        }
                    }
                }
            }else{
                if(truthLayers[layer] == true){
                    if(!IsLineTitle(stringArray[start])){
                        tempMessageArray.Add(stringArray[start]);
                    }
                }
            }
            start++;
            tempMessageArray = checkNextSegLine(start, end, layer, stringArray, tempMessageArray, truthLayers);
        }
        return tempMessageArray;
    }

    private string[] appendedLines(string[] passedLines){
        
        List<string> appendedList = new List<string>();
        int index = 0;
        foreach(string line in passedLines){
            if(line.Split(':')[0] == "^"){
                if(index == 0){ //this is the first index
                    Debug.LogError($"line skipped, because your first line shouldn't be a runon:{line}");
                }else{
                    //prevent from attaching to comment or title
                    string prevLine = appendedList[appendedList.Count-1];
                    if(IsLineTitle(prevLine)){
                        Debug.LogWarning($"This is runon applied itself to the title above it. Are you okay with that? {line}");
                    }else if(IsLineCommand(prevLine)){
                        Debug.LogWarning($"This is runon applied itself to the command above it. Are you okay with that? {line}");
                    }else{
                        appendedList[appendedList.Count-1] = appendedList[appendedList.Count-1].Substring(0,appendedList[appendedList.Count-1].Length).Trim();
                        appendedList[appendedList.Count-1] = String.Concat(appendedList[appendedList.Count-1], ' ' + ReplaceIllegalChars(line.Split(':')[1]));
                    }

                }
            }else{
                appendedList.Add(line);
            }
            index++;
        }
        return appendedList.ToArray();
    }

    // MOCHA MAGIC CODE
    // private bool hasFlagOccured(string[] flagArguments){
    //     List<string> allFlags = new List<string>();
    //     if(flagArguments.Length > 1){
    //         int currentDay = int.Parse(flagArguments[1].Trim());
    //         if(storyActivator.activatedFlagsAt(currentDay) != null){
    //             allFlags = storyActivator.storyFlagStringList(storyActivator.activatedFlagsAt(currentDay));
    //         }                            
    //     }else{
    //         allFlags = storyActivator.storyFlagStringList(storyActivator.allActivatedFlags());
    //     }
    //     bool flagHasOccured = allFlags.Contains(flagArguments[0].ToLower().Trim());
    //     return flagHasOccured;
    // }

    private bool isCharInScene(string charName){
        foreach(GameObject npc in overworldNPCs){
            Debug.Log($"<color=blue>{npc.GetComponent<NPCBehavior>().character.CharName} == {charName}</color>");
            if(npc.GetComponent<NPCBehavior>().character.CharName == charName){
                Debug.Log($"{charName} present!");
                return true;
            }
            
        }
        return false;
    }

    public string[] LoadFullMessageArray(string[] messageArray){
        List<string> newStringList= new List<string>();
        for(int i = 0; i < messageArray.Length; i++){
            string newLine = messageArray[i].Trim();
            if(IsLineComment(newLine)){
                Debug.Log("Comment detected for termination. -" + newLine);
            }
            if(!(newLine == "" || IsLineComment(newLine) )){ //if not any of the rejected line types
                //concat time
                if(newLine.IndexOf(':') == -1 && !IsLineCommand(newLine) && !IsLineTitle(newLine) && !IsLineConditional(newLine)){ //if the line contains no : but isnt title or comment
                    //it's an illegal line.
                    Debug.LogWarning("blank line that isn't a command/title has been detected. skipped.");
                    if(newLine.IndexOf(':') == -1){
                        Debug.Log("This was a blank!");
                    }
                }else{
                    //this is a regular line.
                    //if it's a dialogue line...add quotes here.
                    if(newLine.IndexOf(':') != -1){
                        string[] dialogueLines = newLine.Split(':');
                        if(dialogueLines[1][0] == '"' && dialogueLines[1][dialogueLines[1].Length-1] == '"'){
                            dialogueLines[1] = dialogueLines[1].Substring(1, dialogueLines[1].Length - 2);
                        }else{
                            /*if(dialogueLines[1][0] != '[' && dialogueLines[1][dialogueLines[1].Length-1] != ']'){
                                dialogueLines[1] = '"' + dialogueLines[1].Trim() + '"';
                            }*/
                            
                        }
                        //replace the illegal characters
                        dialogueLines[1] = ReplaceIllegalChars(dialogueLines[1]);
                        newLine = dialogueLines[0] + ":" + dialogueLines[1];
                    }
                    
                    newStringList.Add(newLine);
                }

            }
        }
        storyTags = allTitles(newStringList.ToArray());
        return newStringList.ToArray();
    }

    public string ReplaceIllegalChars(string newString){
        //replace the illegal characters
        newString = newString.Replace("‘","'").Replace("’", "'").Replace('“','"').Replace('”','"');
        return newString;
    }

    // MOCHA MAGIC CODE
    // public void ToggleBacklog(){
    //     AutoTextOff(); //input detected
    //     Debug.Log("Open Backlog!");
    //     if(backlogView.BacklogOpen()){
    //         backlogView.HideBacklog();
    //         isTextFrozen = false;
    //     }else{ 
    //         backlogView.ShowBacklog();
    //         isTextFrozen = true;
    //     }
        
    // }

    public void HideDialogue(){
        
        AutoTextOff(); //input detected
        textbox.SetActive(false);
        //MCImage.SetActive(false);
        textboxVisible = false;
        isTextFrozen = true;
        
    }

    IEnumerator FadeTextbox(){
        yield return new WaitForSeconds(0.3f);
        HideDialogue();
    }

    public void UnhideDialogue(){
        //no auto text off since there's no way to turn it on from a hidden textbox
        textbox.SetActive(true);
        //MCImage.SetActive(true);
        textboxVisible = true;
        isTextFrozen = false;
        
    }

    public void InstantiateSettingsMenu(){
        AutoTextOff(); //input detected
        GameObject newMenuObject = Instantiate(settingsMenu, new Vector3(0,0,0), Quaternion.identity);
        newMenuObject.transform.parent = GameObject.Find("SettingsMenuScene").transform;
        newMenuObject.transform.position = new Vector3(0,0,0);
        // MOCHA MAGIC CODE
        //CreateSettingsMenu.VNFreeze = true;
        isTextFrozen = true;
    }

    public void CharaVoiceSwitch(){
        //AutoTextOff(); //this one is a toggle so i won't count it
        // MOCHA MAGIC CODE
        //PlayerSettings.characterVoices = !PlayerSettings.characterVoices;
        UpdateVoiceSwitch();
        
    }

    public void UpdateVoiceSwitch(){
        // MOCHA MAGIC CODE
        // if(PlayerSettings.characterVoices){
        //     noVoiceButtonText.color = optionsWhite;
        // }else{
        //     noVoiceButtonText.color = optionsBlack;
        // }
    }

    public bool CharaVoicesOn(){
        //return charaVoicesOn;
        // MOCHA MAGIC CODE
        // return PlayerSettings.characterVoices;

        // Temp
        return true;
    }

    public void AutoTextSwitch(){
        if(autoText){
            AutoTextOff();
        }else{
            AutoTextOn();
        }
    }

    public void AutoTextOn(){
        autoText = true;
        autoButtonText.color = optionsBlack;
    }
    public void AutoTextOff(){
        autoText = false;
        autoButtonText.color = optionsWhite;
    }

    public bool IsAutoTextOn(){
        return autoText;
    }

    // EXCLUSIVE MOCHA MAGIC CODE
    public Dictionary<string, CharacterObject> ActiveCharacters(){
        return activeCharacters;
    }
    
    // Main function for changing color of speaker
    // Currently mainSpeaker is not utilized as we're not searching for a
    // character from an container or collection
    public void HighlightSpeaker(string mainSpeaker){ //ungrey the active speaker in scene if one exists
        
        UngreySprite(MCImage);

        // OLD CODE:
        // Based on existing instantiate NPCs, each of the sprites are greyed out or ungreyed out
        // if(mainSpeaker == MCName){
        //     Debug.Log(message: $"<size=16><color=blue>Here PT1</color></size>");
        //     UngreySprite(MCImage);
        //     for(int i=0;i<npcsInSceneList.Count;i++){
        //         GreyOutSprite(npcsInSceneList[i]);
        //     }
        // }else if(!npcsInScene.ContainsKey(mainSpeaker)){
        //     //grey out everyone
        //     Debug.Log(message: $"<size=16><color=blue>Here PT2</color></size>");
        //     GreyOutSprite(MCImage);
        //     for(int i=0;i<npcsInSceneList.Count;i++){
        //         GreyOutSprite(npcsInSceneList[i]);
        //     }
        // }else {
        //     Debug.Log(message: $"<size=16><color=blue>Here PT3</color></size>");
        //     GreyOutSprite(MCImage);
        //     for(int i = 0; i < npcsInSceneList.Count; i++){
        //         if(npcsInSceneList[i] == npcsInScene[mainSpeaker]){
        //             UngreySprite(npcsInSceneList[i]);
        //             // MOCHA MAGIC CODE
        //             //npcsInSceneList[i].GetComponent<NPCBehaviorVN>().blinkOnCommand();
        //             npcsInSceneList[i].transform.SetAsLastSibling();
        //         }else{
        //             GreyOutSprite(npcsInSceneList[i]);
        //         }
        //     }
        // }
    }

    public void GreyOutSprite(GameObject gameSprite){ //grey out sprite in scene view
        gameSprite.GetComponent<Image>().color = new Color( 
                greyOutColor.r,
                greyOutColor.g,
                greyOutColor.b,
                gameSprite.GetComponent<Image>().color.a
            );

        // OLD CODE:
        // Greying out the BlinkOverlay on characters    
        //gameSprite.transform.Find("BlinkOverlay").GetComponent<Image>().color = greyOutColor; // Disabled trying to find blink overlay
        
        
    }
    
    public void UngreySprite(GameObject gameSprite){ //ungrey out sprite in game view
        gameSprite.GetComponent<Image>().color =  Color.white;

        // OLD CODE:
        // Setting color of BlinkOvelay
        // gameSprite.transform.Find("BlinkOverlay").GetComponent<Image>().color = new Color(
        //     1,1,1, gameSprite.GetComponent<Image>().color.a
        // );
        
        //cause them to blink instantly when they wake
        //if(gameSprite.activeSelf){
        //    Debug.Log("Image not active!");
        //    gameSprite.GetComponent<NPCBehaviorVN>().blinkOnCommand();
        //}
        //gameSprite.GetComponent<NPCBehaviorVN>().blinkOnCommand();
        
    }
}
