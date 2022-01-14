using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats Stats;
    public GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("StartPoint");
        Stats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        if(target != null)
        {
            MoveToTarget();
            if (Vector3.Distance(transform.position, target.transform.position) <= .0001)
            {
                target = target.GetComponent<Path>().NextTarget;
            }
        }
        else
        Attack();
    }

    public void Attack()
    {
        Debug.Log("player took " + Stats.EnemyDamage + " damage.");
        GameManager.instance.EnemiesAlive--;
        Destroy(this.gameObject);
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Stats.EnemySpeed * Time.deltaTime);
    }

    public void TakeDamage(float damageTaken)
    {
        Stats.EnemyHealth -= damageTaken;
        if(Stats.EnemyHealth < 0)
        Die();
    }

    public void Die()
    {
        GameManager.instance.EnemiesAlive--;
        Destroy(this.gameObject);
    }
}
