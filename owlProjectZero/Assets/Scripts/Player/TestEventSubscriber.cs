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
        testingEvent.OnFloatEvent += TestEvent_OnFloatEvent;
        testingEvent.OnActionEvent += TestEvent_OnActionEvent;
    }

    private void TestEvent_OnActionEvent(bool arg1, int arg2)
    {

        Debug.Log(arg1 + " " + arg2);

    }

    private void TestEvent_OnFloatEvent(float f)
    {

        Debug.Log("Float: " + f);

    }

    // In order to subscribe to event, we need a function that will
    // receive that event. Function signature needs to be same as event.
    private void TestEvent_OnSpacePressed(object sender, TestEvent.OnSpacePressedEventArgs e)
    {

        Debug.Log("Space is pressed! " + e.spaceCount);
        //TestEvent testingEvent = GetComponent<TestEvent>();
        //testingEvent.OnSpacePressed -= TestEvent_OnSpacePressed; // Unsubscribes to publisher

    }

    public void TestingUnityEvent()
    {

        Debug.Log("TestingUnityEvent");

    }

}
