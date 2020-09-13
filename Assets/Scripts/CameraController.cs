using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float zomeSpeed;
    [SerializeField] private float upSpeed;
    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;

    private Camera camera;
    private Vector3 upPos;
    private Vector3 direction;

    private void Awake()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        Move();
        Zoom();
        Rotation();
        UpCamera();
    }

    private void UpCamera()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            upPos = transform.position;

            upPos.y += upSpeed * Time.deltaTime;
            transform.position = upPos;
        }
        if (Input.GetKey(KeyCode.X))
        {
            upPos = transform.position;

            upPos.y -= upSpeed * Time.deltaTime;
            transform.position = upPos;
        }
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }

    private void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float distance = Vector3.Distance(transform.position, camera.transform.position);

        if (distance < minZoomDist && scrollInput > 0.0f)
            return;
        else if (distance > maxZoomDist && scrollInput < 0.0f)
            return;

        camera.transform.position += camera.transform.forward * scrollInput * zomeSpeed;
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        direction = transform.forward * xInput + transform.right * -zInput;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

}
