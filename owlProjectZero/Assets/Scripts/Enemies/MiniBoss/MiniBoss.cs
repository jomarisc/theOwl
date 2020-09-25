using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : HeavyEnemy
{
    [Header("Other")]
    public GameObject slamHitbox;
    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new MiniBossIdle(this);
            myState = defaultState;
        }
    }
}
