using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField]
    private int minZoom = 25;
    [SerializeField]
    private int maxZoom = 100;

    private float zoomCamera;
    private float zoomMultiplier = 4f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField]
    private Camera cam;

    private void Start()
    {
        zoomCamera = cam.fieldOfView;
    }

    private void Update()
    {
        float scrollSizeCamera = Input.GetAxis("Mouse ScrollWheel");
        zoomCamera -= scrollSizeCamera * zoomMultiplier;
        zoomCamera = Mathf.Clamp(zoomCamera, minZoom, maxZoom);
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoomCamera, ref velocity, smoothTime);
    }
}
