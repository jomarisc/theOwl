using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : MonoBehaviour
{
    [Header("Necessary Attachments")]
    [SerializeField] private playerControl player = null;

    void OnEnable()
    {
        player = GameObject.Find("player").GetComponent<playerControl>();
        player.input.Gameplay.Disable();
    }

    void OnDisable()
    {
        player.input.Gameplay.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.input.UI.Cancel.triggered || player.input.UI.Activate.triggered)
            gameObject.SetActive(false);
    }
}
