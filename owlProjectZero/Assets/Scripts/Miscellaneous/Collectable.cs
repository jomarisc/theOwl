﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float heightOffset;
    private static int numCollectables = 0;
    // Start is called before the first frame update
    void Start()
    {
        Transform prnt = transform.parent;
        heightOffset = prnt.localScale.y / 2 + prnt.position.y;
        Debug.Log(heightOffset);
    }

    // Update is called once per frame
    void Update()
    {
        Float(heightOffset);
        if(!gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(true);
        }
    }

    protected void Float(float height)
    {
        Vector3 newPos = transform.position;
        float amplitude = 0.25f;
        newPos[1] = (Mathf.Sin(Time.time * 2f) + 1.25f) * amplitude + height + (1 - amplitude);
        transform.position = newPos;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<playerControl>() != null)
        {
            numCollectables++;
            Debug.Log("Collected " + numCollectables + " collectables");
            gameObject.SetActive(false);
        }
    }
}