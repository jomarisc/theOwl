using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Publisher class. This is an added component to Player folder and does 
// not require a subscriber class to exist.
public class TestEvent : MonoBehaviour
{
    // Responsible for firing off the event
    // Events work with delegates and EventHandler is simply the standard delegate
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    // Using EventArgs is the standard way of passing in more information
    // This class derives from EventArgs
    public class OnSpacePressedEventArgs : EventArgs
    {
        // Define fields that are needed
        public int spaceCount;

    }

    // Examples of using different delegates instead of EventHandler
    // Making an event of delegate type
    public event TestEventDelegate OnFloatEvent;
    // Defining own delegate
    public delegate void TestEventDelegate(float f);
    // Can also use the default delegate called action
    // Can also be defined with multiple parameters
    public event Action<bool, int> OnActionEvent;

    // Works just like all the events but results will appear in editor and not console.
    // Main benefit is that you can easily set them in the editor for testing
    public UnityEvent OnUnityEvent;

    private int spaceCount;

    // Start is called before the first frame update
    private void Start()
    {

    }
 
    // Update is called once per frame
    private void Update()
    {
        // Triggers events based on pressing spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Space pressed!
            spaceCount++;
            if (OnSpacePressed != null) OnSpacePressed(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });

            if (OnFloatEvent != null) OnFloatEvent(5.5f);

            if (OnActionEvent != null) OnActionEvent(true, 56);

            OnUnityEvent?.Invoke();
        }
    }
}
