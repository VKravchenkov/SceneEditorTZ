using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAxis : MonoBehaviour
{
    [SerializeField] private ModeAxis modeAxis = ModeAxis.Z;
    [SerializeField] private Transform transformForwardRotation;
    public float rotateSpeed = 20;

    private Vector3 newPos;
    private Vector3 pointClickMouse;

    private SelectedMode selectedMode = SelectedMode.Move;

    private Transform transformParentParent;

    private Vector3 distance;


    private void Awake()
    {
        EventManager.OnSelectedMode += (selMod) => selectedMode = selMod;
    }

    private void OnDisable()
    {
        EventManager.OnSelectedMode -= (selMod) => selectedMode = selMod;
    }

    private void OnMouseDown()
    {
        pointClickMouse = Input.mousePosition;
        transformParentParent = transform.parent.parent;

        if (selectedMode == SelectedMode.Move)
        {
            distance = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    Camera.main.WorldToScreenPoint(transform.parent.parent.position).z)
                ) - transform.parent.parent.position;
        }
    }

    private void OnMouseDrag()
    {
        switch (selectedMode)
        {
            case SelectedMode.Move:
                Move2();
                break;
            case SelectedMode.Rotation:
                Rotate();
                break;
            case SelectedMode.Scale:
                Scale();
                break;
            default:
                break;
        }
    }

    private void OnMouseUp()
    {
        if (selectedMode == SelectedMode.Scale)
            transform.parent.parent = transformParentParent;
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;

        if (modeAxis == ModeAxis.Y)
        {
            mousePos.x = Camera.main.WorldToScreenPoint(transform.root.root.position).x;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.root.root.position).z;

            newPos.x = transform.root.root.position.x;
            newPos.y = Camera.main.ScreenToWorldPoint(mousePos).y;
            newPos.z = transform.root.root.position.z;
        }

        if (modeAxis == ModeAxis.Z)
        {
            mousePos.y = Camera.main.WorldToScreenPoint(transform.root.root.position).y;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.root.root.position).z;

            newPos.x = transform.root.root.position.x;
            newPos.y = transform.root.root.position.y;
            newPos.z = -Camera.main.ScreenToWorldPoint(mousePos).x;
        }

        if (modeAxis == ModeAxis.X)
        {
            mousePos.z = Camera.main.WorldToScreenPoint(transform.root.root.position).z;

            newPos.x = -Camera.main.ScreenToWorldPoint(mousePos).y;
            newPos.y = transform.root.root.position.y;
            newPos.z = transform.root.root.position.z;
        }

        transform.root.root.position = newPos;
    }

    private void Move2()
    {
        Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(transform.parent.parent.position);
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));

        newPos = transform.parent.parent.position;

        switch (modeAxis)
        {
            case ModeAxis.X:
                newPos.x = pos_move.x - distance.x;
                break;
            case ModeAxis.Y:
                newPos.y = pos_move.y - distance.y;
                break;
            case ModeAxis.Z:
                newPos.z = pos_move.z - distance.z;
                break;
            default:
                break;
        }

        transform.parent.parent.position = newPos;
    }

    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        switch (modeAxis)
        {
            case ModeAxis.X:
                transform.root.root.RotateAround(transformForwardRotation.forward, rotX);
                break;
            case ModeAxis.Y:
                transform.root.root.RotateAround(transformForwardRotation.forward, rotX);
                break;
            case ModeAxis.Z:
                transform.root.root.RotateAround(transformForwardRotation.forward, rotY);
                break;
            default:
                break;
        }
    }

    private void Scale()
    {
        transform.parent.parent = null;

        Vector3 scale = transform.localScale;
        scale.x = scale.y = scale.z = -(pointClickMouse.y - Input.mousePosition.y) * Time.deltaTime * 0.05f;

        transformParentParent.localScale += scale;
    }
}

public enum ModeAxis
{
    X = 0,
    Y = 1,
    Z = 2
}
