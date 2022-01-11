using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    private int playerDamage;

    private void Start()
    {
        playerSpeed = player.speed;
        playerDamage = player.damage;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // speed = player.script.speedstat
        // force = player.script.forcestat
    }

    private void Update()
    {
        transform.position = (player.direction * Time.deltaTime * playerSpeed);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        //Do damage
    //    }
    //}
}
