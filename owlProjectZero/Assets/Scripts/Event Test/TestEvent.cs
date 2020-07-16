// Script in charge of firing off the event

using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{

	public event EventHandler OnSpacePressed;

	private void Start()
    {


	}

	private void Update()
    {

		if(Input.GetKeyDown(KeyCode.Space))
        {
			// Space pressed!
			if (OnSpacePressed != null)
                OnSpacePressed(this, EventArgs.Empty);

		}

	}

}