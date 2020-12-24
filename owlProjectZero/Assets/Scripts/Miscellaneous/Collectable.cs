using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private float heightOffset;

    private GameObject player;
    protected playerControl playerScript;
    public Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        Transform prnt = transform.parent;
        heightOffset = transform.position.y;
        player = GameObject.Find("player");
        playerScript = player.GetComponent<playerControl>();
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
        newPos[1] = Mathf.Sin(Time.time * 2f) * amplitude + height + amplitude;
        transform.position = newPos;
    }
}
