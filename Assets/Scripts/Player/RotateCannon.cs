using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public void Rotate(float angle)
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
    }

    public void RotateKeyboard(float keyboardAngle)
    {
        transform.localRotation = Quaternion.AngleAxis(keyboardAngle, Vector3.forward) * transform.rotation;
    }
}
