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
}
