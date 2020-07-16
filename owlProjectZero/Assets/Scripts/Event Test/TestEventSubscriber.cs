using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventSubscriber : MonoBehaviour
{

    private void Start()
    {
        TestEvent testEvent = GetComponent<TestEvent>();
        testEvent.OnSpacePressed += TestEvent_OnSpacePressed; 
    }

    private void TestEvent_OnSpacePressed(object sender, EventArgs e)
    {
        Debug.Log("Space!");
    }
}
