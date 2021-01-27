using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    private playerControl player;
    private PlayableDirector myDirector;
    [Tooltip("Timeline asset for entering a new scene")]
    [SerializeField] private PlayableAsset startTransition;
    [Tooltip("Timeline asset for moving on to a different scene")]
    [SerializeField] private PlayableAsset endTransition;
    public int sceneIndex;

    void Awake()
    {
        player = GameObject.Find("player").GetComponent<playerControl>();
        player.enabled = false;

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
        myDirector.playableAsset = endTransition;
        myDirector.Play();
        player.enabled = false;
        myDirector.stopped += LoadNextScene;
    }

    void LoadNextScene(PlayableDirector director)
    {
        if(director == myDirector)
            SceneManager.LoadSceneAsync(sceneIndex);
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
