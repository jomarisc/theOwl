using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
public class CameraBounds : MonoBehaviour
{
    private BoxCollider myBounds;
    [SerializeField] private CinemachineVirtualCamera myVirtualCamera;
    [SerializeField] private CinemachineMixingCamera myMixingCamera;
    public static CinemachineVirtualCamera[] virtualCameras;

    void Awake()
    {
        // Get all virtual cameras within the scene
        virtualCameras = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
        myBounds = GetComponent<BoxCollider>();
    }

    // void OnTriggerEnter(Collider col)
    // {
    //     // Make sure that this gameobject's physics layer only checks for collisions with the player
    //     // foreach (CinemachineVirtualCamera camera in virtualCameras)
    //     // {
    //     //     if(camera == myVirtualCamera)
    //     //         myVirtualCamera.Priority = 2;
    //     //     else
    //     //         camera.Priority = 1;
    //     // }
    //     // myVirtualCamera.Follow = col.transform;
    //     // myVirtualCamera.LookAt = col.transform;
    //     // myVirtualCamera.Priority = 1;

    //     // Start following and looking at the player with the top camera
    //     int topCamera = 0;
    //     myMixingCamera.ChildCameras[topCamera].Follow = col.transform;
    //     myMixingCamera.ChildCameras[topCamera].LookAt = col.transform;
    // }

    void OnTriggerStay(Collider col)
    {
        int topCamera = 0;
        int bottomCamera = 1;
        float bottomOfBounds = myBounds.transform.position.y - myBounds.size.y * transform.lossyScale.y / 2;
        float topCameraPriority = (col.transform.position.y - bottomOfBounds) + 1f;
        myMixingCamera.ChildCameras[topCamera].Priority = (int)topCameraPriority;
        myMixingCamera.SetWeight(topCamera, topCameraPriority);
        float bottomCameraPriority = (transform.lossyScale.y - (col.transform.position.y - bottomOfBounds)) + 1f;
        myMixingCamera.ChildCameras[bottomCamera].Priority = (int)bottomCameraPriority;
        myMixingCamera.SetWeight(bottomCamera, bottomCameraPriority);
        Debug.Log("Bottom of Bounds: " + bottomOfBounds + "\nPlayer PosY: " + col.transform.position.y);
        // Vector3 localPlayerPos = col.transform.position - transform.position;
        // Debug.Log("Local Y: " + localPlayerPos.y);
    }

    // void OnTriggerExit(Collider col)
    // {
    //     // myVirtualCamera.Follow = null;
    //     // myVirtualCamera.LookAt = null;
    //     // myVirtualCamera.Priority = 0;
        
    //     // Stop Following and Looking with the top camera
    //     int topCamera = 0;
    //     myMixingCamera.ChildCameras[topCamera].Follow = null;
    //     myMixingCamera.ChildCameras[topCamera].LookAt = null;
    // }
}

