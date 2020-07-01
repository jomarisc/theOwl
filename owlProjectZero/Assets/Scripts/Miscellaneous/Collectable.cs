using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float heightOffset;
    private static int numCollectables = 0;
    // Start is called before the first frame update
    void Start()
    {
        heightOffset = transform.position.y;
        Debug.Log(heightOffset);
    }

    // Update is called once per frame
    void Update()
    {
        Float(0.5f);
        if(!gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(true);
        }
    }

    protected void Float(float height)
    {
        Vector3 newPos = transform.position;
        newPos[1] = (Mathf.Sin(Time.time) + heightOffset * 4) * (heightOffset / 4);
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
