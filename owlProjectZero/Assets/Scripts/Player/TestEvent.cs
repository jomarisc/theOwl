using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    public event EventHandler OnSpacePressed;

    // Start is called before the first frame update
    private void Start()
    {
        OnSpacePressed += Testing_OnSpacePressed;
    }

    // In order to subscribe to event, we need a function that will
    // receive that event. Function signature needs to be same as event.
    private void Testing_OnSpacePressed(object sender, EventArgs e)
    {

        Debug.Log("Space pressed!");

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
