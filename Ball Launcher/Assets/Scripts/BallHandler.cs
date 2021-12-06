using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Touchscreen.current.press.isPressed)
        {
            return;
        }
        Vector2 TouchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log(TouchPos);
    }
}
