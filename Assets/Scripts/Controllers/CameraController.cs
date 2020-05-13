using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region public variables
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    // based on player height
    public float pitch = 2f;
    // dictates player-camera turn speed
    public float yawSpeed = 100f;
    #endregion

    #region private Variables
    private float currentZoom = 10f;
    private float currentYaw = 0f;

    #endregion

    void Update()
    {
        // Camera zoom
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Camera yaw/direction
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }


    // Runs after Update(), but why
    // TODO: Look up benefits of LateUpdate
    void LateUpdate()
    {
        // Camera zoom
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        // Rotation of camera around our target 
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

}
