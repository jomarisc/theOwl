using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHasPressMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalVars.hasPressMainMenu = true;
        Debug.Log("GlobalVars.hasPressMainMenu is " + GlobalVars.hasPressMainMenu);
    }
}
