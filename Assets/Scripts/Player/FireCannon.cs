using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private Transform Pivot;
    [SerializeField]
    private Transform CannonMouth;

    private GameObject bullet;
    public Vector3 direction;

    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void Fire(int isFiring)
    {
        switch (isFiring)
        {
            case 0:
                if (IsBulletReady())
                {
                    player.CanShoot = false;
                    direction = Pivot.up;
                    GameObject bulletClone = Instantiate(bullet, CannonMouth.position, Quaternion.identity);
                    bulletClone.GetComponent<Bullet>().ShootBullet(player.CannonBallVelocity, player.CannonBallDamage, direction);
                    Debug.Log("Fire!");
                }
                break;
            default:
                break;
        }
    }


    private bool IsBulletReady()
    {
        return player.CanShoot;
    }
}
