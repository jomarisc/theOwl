using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public Enemy(int maxJumps, int maxDodges, float dodgeDuration) : base(maxJumps, maxDodges, dodgeDuration)
    {}

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }
}
