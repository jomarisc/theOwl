using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElement : MonoBehaviour
{
    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.GetComponent<Character>() != null)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            Collider sphereCollider = col.gameObject.GetComponent<Collider>();
            foreach(ContactPoint contact in col.contacts)
            {
                if(contact.point.y > rb.position.y - sphereCollider.bounds.extents.y + 0.1f)
                    return;
                else
                {
                    // Check if the player managed to land on an environment piece
                    // but the jump refresh didn't work
                    if(col.gameObject.GetComponent<playerControl>().numJumps < playerControl.MAX_JUMPS)
                    {
                        col.gameObject.GetComponent<playerControl>().numJumps = playerControl.MAX_JUMPS;
                    }

                    // Same thing for refreshing number of dodges
                    if(col.gameObject.GetComponent<playerControl>().numDodges < playerControl.MAX_DODGES)
                    {
                        col.gameObject.GetComponent<playerControl>().numDodges = playerControl.MAX_DODGES;
                    }
                }
            }
        }
    }
}
