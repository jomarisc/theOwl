using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : HeavyEnemy
{
    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new MiniBossIdle(this);
            myState = defaultState;
            Debug.Log(myState);
        }
    }
}
