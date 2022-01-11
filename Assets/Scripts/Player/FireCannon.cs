using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Fire(int isFiring)
    {
        switch (isFiring)
        {
            case 0:
                if (IsBulletReady())
                    player.Fire();
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
