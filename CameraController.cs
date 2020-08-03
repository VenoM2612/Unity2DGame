using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    public float zoomSpeed = 4f;

    public float minzoom = 5f;

    public float maxzoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentZoom = 10f;

    private float currentyaw = 0f;

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentyaw);
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minzoom, maxzoom);

        currentyaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }


}
