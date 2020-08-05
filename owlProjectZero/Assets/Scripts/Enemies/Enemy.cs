using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Enemy() : base(1, 1, 5.0f)
    {}

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
    }
}
