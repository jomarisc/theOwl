using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // Gets called when this becomes the current state
    void Enter();
    // Gets called when you leave this state
    void Exit();
    // Gets called for physics checking
    void FixedUpdate();
    // Gets called every frame if this is the current state
    // Return null to remain in the same state
    IState Update();
}
