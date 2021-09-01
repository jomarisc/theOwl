using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    // Field for a text writer single

    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    public DialogueManager dialogueManager;

    [SerializeField] SoundLibrary soundLibrary;

    [SerializeField] static int start2char = 85;
    [SerializeField] static int start3char = 65;
    [SerializeField] static int start4char = 45;
    [SerializeField] static int start5char = 20;
    [SerializeField] static int start6char = 15;


    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    // Static function, means that a reference for TextWriter in TextboxManager no longer needs to be used.
    // Note: Action types are a void delegate
    public static TextWriterSingle AddWriter_Static(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete, string currentSpeaker)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete, currentSpeaker);
    }

    private TextWriterSingle AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete, string currentSpeaker)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete, dialogueManager, soundLibrary, currentSpeaker);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TMP_Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(TMP_Text uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            // If UI text matches the one we're looking for,
            // then let's remove this one.
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        // Counter for how many textWriterSingleLists exists at the time
        //Debug.Log(textWriterSingleList.Count);
        
        //for (int i = 0; i < textWriterSingleList.Count; i++)
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            //StartCoroutine(textWriterSingleList[i].PrintChars());
            //bool destroyInstance = textWriterSingleList[i].PrintChars();
            if(!textWriterSingleList[i].IsPrintingCharsActive()){
                Debug.Log(message: $"<color=green><size=16> Inside TextWriterUpdate! </size></color>");
                StartCoroutine(textWriterSingleList[i].PrintChars());
            }

            bool destroyInstance = textWriterSingleList[i].InKillZone();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                // Because we're doing this in the for loop,
                // we have to go back one to not skip one
                i--;
            }
        }
    }

    // Writing a nest class to handle multiple instances of text writers
    // in a single game object.
    // Represents a single TextWriter instance
    public class TextWriterSingle
    {

        private TMP_Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;
        private DialogueManager dialogueManager;
        private SoundLibrary soundLibrary;
        private string currentSpeaker;
        private string endTag = "";
        private bool inKillZone = false;
        private bool isPrintingCharsActive = false;
        float voiceInterval = 0;
        float intervalModifier = 1;
        float hangTime = 0;
        private bool interrupted = false;
        private AudioSource audioSource;

        public TextWriterSingle(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete, DialogueManager dialogueManager, SoundLibrary soundLibrary, string currentSpeaker)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite.Trim();
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            this.dialogueManager = dialogueManager;
            this.audioSource = dialogueManager.GetComponent<AudioSource>();
            this.soundLibrary = soundLibrary;
            this.currentSpeaker = currentSpeaker;
            characterIndex = 0;
        }

        // Returns true on complete
        //public bool PrintChars() testing a rework of PrintChars to get it to pause ()
        public IEnumerator PrintChars()
        {
            this.interrupted = false;
            isPrintingCharsActive = true;
            //timer -= Time.deltaTime;
            dialogueManager.floatingMarker.SetActive(false);
            //string endTag = "";
            //Debug.LogError("End tag has been reset!");
            
            //decide how many chars to print
            int charsToPrint = 1;
            //int frameRate = Application.targetFrameRate;
            float frameRate = 1.0f/Time.deltaTime;
            if(frameRate < start2char && frameRate >= start3char){
                charsToPrint = 2;
                intervalModifier = 1;
            }else if(frameRate < start3char && frameRate >= start4char){
                charsToPrint = 3;
                intervalModifier = 1.5f;
            }else if(frameRate < start4char && frameRate >= start5char){
                charsToPrint = 4;
                intervalModifier = 2;
            }else if(frameRate < start5char && frameRate >= start6char){
                charsToPrint = 5;
                intervalModifier = 2.5f;
            }else if(frameRate < start6char){
                charsToPrint = 6;
                intervalModifier = 3f;
            }
            //starting pitch
            Camera.main.GetComponent<AudioSource>().pitch = 1.03f;

            //while (timer <= 0f) changing end condition
            while(characterIndex <= textToWrite.Length-1)
            {
                //Debug.Log($"{characterIndex} out of {textToWrite.Length} is '{textToWrite[characterIndex]}': {textToWrite.Substring(0, characterIndex)}");
                //Debug.Log($"<b>0: {characterIndex} - index</b>");
                //look for rich text!
                int richTextIterator = 0;
                //Debug.Log($"{richTextIterator < charsToPrint} && {characterIndex < textToWrite.Length}");
                //Debug.Log($"{richTextIterator} < {charsToPrint} && {characterIndex} ({textToWrite[characterIndex+richTextIterator]}) < {textToWrite.Length}");
                while(richTextIterator < charsToPrint && characterIndex < textToWrite.Length){
                    
                    
                    int stepIndex = characterIndex+richTextIterator;
                    //Debug.Log(stepIndex);
                    if(stepIndex > textToWrite.Length-1){
                        break;
                    }
                    if(/*stepIndex < textToWrite.Length &&*/ textToWrite[stepIndex] == '<'){
                        //does this contain a >?
                        //Debug.Log($"found < at {characterIndex}");
                        
                        int startTagIndex = stepIndex;
                        //ignore closing tags for now
                        bool isClosingTag = stepIndex < textToWrite.Length-1 && textToWrite[stepIndex+1] == '/';
                        if(textToWrite.Substring(richTextIterator).IndexOf('>') != -1 && !isClosingTag){
                            
                            int endIndex = textToWrite.Substring(stepIndex).IndexOf('>') + startTagIndex;
                            //Debug.Log($"found full tag!: {textToWrite[startIndex]} to {textToWrite[endIndex]} ({endIndex})");
                            
                            //check to see if there's an end tag
                            string tagText = textToWrite.Substring(startTagIndex+1, endIndex-startTagIndex-1);

                            //ERROR? skip the tagtext in scroll, youve found it
                            characterIndex += tagText.Length+1;

                            //is there an = in the tag text? (we don't want our end tag as </color=blue>)
                            if(tagText.IndexOf('=') != -1){
                                string[] splitTag = tagText.Split('=');
                                tagText= splitTag[0];
                            }

                            string closingTag = "</" + tagText + ">";
                            //Debug.Log($"looking for...full closing tag: {closingTag}!");

                            if(textToWrite.Substring(endIndex).IndexOf(closingTag) != -1){ //does this closing tag appear in the strong after the first end index?
                                //Debug.Log("tag confirmed!");
                                endTag = closingTag + endTag;
                                //Debug.Log($"found end tag {endTag}");
                            }else{
                                Debug.LogWarning("<color=blue>did you forget to conclude your richtext tag? if you used br that's fine.</color>");
                            }

                        }else{
                            if(!isClosingTag){
                                //Debug.LogWarning("< found but no closing >.");
                            }else{
                                //Debug.Log("closing tag hit?");

                                //we just hit a closing tag. skip closing tag in text scroll, we dont need it by now!
                                int endIndex = textToWrite.Substring(stepIndex).IndexOf('>');
                                string tagText = textToWrite.Substring(startTagIndex, endIndex+1);
                                characterIndex += tagText.Length-1;
                                //remove closing from persistent endTag

                                //Debug.Log($"current endTag: {endTag}");
                                if(endTag.IndexOf(tagText) != -1){
                                    endTag = endTag.Remove(endTag.IndexOf(tagText), tagText.Length);
                                    //Debug.Log($"tag removed, it is now: {endTag}");
                                }else{
                                    //Debug.LogWarning($"Tag removal unsuccesful, does {tagText} exist in {endTag}?");
                                }
                            }
                        }
                    }
                    richTextIterator++;

                }


                //Debug.Log($"<b>1: {characterIndex} - index</b>");

                //look for line commands!
                //if character index isn't on the last possible character, it starts with "[@"
                int inlineIterator = 0;
                int startIndex = characterIndex;
                while(inlineIterator < charsToPrint && characterIndex < textToWrite.Length){
                    //characterIndex = checkForInlines(characterIndex);
                    if(startIndex+inlineIterator < textToWrite.Length){
                        //Debug.Log($"checking at: {startIndex+inlineIterator} - {textToWrite.Substring(startIndex+inlineIterator)}");
                        /*characterIndex = */checkForInlines(startIndex+inlineIterator);
                    }
                    
                    inlineIterator++;
                }
                //Debug.Log("------------------------------------");
                //characterIndex = checkForInlines(characterIndex);
                yield return new WaitForSeconds(hangTime);
                hangTime = 0;

                //kill the script here if interupt is true
                /*if(this.interrupted){
                    Debug.Log("EXCUSE ME! You've been interrupted! Don't just keep talking!");
                    endTag = "";
                    inKillZone = true;
                    
                }*/

                //Debug.Log($"<b>2: {characterIndex} - index</b>");

                //don't print duplicate spaces (doing this so scripts, esp ones w a lotta inlines, are easier to write.)
                for(int i = 0; i < charsToPrint; i++){
                    if(characterIndex > 0 && characterIndex+i < textToWrite.Length){ //we don't wanna call this on the first character!
                        if(textToWrite[characterIndex+i-1] == ' ' && textToWrite[characterIndex+i] == ' '){
                            //Debug.Log("Duplicate spaces detected!");
                            textToWrite = textToWrite.Remove(characterIndex+i, 1);
                            characterIndex--;
                        }    
                    }
                }
                

                //Debug.Log($"<b>3: {characterIndex} - index</b>");

                //Debug.Log($"{characterIndex} - freeze the text: {DialogueManager.isTextFrozen}");
                yield return new WaitUntil(() => !DialogueManager.isTextFrozen);
                //yield return new WaitForSeconds(0.25f);

                //Debug.Log("End tag = " +endTag);

                // Display next character
                //timer += timePerCharacter;
                characterIndex = characterIndex+charsToPrint;
                string text = "";
                if(characterIndex < textToWrite.Length){
                    text = textToWrite.Substring(0, characterIndex) + endTag;
                }else{
                    text = textToWrite + endTag;
                    //Debug.LogWarning("Character index greater than text length. This shouldnt be here...");
                }

                //Debug.Log($"Now, {characterIndex} out of {textToWrite.Length} is {textToWrite[characterIndex]}: {textToWrite.Substring(0, characterIndex)}");
                    
                if (invisibleCharacters)
                {
                    //turning off invisible characters for now, sorry (conflicts with colored text)
                    // Color tag = RRGGBBAA
                    //text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                
                //Debug.Log(message: $"Current Speaker in Text Writer: {currentSpeaker}");
                
                if(dialogueManager.ActiveCharacters().ContainsKey(currentSpeaker))
                {
                    Debug.Log(message: $"<color=green><size=16> CurrentSpeaker is IN ActiveCharacters() </size></color>");
                } else {
                    Debug.Log(message: $"<color=green><size=16> CurrentSpeaker is NOT IN ActiveCharacters() </size></color>");
                }

                //get character talking
                if(!dialogueManager.ActiveCharacters().ContainsKey(currentSpeaker)){
                    Debug.Log(message: $"<color=green><size=16> Inside speaking voice chunk part0! </size></color>");
                    if(currentSpeaker != "Narration"){
                        //Debug.LogWarning($"No character '{currentSpeaker}' speaking this line of dialouge exists. Is there a typo?");
                    }
                }else{
                    
                    //this is a bad place to put this
                    //dialogueManager.HighlightSpeaker(currentSpeaker);
                    Debug.Log(message: $"<color=green><size=16> Inside speaking voice chunk part1! </size></color>");
                    
                    CharacterVoice speakingVoice = dialogueManager.ActiveCharacters()[currentSpeaker].characterVoice;
                    float toSpeakVoice = speakingVoice.Interval / intervalModifier;
                    //toSpeakVoice = 8;

                    Debug.Log(message: $"<color=blue><size=16> voiceInterval BEFORE == {voiceInterval} </size></color>");
                    Debug.Log(message: $"<color=blue><size=16> toSpeakVoice == {toSpeakVoice} </size></color>");
                    Debug.Log(message: $"<color=blue><size=16> dialogueManager.CharaVoicesOn() == {dialogueManager.CharaVoicesOn()} </size></color>");
                    if(voiceInterval >= toSpeakVoice && dialogueManager.CharaVoicesOn()){

                        Debug.Log(message: $"<color=green><size=16> Inside speaking voice chunk part2! </size></color>");

                        //AudioSource.PlayClipAtPoint(speakingVoice.VoiceClip(soundLibrary), Camera.main.transform.position, PlayerSettings.SFXVolume*0.3f);
                        // AudioSource.PlayClipAtPoint(speakingVoice.VoiceClip(soundLibrary), Camera.main.transform.position, 10*0.3f);
                        // audioSource.clip = speakingVoice.VoiceClip(soundLibrary);
                        // //audioSource.volume = PlayerSettings.SFXVolume*0.6f;
                        // audioSource.volume = 100*0.6f;

                        // //alternating
                        // if(Camera.main.GetComponent<AudioSource>().pitch == 1.03f){
                        //     Camera.main.GetComponent<AudioSource>().pitch = 0.95f;
                        // }else if(Camera.main.GetComponent<AudioSource>().pitch == 0.95f){
                        //     Camera.main.GetComponent<AudioSource>().pitch = 1.03f;
                        // }

                        // //random
                        // Camera.main.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.95f, 1.03f);
                        // //Camera.main.GetComponent<AudioSource>().PlayOneShot(speakingVoice.VoiceClip(soundLibrary), PlayerSettings.SFXVolume*0.4f);
                        // Camera.main.GetComponent<AudioSource>().PlayOneShot(speakingVoice.VoiceClip(soundLibrary), 10*0.4f);
                        
                        // //audioSource.PlayOneShot(speakingVoice.VoiceClip(soundLibrary), PlayerSettings.SFXVolume*0.6f);
                        // audioSource.PlayOneShot(speakingVoice.VoiceClip(soundLibrary), 10*0.6f);
                        voiceInterval = 0;
                    }
                    if(voiceInterval == 0){
                        Camera.main.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.95f, 1.03f);
                        Camera.main.GetComponent<AudioSource>().PlayOneShot(speakingVoice.VoiceClip(soundLibrary), 1.5f*0.4f); // Previously: PlayerSettings.SFXVolume*0.4f
                    }
                    voiceInterval++;
                    Debug.Log(message: $"<color=blue><size=16> voiceInterval AFTER == {voiceInterval} </size></color>");
                }
                yield return new WaitForSeconds(timePerCharacter * Time.deltaTime);

                //exit condition
                if (characterIndex >= textToWrite.Length)
                {
                    //Debug.Log("TextPrinter complete!");
                    // Entire string displayed
                    if (onComplete != null) onComplete();
                    // Reaching the end
                    //AudioSource.PlayClipAtPoint(dialogueManager.soundLibrary.AudioDict["messageOK"], Camera.main.transform.position, PlayerSettings.SFXVolume);

                    //show marker
                    dialogueManager.floatingMarker.SetActive(true);

                    endTag = "";
                    inKillZone = true;

                }

                
                      
            }

            //return false;
            //yield return false;
            inKillZone = false;
            isPrintingCharsActive = true;
            yield return new WaitForSeconds(0);
        }

        public TMP_Text GetUIText()
        {
            return uiText;
        }

        public bool InKillZone(){
            return inKillZone;
        }

        
        private int checkForInlines(int currIndex){
            if(currIndex < textToWrite.Length -1 && textToWrite.Substring(currIndex, 2) == "[@"){
                int startIndex = currIndex;
                //Debug.LogWarning($"testingA: {startIndex} vs {textToWrite.Length}");
                //find the ']' tag
                if(textToWrite.Substring(startIndex).IndexOf(']') != -1){
                    //found a command!
                    int endIndex = textToWrite.Substring(startIndex).IndexOf(']');
                    string commandString = textToWrite.Substring(startIndex+2, endIndex-2);
                    //Debug.Log($"command string: {commandString}");

                    string[] commandLines = commandString.Split('=');
                    string command = commandLines[0].Trim();

                    // Debug.Log("inline command: " + command);

                    //remove command from string
                    textToWrite = textToWrite.Remove(currIndex, endIndex+1);

                    //bool interjected = false;
                    //jump to could be dangerous, so we're not gonna include that
                    switch(command){
                        case "wait":
                            //this one is special, so we'll get to it later
                            hangTime = 0;
                            if(commandLines.Length > 1){
                                hangTime = float.Parse(commandLines[1].Trim());
                            }
                            break;
                            //plot twist - the hardest one to implement normally was the easiest to implement inline
                            //i stand corrected :)))))))
                        case "sfx":
                            string[] soundCommand = commandLines[1].Trim().Split(',');
                            float waitTime = 0f;
                            if(soundCommand.Length > 1){
                                waitTime = float.Parse(soundCommand[1]);
                            }
                            dialogueManager.playStorySoundEffectPublic(soundCommand[0], waitTime);
                            break;
                        case "music":
                            dialogueManager.UpdateMusicInVN(commandLines[1].Trim());
                            break;
                        case "stopMusic":
                            dialogueManager.StopMusicInVN();
                            break;
                        case "char":
                            dialogueManager.CreateOrUpdateCharacter(commandLines);
                            break;
                        case "leave":
                            dialogueManager.DeleteCharacterFromScene(commandLines[1].Trim());
                            break;
                        case "icon":
                            dialogueManager.changeMCPortrait(commandLines[1].Trim());
                            break;
                        case "background":
                            dialogueManager.UpdateBackground(commandLines, "fade");
                            break;
                        case "hideBackground":
                            dialogueManager.DestroyBackground();
                            break;
                        case "move":
                            string[] moveArguments = commandLines[1].Trim().Split(',');
                            Vector3 posToMove = new Vector3(
                            float.Parse(moveArguments[1].Trim()), float.Parse(moveArguments[2].Trim()), 0);
                            dialogueManager.MoveCharacterPos(dialogueManager.npcsInScene[moveArguments[0]], posToMove, 0.3f);
                            break;
                         case "textSpeed":
                            string textSpeed = commandLines[1].Trim();
                            dialogueManager.UpdateTextSpeed(textSpeed);
                            this.timePerCharacter = dialogueManager.timePerCharacter;
                            break;
                        case "interrupt": //specific to inlines
                            this.interrupted = true;
                            //Coroutine printChars;
                            //printChars = StartCoroutine(PrintChars());
                            //StopCoroutine(PrintChars());
                            dialogueManager.InterruptMessage();
                            //interjected = true;
                            /*if(characterIndex < textToWrite.Length){
                                Debug.LogWarning(textToWrite);
                            }*/
                            textToWrite = textToWrite.Remove(characterIndex);
                            //textToWrite = textToWrite + '"';
                            //return currIndex;
                            break;
                        case "despawn":
                            string[] charsToDespawn = commandLines[1].Trim().Split(',');
                            dialogueManager.DespawnNPCs(charsToDespawn);
                            break;
                        case "spawn":
                            string[] charsToSpawn = commandLines[1].Trim().Split(',');
                            dialogueManager.SpawnNPCs(charsToSpawn, NPCStatus.Customer);
                            break;
                        case "spawnVisitor":
                            string[] visitorsToSpawn = commandLines[1].Trim().Split(',');
                            dialogueManager.SpawnNPCs(visitorsToSpawn, NPCStatus.Visitor);
                            break;
                        case "endDay":
                            //MOCHA MAGIC CODE
                            //dialogueManager.EndDay();
                            break;
                        default:
                            Debug.LogWarning("Invalid Script Command!");
                            break;
                    }

                    //remove command from string
                    //textToWrite = textToWrite.Remove(characterIndex, endIndex+1);
                    
                    
                    currIndex--;
                }else{
                    Debug.LogWarning("inline command [@ found without closing ']' brackcet!");
                }
                // Debug.LogWarning($"testingA: {startIndex} vs {textToWrite.Length}");
            }
            return currIndex;
        }

        public bool IsPrintingCharsActive(){
            return isPrintingCharsActive;
        }


        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            //inline transmutation code.
            //from character index, go through rest of code
            
            bool waitCommandStop = false;
            while(characterIndex < textToWrite.Length){
                characterIndex = checkForInlines(characterIndex);
                if(hangTime > 0){
                    waitCommandStop = true;
                    Debug.Log("break!!");
                    break;
                }
                // Debug.Log("procced!!" + characterIndex);
                characterIndex++;

                if(textToWrite[characterIndex-1] == ' ' && textToWrite[characterIndex] == ' '){
                    // Debug.Log("Duplicate spaces detected!");
                    textToWrite = textToWrite.Remove(characterIndex, 1);
                    characterIndex--;
                }
            }

            if(!waitCommandStop){
                uiText.text = textToWrite;
                dialogueManager.floatingMarker.SetActive(true);
                characterIndex = textToWrite.Length;
                if (onComplete != null) onComplete();
                TextWriter.RemoveWriter_Static(uiText);
            }else{
                uiText.text = textToWrite.Substring(0, characterIndex);
            }
            
        }

        public void JustDestroy(){
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriter.RemoveWriter_Static(uiText);
        }

    }
}
