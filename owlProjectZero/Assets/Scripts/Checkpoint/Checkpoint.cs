using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public enum state
    {
      Inactive, Active, Used, Locked  
    };

    public state status;

    public Sprite[] sprites;

    void Update()
    {
        ChangeColor();
    }
    
    // Update is called once per frame
    void ChangeColor()
    {
        if(status == state.Inactive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (status == state.Active)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (status == state.Used)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (status == state.Locked)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }
}
