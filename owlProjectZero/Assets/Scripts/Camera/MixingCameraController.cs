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
        myMixingCamera = GameObject.Find("MixingCamera").GetComponent<CinemachineMixingCamera>();
    }

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
    }
}

