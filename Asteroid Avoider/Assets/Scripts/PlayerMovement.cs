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
