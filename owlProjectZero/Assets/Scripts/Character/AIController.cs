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

    void OnBecameVisible()
    {
        myBehavior.enabled = true;
    }

    void OnBecameInvisible()
    {
        myBehavior.enabled = false;
    }
}
