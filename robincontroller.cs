using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobinController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick   fixedJoystick;    // planar (X‑Z) movement
    private FloatingJoystick altitudeJoystick; // vertical (Y) movement
    private Rigidbody       rigidBody;

    private void OnEnable()
    {
        fixedJoystick    = FindObjectOfType<FixedJoystick>();      // auto‑find
        altitudeJoystick = FindObjectOfType<FloatingJoystick>();   // auto‑find
        rigidBody        = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // horizontal plane input
        float xVal = fixedJoystick != null ? fixedJoystick.Horizontal : 0f;
        float zVal = fixedJoystick != null ? fixedJoystick.Vertical   : 0f;

        // altitude input (use vertical axis of floating joystick)
        float yVal = altitudeJoystick != null ? altitudeJoystick.Vertical : 0f;

        Vector3 movement = new Vector3(xVal, yVal, zVal);
        rigidBody.velocity = movement * speed;

        if (xVal != 0 && zVal != 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                Mathf.Atan2(xVal, zVal) * Mathf.Rad2Deg,
                transform.eulerAngles.z
            );
        }
    }
}
