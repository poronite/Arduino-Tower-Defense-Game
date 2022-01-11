using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform pivot;
    private GameObject bullet;
    public Vector2 direction;
    public int speed;
    public int damage;
    public int health;

    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }

    public void Fire()
    {
        direction = pivot.forward;
        Instantiate(bullet, pivot);
    }
}
