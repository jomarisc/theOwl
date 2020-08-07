using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public HealthbarController healthbar;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TestEnemy")
        {
            if (healthbar.currentHealth > 0)
            {
                healthbar.Damage(2);
                //Debug.Log("Current Health: " + player.getHealth());
            }
        }
    }
}
