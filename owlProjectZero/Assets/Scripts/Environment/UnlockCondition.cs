using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCondition : MonoBehaviour
{
    enum UnlockType {DefeatAll, DefeatSpecific, CollectAll, CollectSpecific, InteractAll, InteractSpecific}

    private Room myRoom;
    [SerializeField] private UnlockType type;

    void Awake()
    {
        SetUpRoom(type);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRoom = GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ConditionIsSatisfied(type))
            myRoom.Deactivate();
    }

    // Given the type of unlock condition, set up the room accordingly
    void SetUpRoom(UnlockType ut)
    {

    }

    // Given the type of unlock condition, check if the condition is satisfied
    bool ConditionIsSatisfied(UnlockType ut)
    {
        switch(ut)
        {
            case UnlockType.DefeatAll:
                return DefeatAllIsSatisfied();
            case UnlockType.DefeatSpecific:
                break;
            case UnlockType.CollectAll:
                break;
            case UnlockType.CollectSpecific:
                break;
            case UnlockType.InteractAll:
                break;
            case UnlockType.InteractSpecific:
                break;
        }
        return false;
    }

    void InitializeDefeatAll()
    {
        
    }
    
    bool DefeatAllIsSatisfied()
    {
        return myRoom.enemyColliders.Count <= 0;
    }
}
