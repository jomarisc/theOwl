using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    public int sceneIndex;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("player");
        //DontDestroyOnLoad(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
