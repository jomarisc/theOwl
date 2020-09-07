using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{

    public enum state
    {
      Inactive, Active, Used, Locked  
    };

    public state status;

    // Checkpoint Handler
    public checkpointHandler ch;
    //public PlayerInputs input;
    public bool triggerEntered;

    public Sprite[] sprites;

    void Start()
    {
        ch = GameObject.Find("CheckpointHandler").GetComponent<checkpointHandler>();
        //input = new PlayerInputs();
        triggerEntered = false;
    }

    void Update()
    {
        // Checkpoint is Inactive by default until colliding with it.
        // Repeatedly sets the color to something depending on status
        SetCheckpointColor();
        
        // OLD CODE to try to coordinate player input with trigger
        //Debug.Log("Pressing enter trigger in Checkpoint!: " + input.Gameplay.Pause.triggered);
        /*
        if (input.Gameplay.Pause.triggered && triggerEntered == true)
        {
            //Debug.Log("Checkpoint activated!");
            ch.UpdateCheckpoints(this.gameObject);
        }
        */
        
    }
    
    // Update is called once per frame
    void SetCheckpointColor()
    {
        if(status == state.Inactive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (status == state.Active)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (status == state.Used)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (status == state.Locked)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // Checks if the collision is happening between the checkpoint and the player game object
        if (col.gameObject.GetComponent<playerControl>() != null) 
        {
            triggerEntered = true;
            ch.UpdateCheckpoints(this.gameObject); // Investigate this to see if there's a way in Update() to use this function with a keypress.
                                                   // Check if it's possible to respawn enemies
        } 
    }

    void OnTriggerExit(Collider col)
    {
        // Checks if the collision is happening between the checkpoint and the player game object
        if (col.gameObject.GetComponent<playerControl>() != null)
        {
            triggerEntered = false;
        }
    }
}
