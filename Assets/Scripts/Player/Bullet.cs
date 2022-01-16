using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private int bulletSpeed;
    private float bulletDamage;
    private int bulletPenetration;


    public void ShootBullet(int speed, float damage, int penetration, Vector3 direction)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletSpeed = speed;
        bulletDamage = damage;
        bulletPenetration = penetration;
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.GetComponent<Enemy>().IsDead == false)
        {
            bulletPenetration--;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
        }
        else if(collision.gameObject.CompareTag("Upgrade"))
        {
            collision.GetComponent<UpgradeBehaviour>().Upgrade();
        }

        if(bulletPenetration < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}