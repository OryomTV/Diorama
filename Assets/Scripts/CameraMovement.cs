using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;


public sealed class CameraMovement : MonoBehaviour
{
    private float xRotation = 0f; // Current rotation around the x-axis
    private float yRotation = -90f; // Current rotation around the y-axis

    [SerializeField] private float sensitivityX = 3f;
    [SerializeField] private float sensitivityY = 3f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float speedBoost = 3f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovements();

        HandleRotation();
    }

    private void HandleMovements()
    {
        Vector3 velocity = Vector3.zero;
        bool boost = Input.GetKey(KeyCode.LeftShift);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        if (left != right)
            velocity += right ? transform.right : -transform.right;

        bool backward = Input.GetKey(KeyCode.S);
        bool forward = Input.GetKey(KeyCode.W);
        if (backward != forward)
            velocity += forward ? transform.forward : -transform.forward;

        bool down = Input.GetKey(KeyCode.C);
        bool up = Input.GetKey(KeyCode.E);
        if (down != up)
            velocity += up ? transform.up : -transform.up;

        transform.position += boost ?
            speedBoost * speed * Time.deltaTime * velocity :
            speed * Time.deltaTime * velocity
        ;
    }

    private void HandleRotation()
    {
        // around x-axis
        xRotation -= Input.GetAxis("Mouse Y") * sensitivityY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f); // Clamp in order to avoid doing a flip when looking up/down too intensely

        // around y-axis
        yRotation += Input.GetAxis("Mouse X") * sensitivityX;

        // apply
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}