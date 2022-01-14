using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private int bulletSpeed;
    private float bulletDamage;


    public void ShootBullet(int speed, float damage, Vector3 direction)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletSpeed = speed;
        bulletDamage = damage;
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
