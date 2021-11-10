using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
public class MixingCameraController : MonoBehaviour
{
    private BoxCollider myBounds;
    private CinemachineMixingCamera myMixingCamera;

    void Awake()
    {
        myBounds = GetComponent<BoxCollider>();
        myMixingCamera = GetComponentInParent<CinemachineMixingCamera>();
    }

    void OnTriggerEnter(Collider col)
    {
        myMixingCamera.Priority = 10;
        CalculateCameraPriority(col.transform.position.y);
    }

    void OnTriggerStay(Collider col)
    {
        CalculateCameraPriority(col.transform.position.y);
    }

    void OnTriggerExit(Collider col)
    {
        int topCamera = 0;
        int bottomCamera = 1;
        myMixingCamera.ChildCameras[topCamera].Priority = 0;
        myMixingCamera.ChildCameras[bottomCamera].Priority = 0;
        myMixingCamera.Priority = 0;
    }

    void CalculateCameraPriority(float yPosition)
    {
        int topCamera = 0;
        int bottomCamera = 1;
        float bottomOfBounds = myBounds.transform.position.y - myBounds.size.y * transform.lossyScale.y / 2;
        float topCameraPriority = (yPosition - bottomOfBounds) + 1f;
        myMixingCamera.ChildCameras[topCamera].Priority = (int)topCameraPriority;
        myMixingCamera.SetWeight(topCamera, topCameraPriority);
        float bottomCameraPriority = (transform.lossyScale.y - (yPosition - bottomOfBounds)) + 1f;
        myMixingCamera.ChildCameras[bottomCamera].Priority = (int)bottomCameraPriority;
        myMixingCamera.SetWeight(bottomCamera, bottomCameraPriority);
    }
}

