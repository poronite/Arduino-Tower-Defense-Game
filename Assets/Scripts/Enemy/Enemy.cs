using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyHealth;
    public float EnemySpeed;
    public float EnemyDamage;
    public float EnemyValue;
    public Vector2 target;

    void Start()
    {
        target = GameObject.Find("1").transform.position;
    }

    void Update()
    {
        MoveToTarget();
    }

    public void Attack()
    {
        Debug.Log("player took damage");
        Destroy(this.gameObject);
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, EnemySpeed * Time.deltaTime);
    }

    public void TakeDamage(float damageTaken)
    {
        EnemyHealth -= damageTaken;
        if(EnemyHealth < 0)
        Die();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
