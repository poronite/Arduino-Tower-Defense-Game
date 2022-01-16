using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Wave = 1;
    public int WaveAmount = 5;
    public int LeftToSpawn;
    public int EnemiesAlive;
    public float SpawnSpeed = 3f;
    public float PlayerScore = 0;
    public bool IsWaveOver;
    public GameObject EnemyPrefab;
    public GameObject UpgradePrefab;
    public Transform SpawnPosition;
    public GameObject Player;

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
        Player = GameObject.FindGameObjectWithTag("Player");
        IsWaveOver = false;
        LeftToSpawn = WaveAmount;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (LeftToSpawn > 0)
        {
            GameObject enemy = Instantiate(EnemyPrefab, SpawnPosition.position, Quaternion.identity);
            EnemiesAlive++;
            LeftToSpawn--;
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
            yield return new WaitForSeconds(SpawnSpeed);
        }

        while(EnemiesAlive > 0)
        {
            yield return new WaitForSeconds(1);
        }

        IsWaveOver = true;
        StopCoroutine(SpawnEnemy());
        StartCoroutine(NextWave());
    }

    IEnumerator NextWave()
    {
        Wave++;
        WaveAmount += 3;
        LeftToSpawn = WaveAmount;
        if(SpawnSpeed > .1f)
        SpawnSpeed -= .2f;
        SpawnUpgrades();
        yield return new WaitForSeconds(5f);
        IsWaveOver = false;
        LeftToSpawn = WaveAmount;
        StopCoroutine(NextWave());
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
        Instantiate(UpgradePrefab, Player.transform.position + new Vector3(0,-2.5f), Quaternion.identity);
        Instantiate(UpgradePrefab, Player.transform.position + new Vector3(2,-3.5f), Quaternion.identity);
        Instantiate(UpgradePrefab, Player.transform.position + new Vector3(-2,-3.5f), Quaternion.identity);
    }
}
