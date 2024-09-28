using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      
    public float spawnInterval = 2f;    
    public int maxEnemies = 10;          
    private int enemiesSpawned = 0;      

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemiesSpawned < maxEnemies)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemiesSpawned++;
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
