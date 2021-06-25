using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{

    public string currScene;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("CHECKPOINT SAVED");

        if(other.gameObject.tag == player.tag)
        {
            CheckpointsHandler.checkpointScene = currScene;
            CheckpointsHandler.playerPosition[0] = this.transform.position.x;
            CheckpointsHandler.playerPosition[1] = this.transform.position.y;
            CheckpointsHandler.playerPosition[2] = 0.0f;
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
