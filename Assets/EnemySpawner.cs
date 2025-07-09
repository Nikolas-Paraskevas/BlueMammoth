using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[System.Serializable]
public class SpawnPointGroup
{
    public string groupName;                // Optional label for organization
    public Transform[] points;              // Spawn points in this group
}

[System.Serializable]
public class WaveConfig
{
    public string waveName;
    public GameObject enemyPrefab;
    public int enemyCount = 5;
    public float spawnInterval = 1f;
    public int spawnGroupIndex = 0;
}


public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [Header("Wave Settings")]
    public List<WaveConfig> waves;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;
    private int enemiesSpawned = 0;
    private int enemiesAlive = 0;
    private bool isSpawning = false;

    [Header("Spawn Point Sets")]
    public List<SpawnPointGroup> spawnPointGroups;

    void Start()
    {
        StartCoroutine(HandleWave());
    }

    void Update()
    {
        // Check if wave is done
        if (isSpawning && enemiesSpawned >= waves[currentWave - 1].enemyCount && enemiesAlive <= 0)
        {
            isSpawning = false;
            StartCoroutine(HandleWave());
        }
    }

    IEnumerator HandleWave()
    {
        if (currentWave >= waves.Count)
        {
            Debug.Log("All waves completed!");
            yield break;
        }

        var wave = waves[currentWave];
        Debug.Log($"Wave {currentWave + 1} ({wave.waveName}) starting in {timeBetweenWaves} seconds...");
        yield return new WaitForSeconds(timeBetweenWaves);

        Debug.Log($"Spawning wave {currentWave + 1} with {wave.enemyCount} enemies!");
        StartCoroutine(SpawnWave(wave));

        currentWave++;
    }



    IEnumerator SpawnWave(WaveConfig wave)
    {
        isSpawning = true;
        enemiesSpawned = 0;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave);
            enemiesSpawned++;
            yield return new WaitForSeconds(wave.spawnInterval);
        }
    }


    void SpawnEnemy(WaveConfig wave)
    {
        if (spawnPointGroups.Count == 0) return;

        var groupIndex = Mathf.Clamp(wave.spawnGroupIndex, 0, spawnPointGroups.Count - 1);
        var group = spawnPointGroups[groupIndex];

        if (group.points.Length == 0) return;

        int index = Random.Range(0, group.points.Length);
        Instantiate(wave.enemyPrefab, group.points[index].position, Quaternion.identity);
        enemiesAlive++;
    }



    // Call this from your enemy's script on death
    public void OnEnemyDestroyed()
    {
        enemiesAlive--;
        Debug.Log("Enemy killed");
    }
}