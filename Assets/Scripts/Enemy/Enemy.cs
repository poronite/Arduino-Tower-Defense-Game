using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats Stats;
    public GameObject Target;
    public GameObject Player;
    public GameObject DeathParticleSystem;
    public bool IsDead;
    private DamageFlash flash;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("StartPoint");
        Player = GameObject.FindGameObjectWithTag("Player");
        Stats = GetComponent<EnemyStats>();
        flash = GetComponent<DamageFlash>();
    }

    void Update()
    {
        if(Target != null)
        {
            MoveToTarget();
            if (Vector3.Distance(transform.position, Target.transform.position) <= .0001)
            {
                Target = Target.GetComponent<Path>().NextTarget;
            }
        }
        else
        Attack();
    }

    public void Attack()
    {
        Debug.Log("Player took " + Stats.EnemyDamage + " damage.");
        Player.GetComponent<Player>().CannonHealth -= Stats.EnemyDamage;
        if(Player.GetComponent<Player>().CannonHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
        GameManager.instance.EnemiesAlive--;
        Destroy(gameObject);
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Stats.EnemySpeed * Time.deltaTime);
    }

    public void TakeDamage(float damageTaken)
    {
        flash.Flash();
        Stats.EnemyHealth -= damageTaken;
        if(Stats.EnemyHealth <= 0)
        Die();
    }

    public void Die()
    {
        IsDead = true;
        GameManager.instance.PlayerScore += Stats.EnemyValue;
        GameManager.instance.EnemiesAlive--;
        Debug.Log(GameManager.instance.EnemiesAlive);
        Instantiate(DeathParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
