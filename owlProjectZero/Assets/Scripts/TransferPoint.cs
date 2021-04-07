using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPoint : MonoBehaviour
{
    private playerControl player;

    public string pointName;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerControl>();

        if(player.startPoint == pointName) 
        {
            player.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
