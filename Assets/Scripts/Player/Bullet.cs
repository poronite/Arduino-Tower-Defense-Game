using System.Collections;
using System.Collections.Generic;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Do damage
        }
    }
}
