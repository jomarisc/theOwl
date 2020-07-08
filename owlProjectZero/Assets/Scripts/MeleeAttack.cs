using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float knockback = 5f;
    public float knockbackAngle = 45f;
    public float damage = 1;
    public int activeFrames = 10;

    void OnEnable()
    {
        activeFrames = 10;
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
