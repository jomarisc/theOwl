using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Character myBehavior;
    private Room myRoom = null;
    // Start is called before the first frame update
    void Start()
    {
        myBehavior = gameObject.GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out Room room))
        {
            myRoom = col.GetComponent<Room>();
            myRoom.enemyAIManagers.Add(this);
        }
    }

    void OnBecameVisible()
    {
        if(myRoom == null)
            myBehavior.enabled = true;
        else
            myBehavior.enabled = false;
    }

    void OnBecameInvisible()
    {
        if(myRoom != null)
            myBehavior.enabled = false;
    }

    public void EnableBehavior()
    {
        myBehavior.enabled = true;
    }

    public void DisableBehavior()
    {
        myBehavior.enabled = false;
    }
}
