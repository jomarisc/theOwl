using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToCheckpoint : MonoBehaviour
{

    public GameObject player;
    public playerControl playerState;

    void Awake()
    {
        // Debug.Log(CheckpointsHandler.isDead);
        player = this.gameObject;
        playerState = player.GetComponent<playerControl>();

        if(CheckpointsHandler.isDead == true)
        {
            NextScene.ClearSceneTriggers();
            player.transform.position = new Vector3(CheckpointsHandler.playerPosition[0], CheckpointsHandler.playerPosition[1], CheckpointsHandler.playerPosition[2]);
            // playerState.healthbar.ResetHealth();
            // playerState.healthbar.Redraw();
            playerState.isAlive = true;
            CheckpointsHandler.isDead = false;
            // Debug.Log(CheckpointsHandler.isDead);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(playerState.isAlive == false)
        // {

        //     CheckpointsHandler.isDead = true;

        //     if(playerState.data.deadDuration <= 0f)
        //     {
                
        //     }
        //     else
        //     {
        //         playerState.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
        //     }  
        // }
    }
}
