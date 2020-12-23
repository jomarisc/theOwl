using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceCollectable : Collectable
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<playerControl>() != null)
        {
            //gameObject.SetActive(false);
            Destroy(this.gameObject);


            // Refers to the levelSystem of the collider passed into this function.
            // Then uses AddExperience of this levelSystem.
            col.gameObject.GetComponent<playerControl>().levelSystem.AddExperience(50);
            
        }
    }
}
