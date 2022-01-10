using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public void Fire(int isFiring)
    {
        switch (isFiring)
        {
            case 0:
                if (IsBulletReady())
                    Debug.Log("Fire!");
                break;
            default:
                break;
        }
    }


    private bool IsBulletReady()
    {
        return true;
    }
}
