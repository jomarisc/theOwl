using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveScript : MonoBehaviour
{

    SaveManager saveManager;
    public GameObject player;
    public PlayerInputs input;
    playerControl pControl;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = this.GetComponent<SaveManager>();
        player = GameObject.FindWithTag("Player");
        pControl = player.GetComponent<playerControl>();
        input = pControl.input;
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Gameplay.Interact.triggered)
        {
            saveManager.saveGame();
        }
    }
}
