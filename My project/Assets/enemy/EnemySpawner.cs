using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 5;
    public float spawnInterval = 2f;
    public Vector3 spawnArea;
    
    private List<GameObject> enemyPool;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f;

            foreach (GameObject enemy in enemyPool)
            {
                if (!enemy.activeInHierarchy)
                {
                    enemy.transform.position = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), 
                        Random.Range(-spawnArea.y, spawnArea.y), Random.Range(-spawnArea.z, spawnArea.z));
                    enemy.SetActive(true);
                    break;
                }
            }
        }
    }
}
