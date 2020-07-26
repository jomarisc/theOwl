using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventSubscriber : MonoBehaviour
{
    // Accesses TestEvent.cs and subscribes to it
    private void Start()
    {
        TestEvent testingEvent = GetComponent<TestEvent>();
        testingEvent.OnSpacePressed += TestEvent_OnSpacePressed; // Subscribes to publisher
    }

    // In order to subscribe to event, we need a function that will
    // receive that event. Function signature needs to be same as event.
    private void TestEvent_OnSpacePressed(object sender, EventArgs e)
    {

        Debug.Log("Space is pressed!");
        TestEvent testingEvent = GetComponent<TestEvent>();
        testingEvent.OnSpacePressed -= TestEvent_OnSpacePressed; // Unsubscribes to publisher

    }

}
