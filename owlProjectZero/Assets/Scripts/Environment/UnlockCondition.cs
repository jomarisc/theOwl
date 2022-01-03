﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCondition : MonoBehaviour
{
    enum UnlockType {DefeatAll, DefeatSpecific, CollectAll, CollectSpecific, InteractAll, InteractSpecific}

    private Room myRoom;
    [SerializeField] private UnlockType type = UnlockType.DefeatAll;

    void Awake()
    {
        SetUpRoom(type);
    }

    void OnEnable()
    {
        EnemyDead.OnEnemyDeath += CheckUnlockCondition;
    }

    void OnDisable()
    {
        EnemyDead.OnEnemyDeath -= CheckUnlockCondition;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRoom = GetComponent<Room>();
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
        // bool noMoreEnemies = false;
        // foreach (var enemy in myRoom.enemyColliders)
        // {
        //     if(enemy != null)
        //         return false;
        // }
        // noMoreEnemies = true;
        return myRoom.enemyColliders.Count <= 0; // || noMoreEnemies;
    }

    void CheckUnlockCondition()
    {
        if(myRoom.isLocked && ConditionIsSatisfied(type))
            myRoom.Deactivate();
        else
            Debug.Log("Room unlock condition not yet satisfied");
    }
}
