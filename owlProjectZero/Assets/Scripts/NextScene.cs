using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    public static List<NextScene> sceneTriggers = new List<NextScene>();
    private playerControl player;
    private PlayableDirector myDirector;
    [Tooltip("Timeline asset for entering a new scene")]
    [SerializeField] private PlayableAsset startTransition = null;
    [Tooltip("Timeline asset for moving on to a different scene")]
    [SerializeField] private PlayableAsset endTransition = null;
    public int sceneIndex;
    public static int previousSceneIndex;
    public Transform spawnPoint;

    void Awake()
    {
        sceneTriggers.Add(this);
        player = GameObject.Find("player").GetComponent<playerControl>();
        player.enabled = false;

        Debug.Log("previousSceneIndex is " + previousSceneIndex);

        if(previousSceneIndex == sceneIndex)
        {
            SpawnAtMyPointInstead();
        }

        myDirector = GetComponent<PlayableDirector>();
        myDirector.playableAsset = startTransition;
        myDirector.Play();
        myDirector.stopped += ReenablePlayer;

        DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable()
    {
        myDirector.stopped -= LoadNextScene;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.TryGetComponent(out playerControl p))
        {
            Debug.Log("this is scene index " + sceneIndex);
            previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
            myDirector.playableAsset = endTransition;
            myDirector.Play();
            player.enabled = false;
            myDirector.stopped += LoadNextScene;
        }
    }

    void LoadNextScene(PlayableDirector director)
    {
        // Debug.Log("Before deleting scenetriggers");
        // for(int n = 0; n < sceneTriggers.Count; n++)
        // {
        //     Debug.Log(sceneTriggers[n]);
        // }

        // Remove all other scene triggers from list of scene triggers and destroy them
        // int i = 0;
        while(sceneTriggers.Count > 1)
        {
            if(sceneTriggers[0] != this)
            {
                Destroy(sceneTriggers[0].gameObject);
                sceneTriggers.Remove(sceneTriggers[0]);
            }
            else if(sceneTriggers[1] != this)
            {
                Destroy(sceneTriggers[1].gameObject);
                sceneTriggers.Remove(sceneTriggers[1]);
            }
            // i++;
        }

        // Debug.Log("After deleting scenetriggers");
        // for(int n = 0; n < sceneTriggers.Count; n++)
        // {
        //     Debug.Log(sceneTriggers[n]);
        // }

        // Load next scene
        if(director == myDirector)
            SceneManager.LoadSceneAsync(sceneIndex);
        
        // Finally, destroy this one
        sceneTriggers.Remove(this);
        Destroy(this.gameObject);
    }

    public static void ClearSceneTriggers()
    {

        // int i = 0;
        while(sceneTriggers.Count > 0)
        {
            Destroy(sceneTriggers[0].gameObject);
            sceneTriggers.Remove(sceneTriggers[0]);
            // i++;
        }

        for(int n = 0; n < sceneTriggers.Count; n++)
        {
            Debug.Log(sceneTriggers.Count);
            Debug.Log(sceneTriggers[n]);
        }
    }

    void ReenablePlayer(PlayableDirector director)
    {
        if(director == myDirector)
        {
            player.enabled = true;
            myDirector.stopped -= ReenablePlayer;
        }
    }

    void SpawnAtMyPointInstead()
    {
        // if the player is dead, let the ReturnToCheckpoint script handle the player spawn position
        if(CheckpointsHandler.isDead == false && GlobalVars.hasPressMainMenu == false)
        {
            Debug.Log("here in SpawnAtMyPointInstead bc player is dead");
            player.transform.position = spawnPoint.position;
        }
    }
}
