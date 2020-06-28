using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElement : MonoBehaviour
{
       private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        Collider sphereCollider = col.gameObject.GetComponent<SphereCollider>();
        foreach(ContactPoint contact in col.contacts)
        {
            if(contact.point.y > rb.position.y - sphereCollider.bounds.extents.y + 0.1f)
                return;
            else
            {
                col.gameObject.GetComponent<playerControl>().numJumps = playerControl.MAX_JUMPS;
            }
            // Debug.DrawRay(contact.point, Vector2.up, Color.cyan, 10f);
        }
        // Debug.Log("Collided with " + col.gameObject.name);
    }
}
