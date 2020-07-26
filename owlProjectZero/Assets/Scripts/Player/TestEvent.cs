using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Publisher class. This is an added component to Player folder and does 
// not require a subscriber class to exist.
public class TestEvent : MonoBehaviour
{
    // Responsible for firing off the event
    public event EventHandler OnSpacePressed;

    // Start is called before the first frame update
    private void Start()
    {

    }
 
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Space pressed!
            if (OnSpacePressed != null) OnSpacePressed(this, EventArgs.Empty);

        }
    }
}
