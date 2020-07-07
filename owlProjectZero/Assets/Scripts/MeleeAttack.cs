using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float activeFrames = 10f;
    public float knockback = 5f;
    public int damage = 1;

    void OnEnable()
    {
        activeFrames = 10f;
    }

    void Update()
    {
        activeFrames--;
        if(activeFrames < 0f)
        {
            gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        col.gameObject.SetActive(false);
    }
}
