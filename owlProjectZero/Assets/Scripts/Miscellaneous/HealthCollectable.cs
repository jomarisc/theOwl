using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : Collectable
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<playerControl>() != null)
        {
            
            // Refers to the heartbar of the collider passed into this function
            // Then uses Heal of this from the heartbar's heartsHealthSystem
            col.gameObject.GetComponent<playerControl>().heartbar.heartsHealthSystem.Heal(2);

            // Destroy this game object upon collision
            Destroy(this.gameObject);

        }
    }
}
