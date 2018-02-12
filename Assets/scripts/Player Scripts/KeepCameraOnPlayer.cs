using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCameraOnPlayer : MonoBehaviour
{
    public Camera PlayerCamera;
    public Vector3 OffsetVector3;

    void FixedUpdate()
    {
        PlayerCamera.gameObject.transform.position = transform.position + OffsetVector3;
    }
}
