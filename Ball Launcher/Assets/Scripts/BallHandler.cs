using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] Rigidbody2D currentBallRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Touchscreen.current.press.isPressed)
        {
            currentBallRigidbody2D.isKinematic = false;
            return;
        }
        Vector2 TouchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(TouchPos);
        currentBallRigidbody2D.position = WorldPos;
        currentBallRigidbody2D.isKinematic = true;
    }
}
