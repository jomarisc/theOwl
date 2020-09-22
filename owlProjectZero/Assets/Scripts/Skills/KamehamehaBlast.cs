using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaBlast : IState
{
    private readonly Character user;
    private Attack blast;
    
    public KamehamehaBlast(Character c, Attack b)
    {
        user = c;
        blast = b;
    }

    public void Enter()
    {
        blast.gameObject.SetActive(true);
        user.Attack(blast.gameObject);
        // user.Attack(); // Should change attack method to take in
                          // a GameObject to change positions

        // Should have a way to disable listening for useActiveSkill input

    }

    public void Exit()
    {
        if(blast.gameObject.activeInHierarchy)
        {
            blast.gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        if(blast.gameObject.activeInHierarchy)
            return null;
        return new PlayerIdle((playerControl) user); // Should refactor idle
                                                     // state to take in a
                                                     // generic character type
    }
}
