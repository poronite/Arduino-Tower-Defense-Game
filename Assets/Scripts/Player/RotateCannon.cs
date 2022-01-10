using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public void Rotate(int angle)
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
    }
}
