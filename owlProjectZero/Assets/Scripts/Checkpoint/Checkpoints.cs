using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{

    public int currScene;
    public GameObject player;
    public PlayerInputs input;
    playerControl pControl;
    SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pControl = player.GetComponent<playerControl>();
        currScene = SceneManager.GetActiveScene().buildIndex;
        input = pControl.input;
        saveManager = this.GetComponent<SaveManager>();
    }

    void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == player.tag)
        {
            if(input.Gameplay.Interact.triggered && pControl.data.maxSpeed == pControl.data.groundSpeed)
            {
                Debug.Log("CHECKPOINT SAVED");
                CheckpointsHandler.checkpointScene = currScene;
                CheckpointsHandler.playerPosition[0] = this.transform.position.x;
                CheckpointsHandler.playerPosition[1] = this.transform.position.y;
                CheckpointsHandler.playerPosition[2] = 0.0f;
                saveManager.saveGame();
            }
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject.tag == player.tag)
    //     {
    //         Debug.Log(CheckpointsHandler.checkpointScene);

    //         for(int i = 0; i < CheckpointsHandler.playerPosition.Length; i++)
    //         {
    //             Debug.Log(CheckpointsHandler.playerPosition[i]);
    //         }
    //     }
    // }
}
