using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    public playerControl playerState;

    public enum Mode
    {
        Unlocked, Locked
    }

    public Mode mode;

    public GameObject[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        playerState = player.GetComponent<playerControl>();
        spawn = GameObject.Find("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.isAlive == false)
        {
            foreach (GameObject cp in checkpoints)
            {
                if (cp.GetComponent<Checkpoint>().status == Checkpoint.state.Active)
                {
                    // If statement timer for 3 seconds
                    if (playerState.data.deadDuration <= 0f)
                    {

                        Vector3 tempPosition = cp.transform.position - new Vector3(0, 0, (float)0.5);
                        player.transform.position = tempPosition;
                        playerState.healthbar.ResetHealth();
                        playerState.healthbar.Redraw();
                        playerState.isAlive = true;                      // Resets playerControl variable isAlive to true

                    }
                    else
                    {
                        playerState.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
                    }
                    return;
                }
            }

            // If statement timer for 3 seconds
            if (playerState.data.deadDuration <= 0f)
            {

                player.transform.position = spawn.transform.position; // If a checkpoint has not been made active yet, return player to original spawn
                playerState.healthbar.ResetHealth();
                playerState.healthbar.Redraw();
                playerState.isAlive = true;                           // Resets playerControl variable isAlive to true

            }
            else
            {
                playerState.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
            }  
        } 
    }

    public void UpdateCheckpoints(GameObject currentCheckpoint)
    {
        if (mode == Mode.Unlocked)
        {
            foreach (GameObject cp in checkpoints)
            {
                if (cp.GetComponent<Checkpoint>().status != Checkpoint.state.Inactive)
                {
                    cp.GetComponent<Checkpoint>().status = Checkpoint.state.Used;
                }
            }
            currentCheckpoint.GetComponent<Checkpoint>().status = Checkpoint.state.Active;
        } // else
    }
    
}
