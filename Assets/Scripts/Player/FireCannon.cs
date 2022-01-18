using UnityEngine;

public class FireCannon : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private Transform CannonMouth;
    private GameObject bullet;

    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
        player = GameObject.FindObjectOfType<Player>();
    }


    public void Fire(int isFiring)
    {
        switch (isFiring)
        {
            case 0:
                if(player != null)
                {
                    if(player.CanShoot)
                    {
                        GameObject bulletClone = Instantiate(bullet, CannonMouth.position, Quaternion.identity);
                        bulletClone.GetComponent<Bullet>().ShootBullet(player.CannonBallVelocity, player.CannonBallDamage, player.PenetrationAmount);
                        player.CanShoot = false;
                    }
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
