using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Room : MonoBehaviour
{
    private Collider box;
    [SerializeField] private Collider leftWall;
    [SerializeField] private Collider rightWall;
    [SerializeField] private string unlockCondition;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out playerControl player))
        {
            leftWall.enabled = true;
            rightWall.enabled = true;
        }
    }
}
