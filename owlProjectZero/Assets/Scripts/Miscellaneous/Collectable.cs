using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private float heightOffset;
    private static int numCollectables = 0;

    private GameObject player;
    private playerControl playerScript;
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

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<playerControl>() != null 
            && this.gameObject.tag == "Experience")
        {
            numCollectables++;
            gameObject.SetActive(false);

            // Refers to the levelSystem of the collider passed into this function.
            // Then uses AddExperience of this levelSystem.
            col.gameObject.GetComponent<playerControl>().levelSystem.AddExperience(50);
            
        }
        else if (col.gameObject.GetComponent<playerControl>() != null
          && this.gameObject.tag == "Currency")
        {
            playerScript.AddCurrency(20);
            currencyText.text = "Currency: " + playerScript.GetCurrency();
            gameObject.SetActive(false);
        }
    }
}
