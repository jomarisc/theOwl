using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public HealthbarController healthbar;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "GroundedEnemy")
        {
            if (healthbar.playerScript.data.health > 0)
            {
                healthbar.Damage(2);
                //Debug.Log("Current Health: " + player.getHealth());
            }
        }
        
    }
}
