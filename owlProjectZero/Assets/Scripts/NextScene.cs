using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    private static List<NextScene> sceneTriggers = new List<NextScene>();
    private playerControl player;
    private PlayableDirector myDirector;
    [Tooltip("Timeline asset for entering a new scene")]
    [SerializeField] private PlayableAsset startTransition = null;
    [Tooltip("Timeline asset for moving on to a different scene")]
    [SerializeField] private PlayableAsset endTransition = null;
    public int sceneIndex;

    public string exitPoint;

    void Start()
    {
        //player = FindObjectOfType<playerControl>();
    }

    void Awake()
    {
        sceneTriggers.Add(this);
        player = GameObject.Find("player").GetComponent<playerControl>();
        player.enabled = false;

        myDirector = GetComponent<PlayableDirector>();
        myDirector.playableAsset = startTransition;
        myDirector.Play();
        myDirector.stopped += ReenablePlayer;

        //DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable()
    {
        myDirector.stopped -= LoadNextScene;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.TryGetComponent(out playerControl p))
        {
            myDirector.playableAsset = endTransition;
            myDirector.Play();
            player.enabled = false;
            myDirector.stopped += LoadNextScene;
        }
    }

    void LoadNextScene(PlayableDirector director)
    {
        // Remove all other scene triggers from list of scene triggers and destroy them
        int i = 0;
        while(i < sceneTriggers.Count)
        {
            if(sceneTriggers[i] != this)
            {
                Destroy(sceneTriggers[i].gameObject);
                sceneTriggers.Remove(sceneTriggers[i]);
            }
            i++;
        }

        // Load next scene
        if(director == myDirector)
            // Changing player's start point to work with transfer point
            player.startPoint = exitPoint; //exit point
            SceneManager.LoadSceneAsync(sceneIndex);
        
        // Finally, destroy this one
        sceneTriggers.Remove(this);
        Destroy(this.gameObject);
    }

    void ReenablePlayer(PlayableDirector director)
    {
        if(director == myDirector)
        {
            player.enabled = true;
            myDirector.stopped -= ReenablePlayer;
        }
    }
}
