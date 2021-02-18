using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherPoint : EnvironmentElement
{
    public enum TetherMethod {Original, Vertical}

    public TetherMethod tetherType;
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl player))
        {
            col.GetComponent<playerControl>().tetherAbility.activeTetherPoint = this;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl player))
        {
            col.GetComponent<playerControl>().tetherAbility.activeTetherPoint = null;
        }
    }
}
