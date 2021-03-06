using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats Stats;
    public GameObject Target;
    public Player Player;
    public GameObject DeathParticleSystem;
    public bool IsDead;
    private DamageFlash flash;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("StartPoint");
        Player = GameObject.FindObjectOfType<Player>();
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
        Player.CannonHealth -= Stats.EnemyDamage;
        GameManager.instance.UpdateUIValues();
        if(Player.CannonHealth <= 0)
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
        Instantiate(DeathParticleSystem, transform.position, Quaternion.identity);
        GameManager.instance.UpdateUIValues();
        Destroy(gameObject);
    }
}
