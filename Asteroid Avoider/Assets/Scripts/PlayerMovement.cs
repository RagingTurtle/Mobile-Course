using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float magnitude;
    [SerializeField] float maxVelocity;
    Rigidbody rb;
    Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPostion = transform.position;
        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPortPosition.x > 1)
        {
            newPostion.x = -newPostion.x + .1f;
        }
        else if (viewPortPosition.x < 0)
        {
            newPostion.x = -newPostion.x - .1f;
        }

        if (viewPortPosition.y > 1)
        {
            newPostion.y = -newPostion.y + .1f;
        }
        else if (viewPortPosition.y < 0)
        {
            newPostion.y = -newPostion.y - .1f;
        }
        newPostion.z = 0f;
        transform.position = newPostion;
    }

    private void ProcessInput()
    {
        if (!Touchscreen.current.press.isPressed)
        {
            movementDirection = Vector3.zero;
        }
        else
        {
            Vector2 TouchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(TouchPos);
            movementDirection = transform.position - WorldPos;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) { return; }
        rb.AddForce(movementDirection * magnitude, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
