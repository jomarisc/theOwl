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
        // Debug.Log("here");
        // Debug.Log(CheckpointsHandler.isDead);
        Debug.Log("Scene is " +  System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(CheckpointsHandler.checkpointScene)));
        Debug.Log("Coords are " + CheckpointsHandler.playerPosition[0] + ", "+ CheckpointsHandler.playerPosition[1] + ", " + CheckpointsHandler.playerPosition[2]);
        player = this.gameObject;
        playerState = player.GetComponent<playerControl>();

        if(CheckpointsHandler.isDead == true)
        {
            NextScene.ClearSceneTriggers();
            player.transform.position = new Vector3(CheckpointsHandler.playerPosition[0], CheckpointsHandler.playerPosition[1], CheckpointsHandler.playerPosition[2]);
            // playerState.healthbar.ResetHealth();
            // playerState.healthbar.Redraw();
            playerState.isAlive = true;

            // commented out and put in start
            // CheckpointsHandler.isDead = false;
            // Debug.Log(CheckpointsHandler.isDead);
        }

        // Debug.Log("GlobalVars.hasPressMainMenu is " + GlobalVars.hasPressMainMenu);
        if(GlobalVars.hasPressMainMenu == true)
        {
            Debug.Log("GlobalVars.hasPressMainMenu" + GlobalVars.hasPressMainMenu);
            NextScene.ClearSceneTriggers();
            player.transform.position = new Vector3(CheckpointsHandler.playerPosition[0], CheckpointsHandler.playerPosition[1], CheckpointsHandler.playerPosition[2]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // we put this in start because the awake function in NextScene.cs messes with this script's awake
        if(CheckpointsHandler.isDead == true)
        {
            CheckpointsHandler.isDead = false;
        }

        if(GlobalVars.hasPressMainMenu == true)
        {
            StartCoroutine(delay_spawn());
        }
    }

    IEnumerator delay_spawn()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        Debug.Log("hasPressMainMenu is now false");
        GlobalVars.hasPressMainMenu = false;
    }
}
