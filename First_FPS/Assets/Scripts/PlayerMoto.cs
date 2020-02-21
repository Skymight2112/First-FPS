﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMoto : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void rotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }
    
    public void ApplyThruster(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }


    private void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    void performMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        } 
    }

}
