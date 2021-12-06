using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Rigidbody2D pivotRigidbody2D;
    [SerializeField] float detachDelay = 1f;
    [SerializeField] float respawnDelay = 1f;
    Rigidbody2D currentBallRigidbody2D;
    SpringJoint2D currentBallSpringJoint2D;
    bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBallRigidbody2D == null) { return; }
        if (!Touchscreen.current.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }
            isDragging = false;
            return;
        }
        isDragging = true;
        Vector2 TouchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(TouchPos);
        currentBallRigidbody2D.position = WorldPos;
        currentBallRigidbody2D.isKinematic = true;
    }
    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivotRigidbody2D.position, Quaternion.identity);
        currentBallRigidbody2D = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint2D = ballInstance.GetComponent<SpringJoint2D>();

        currentBallSpringJoint2D.connectedBody = pivotRigidbody2D;
    }
    private void LaunchBall()
    {
        currentBallRigidbody2D.isKinematic = false;
        currentBallRigidbody2D = null;
        Invoke("DetachBall", detachDelay);
    }

    private void DetachBall()
    {
        currentBallSpringJoint2D.enabled = false;
        currentBallSpringJoint2D = null;

        Invoke(nameof(SpawnNewBall), respawnDelay);
    }
}
