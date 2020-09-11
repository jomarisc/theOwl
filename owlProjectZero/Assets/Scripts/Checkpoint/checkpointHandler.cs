using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointHandler : MonoBehaviour
{
    public GameObject player;
    //public GameObject groundedEnemy;
    //public UnityEngine.Object enemyRef;
    public GameObject spawn;
    public playerControl playerState;

    public enum Mode
    {
        Unlocked, Locked
    }

    public Mode mode;

    public GameObject[] checkpoints;
    public GameObject[] groundedEnemiesArray;
    public GameObject[] groundedEnemiesRespawnArray;
    private int totalNumberEnemies;

    private UnityEngine.Object enemyRef;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        groundedEnemiesArray = GameObject.FindGameObjectsWithTag("GroundedEnemy");
        CopyArray();
        playerState = player.GetComponent<playerControl>();
        spawn = GameObject.Find("Spawn");
        totalNumberEnemies = groundedEnemiesArray.Length;
        //groundedEnemy = GameObject.Find("GroundedEnemy");
        enemyRef = Resources.Load("GroundedEnemy"); // Will be used for cloning , typeof(GameObject)
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
                        RespawnEnemies();

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
                RespawnEnemies();

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

    public void RespawnEnemies() // GameObject amountToRespawn
    {
        /*
        GameObject enemyClone;
        
        for (int i = 0; i > totalNumberEnemies; i++)
        { 
            enemyClone = Instantiate(groundedEnemiesArray[i]);

            if (enemyClone.active == false)
            {
                enemyClone.SetActive(true);
            }

            enemyClone.transform.position = groundedEnemiesArray[i].transform.position;

            //groundedEnemiesArray.RemoveAt(i);
            //Destroy(groundedEnemiesArray[i]);
            //groundedEnemiesArray.Add(enemyClone);
        }
        */

        // MOST RECENT CODE 9/10/2020, Investigate this
        
        //GameObject enemyClone;
        foreach (GameObject groundedEnemies in groundedEnemiesArray)
        {
            /*
            Debug.Log("Before Instantiate!");
            enemyClone = (GameObject)Instantiate(groundedEnemies);
            if (enemyClone.active == false)
            {
                enemyClone.SetActive(true);
            }
            enemyClone.transform.position = groundedEnemies.transform.position;
            //Destroy(groundedEnemies);
            //groundedEnemies.SetActive(false);
            */
            groundedEnemies.GetComponent<GroundedEnemy>().Respawn();
        }

        //groundedEnemiesArray = (GameObject[]) groundedEnemiesRespawnArray.Clone();
        
        // ----------
        
        //enemyClone = (GameObject) Instantiate(enemyRef);
        //Instantiate(groundedEnemies);
        /*
        if (enemyClone.active == false)
        {
            enemyClone.SetActive(true);
        }
        */

        //enemyClone.SetActive(true);
        //enemyClone.transform.position = groundedEnemies.transform.position;

        //Destroy(groundedEnemies);
        //groundedEnemies.active = false;
        //groundedEnemies.active = true;

        //}


        //GameObject enemyClone;
        /*
        for (int i = (totalNumberEnemies - FindEnemiesRemaining()); i > 0; i--)
        {
            Debug.Log("ENEMIES RESPAWNED: " + i);
            //enemyClone = (GameObject)Instantiate(enemyRef);
            Instantiate(enemyRef);
        }
        */
    }

    public void CopyArray()
    {
        groundedEnemiesRespawnArray = (GameObject[]) groundedEnemiesArray.Clone();
    }
    /*
    public int FindEnemiesRemaining()
    {

        //for (int i = 0; i < groundedEnemiesArray.Length; i++)
        //{
        //Copy(groundedEnemiesArray, groundedEnemiesRespawnArray, groundedEnemiesArray.length);
        //}

        groundedEnemiesArray = GameObject.FindGameObjectsWithTag("GroundedEnemy");
        int numberOfRemainingEnemies = 0;
        foreach(GameObject remainingEnemy in groundedEnemiesArray)
        {
            numberOfRemainingEnemies++;
        }
        Debug.Log("ENEMIES REMAINING: " + numberOfRemainingEnemies);
        return numberOfRemainingEnemies;
    }

    public void DestroyOriginalArray()
    {
    }
    */
    
}
