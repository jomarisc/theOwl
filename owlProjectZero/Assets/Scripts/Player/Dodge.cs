// This class's purpose is to be able to modify
// Character dodge parameters in the Unity Editor

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    [Range(0f, 1f)] public float alpha = 0.5f;
    public float fullDuration;
    [HideInInspector] public float dodgeDuration;
    [field: SerializeField] public bool USING_GRAVITY { get; private set; }
    [field: SerializeField] public float PUSH_FORCE { get; private set; }
    [field: SerializeField] public float DRAG { get; private set; }

    // Currently Only toggles player collisions with Enemy-related rigidbodies/colliders
    public void PerformDodge()
    {
        if(dodgeDuration > 0f)
        {
            // Stop checking collisions with player hurtbox and enemy-related physics layers
            Physics.IgnoreLayerCollision(9, 10, true); // Player x Enemies
            Physics.IgnoreLayerCollision(9, 12, true); // Player x Enemies' Attacks
            Physics.IgnoreLayerCollision(9, 15, true); // Player x Enemies' Bodu Hitbox
        }
        // This branch should only be called once as dodgeDuration becomes negative
        else
        {
            Physics.IgnoreLayerCollision(9, 15, false); // Player x Enemies' Body Hitbox
            Physics.IgnoreLayerCollision(9, 12, false); // Player x Enemies' Attacks
            Physics.IgnoreLayerCollision(9, 10, false); // Player x Enemies
        }
    }
}
