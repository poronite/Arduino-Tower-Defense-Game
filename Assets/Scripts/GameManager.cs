using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Wave = 1;
    public int WaveAmount = 10;
    public int LeftToSpawn;
    public int EnemiesAlive;
    public float SpawnSpeed = 3f;
    public float PlayerScore = 0;
    public bool IsWaveOver;
    public GameObject EnemyPrefab;
    public Transform SpawnPosition;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
            instance = this;
    }

    void Start()
    {
        IsWaveOver = false;
        LeftToSpawn = WaveAmount;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (LeftToSpawn > 0 || EnemiesAlive > 0)
        {
            GameObject enemy = Instantiate(EnemyPrefab, SpawnPosition.position, Quaternion.identity);
            EnemyStats stats = enemy.GetComponent<EnemyStats>();

            for (int i = 0; i < Wave; i++)
                switch (Random.Range(0, 2)) {
                    case 0:
                        stats.EnemyHealth++;
                        break;
                    case 1:
                        stats.EnemyDamage++;
                        break;
                    case 2:
                        stats.EnemySpeed++;
                        break;
                }
            stats.EnemyValue = stats.EnemyHealth + stats.EnemyDamage + stats.EnemySpeed;

            EnemiesAlive++;
            LeftToSpawn--;
            yield return new WaitForSeconds(SpawnSpeed);
        }
        IsWaveOver = true;
        StopCoroutine(SpawnEnemy());
        StartCoroutine(NextWave());
    }

    IEnumerator NextWave()
    {
        Wave++;
        WaveAmount += 10;
        LeftToSpawn = WaveAmount;
        if(SpawnSpeed > .5f)
        SpawnSpeed -= .1f;
        yield return new WaitForSeconds(5f);
        IsWaveOver = false;
        LeftToSpawn = WaveAmount;
        StartCoroutine(SpawnEnemy());
    }

    public void GameOver()
    {
        IsWaveOver = true;
        StopAllCoroutines();
        Debug.Log("Game has ended.");
        Time.timeScale = 0;
    }


    void SpawnUpgrades()
    {
        
    }
}
