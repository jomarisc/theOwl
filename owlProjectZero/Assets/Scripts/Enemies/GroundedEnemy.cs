using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : Enemy
{
    // Initializing maxJumps, maxDodges, dodgeDuration
    public GroundedEnemy() : base(0, 1, 5f)
    {}
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
    }
}
