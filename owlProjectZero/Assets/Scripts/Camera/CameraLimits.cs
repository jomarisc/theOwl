using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// [ExecuteInEditMode]
// [SaveDuringPlay]
// [AddComponentMenu("")]
public class CameraLimits : CinemachineExtension
{
    [SerializeField] private Vector2 minCoordinates;
    [SerializeField] private Vector2 maxCoordinates;
    [SerializeField] private bool lockRotation;
    [SerializeField] private Vector3 idealRotation;
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
                                                      CinemachineCore.Stage stage,
                                                      ref CameraState state,
                                                      float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            Vector3 position = state.RawPosition;
            if(position.x < minCoordinates.x ||
               position.x > maxCoordinates.x ||
               position.y < minCoordinates.y ||
               position.y > maxCoordinates.y)
            {

                if(position.x < minCoordinates.x)
                {
                    position.x = minCoordinates.x;
                    // Debug.Log("Past minX");
                    // Debug.Break();
                }
                else if(position.x > maxCoordinates.x)
                {    
                    position.x = maxCoordinates.x;
                    // Debug.Log("Past maxX");
                    // Debug.Break();
                }

                if(position.y < minCoordinates.y)
                {
                    position.y = minCoordinates.y;
                    // Debug.Log("Past minY");
                    // Debug.Break();
                }
                else if(position.y > maxCoordinates.y)
                {
                    position.y = maxCoordinates.y;
                    // Debug.Log("Past maxY");
                    // Debug.Break();
                }

                state.RawPosition = position;
            }
        }

        if(stage == CinemachineCore.Stage.Aim && lockRotation)
        {
            Quaternion rotation = state.RawOrientation;
            Vector3 euler = rotation.eulerAngles;
            euler = idealRotation;
            rotation.eulerAngles = euler;
            state.RawOrientation = rotation;
        }
    }
}
