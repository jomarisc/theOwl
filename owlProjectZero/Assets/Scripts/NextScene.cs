using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class NextScene : MonoBehaviour
{
    public int sceneIndex;
    private GameObject player;
    public GameObject Camera;
 
    void SetClipPlane() {
        Camera = GameObject.Find("MainCamera");
        Camera.GetComponent<Camera>().farClipPlane = 15;
    }

    void Awake()
    {
        SetClipPlane();
        SceneManager.sceneLoaded += (scene, mode) => SetClipPlane();
    }
    
    // Start is called before the first frame update
    void Start()
    {
    
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
    }
}
