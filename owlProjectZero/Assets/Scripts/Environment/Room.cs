using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(UnlockCondition))]
public class Room : MonoBehaviour
{
    // private int unlockCounter = 0; // This variable is used for
    //                                // counting down certain unlock conditions
    private Collider box;
    [SerializeField] private NextScene[] Exits = null;
    [SerializeField] private Collider leftWall = null;
    [SerializeField] private Collider rightWall = null;
    public bool isLocked = false;
    public List<Collider> enemyColliders { get; private set; }
    public List<AIController> enemyAIManagers;

    void Awake()
    {
        enemyColliders = new List<Collider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl player))
        {
            SetLock(true);
            foreach (var AIComponent in enemyAIManagers)
            {
                AIComponent.EnableBehavior();
            }
        }
        // else if(col.gameObject.TryGetComponent(out Enemy enemy))
        // {
        //     if(!enemyColliders.Contains(col))
        //     {
        //         enemyColliders.Add(col);
        //         Debug.Log("Added enemy to enemy list");
        //         Debug.Log("Num Enemies in room:" + enemyColliders.Count);
        //         Debug.Break();
        //     }
        // }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl player))
        {
            foreach (var AIComponent in enemyAIManagers)
            {
                AIComponent.DisableBehavior();
            }
        }
    }

    // // Might have performance issues due to calling GetComponent
    // private void OnTriggerStay(Collider col)
    // {
    //     // Check if obj has Enemy script attached to it
    //     if(col.gameObject.TryGetComponent(out Enemy enemy))
    //     {
    //         // Check if obj is not in list of enemies
    //         if(!enemyColliders.Contains(col))
    //         {
    //             enemyColliders.Add(col);
    //         }
    //     }
    // }

    public void SetLock(bool isLocked)
    {
        foreach (var exit in Exits)
        {
            // We can assume each NextScene object has a collider bc it requires one
            exit.GetComponent<Collider>().enabled = !isLocked;
        }
        // leftWall.enabled = isLocked;
        // rightWall.enabled = isLocked;
        this.isLocked = isLocked;
    }

    // Call this function so that the room cannot be triggered again after
    // the unlock condition has already been met
    public void Deactivate()
    {
        foreach (var exit in Exits)
        {
            // We can assume each NextScene object has a collider bc it requires one
            exit.GetComponent<Collider>().enabled = true;
        }
        // leftWall.enabled = false;
        // rightWall.enabled = false;
        isLocked = false;
        Debug.Log("Room unlocked!");
        // Debug.Break();
        // gameObject.SetActive(false);
    }
}
