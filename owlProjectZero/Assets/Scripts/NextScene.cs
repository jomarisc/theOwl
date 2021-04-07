using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    public int sceneIndex;
    private playerControl player;
    //private GameObject player;
    public GameObject Camera;

    public string exitPoint;
 
    // void SetClipPlane() {
    //     Camera = GameObject.Find("MainCamera");
    //     Camera.GetComponent<Camera>().farClipPlane = 15;
    // }

    // void Awake()
    // {
    //     SetClipPlane();
    //     SceneManager.sceneLoaded += (scene, mode) => SetClipPlane();
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        //SetClipPlane();
        //if (player.position > )
        SceneManager.LoadSceneAsync(sceneIndex);
        player.startPoint = exitPoint;
    }
}
