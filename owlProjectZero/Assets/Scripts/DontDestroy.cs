using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //public static bool objectExists = false;
    public static bool playerExists = false;
    public static bool gameplayCanvasExists = false;

    public void DontDestroyObjects()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        //GameObject findPlayer = GameObject.Find("player");
        //GameObject findGameplayCanvas = GameObject.Find("GameplayCanvas");
        
        // //if (objs.Length > 1)
        // //{
        // //    Destroy(this.gameObject);
        // //}

        // // if(!objectExists)
        // // {
        // //     objectExists = true;
        // //     DontDestroyOnLoad(transform.gameObject);
        // // } else {
        // //     Destroy(gameObject);
        // // }

        if(!playerExists)
        {
            Debug.Log("DontDestroyOnLoad Occurring");
            //Debug.Log("Attached gameObject: " + this.gameObject.ToString());
            // Trying to print out objs array
            // for(int i = 0; i < objs.Length; i++) {
            //     Debug.Log("objs contents: " + objs[i]);
            // }
            // Debug.Log("objs.Length: " + objs.Length);

            playerExists = true;
            // DontDestroyOnLoad(findPlayer);
            // DontDestroyOnLoad(findGameplayCanvas);
            for (int index = 0; index < objs.Length; index++)
            {
                DontDestroyOnLoad(objs[index]);
                //objs.Length -= 1;
            } 

        }else{
            //Debug.Log("Test 2");
            // Destroy(findPlayer);
            // Destroy(findGameplayCanvas);
            // if (objs.Length > 0)
            // {
            
            //for (index = 0; index < objs.Length; index++)
            //{
            //    Destroy(objs[index]);  
            //}
            Debug.Log("Destroying Occurring");
            // Destroy the object that is being created
            Destroy(gameObject); 
        }
        
        // if(!gameplayCanvasExists)
        // {
        //     Debug.Log("Attached gameObject: " + this.gameObject.ToString());
        //     gameplayCanvasExists = true;
        //     DontDestroyOnLoad(findGameplayCanvas);
        // } else {
        //     Destroy(findGameplayCanvas);
        // } 

        //DontDestroyOnLoad(this.gameObject);
        
    }
    // void Awake()
    // {
    //     GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

    //     if (objs.Length > 1)
    //     {
    //         Destroy(this.gameObject);
    //     }

    //     DontDestroyOnLoad(this.gameObject);
    // }
}