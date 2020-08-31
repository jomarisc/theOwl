using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Character myBehavior;
    // Start is called before the first frame update
    void Start()
    {
        myBehavior = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameVisible()
    {
        Debug.Log("Visible");
        myBehavior.enabled = true;
    }

    void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        myBehavior.enabled = false;
    }
}
