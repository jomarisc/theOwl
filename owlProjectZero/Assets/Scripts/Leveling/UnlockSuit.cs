using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSuit : MonoBehaviour
{
    private playerControl player;
    public static event SuitUnlocked OnSuitUnlocked;
    public delegate void SuitUnlocked();

    void Start()
    {
        this.enabled = GlobalVars.hasReachedTheElevator;
    }

    void Update()
    {
        if(player != null && player.input.Gameplay.Interact.triggered && player.data.maxSpeed == player.data.groundSpeed)
        {
            if(GlobalVars.playerHasUnlockedSuit)
                Debug.Log("Already unlocked the suit, dummy");
            else
            {
                Debug.Log("Unlock Suit!");
                GlobalVars.playerHasUnlockedSuit = true;
                OnSuitUnlocked?.Invoke();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl p))
            player = p;
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl p))
            player = null;
    }
}
