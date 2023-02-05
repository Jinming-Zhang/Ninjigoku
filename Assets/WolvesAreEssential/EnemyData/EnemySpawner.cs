using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyPrefabMap
{
    public EnemyType enemyType;
    public GameObject enemyPrefab;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<EnemyPrefabMap> enemyTypeMap;

    [SerializeField]
    EnemyResourceData enemyResourceData;
    [SerializeField]
    GameObject enemyTemplate;
    [SerializeField]
    int radius;

    private float timer = 0;
    int spawningIndex;
    bool started = false;
    
    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        timer = 0;
        spawningIndex = 0;
        started = true;
    }

    private void Update()
    {
        if (started && spawningIndex < enemyResourceData.enemySpawnData.Count)
        {
            timer += Time.deltaTime;
            if (timer > enemyResourceData.enemySpawnData[spawningIndex].timeElapsed)
            {
                SpawnEnemy(enemyResourceData.enemySpawnData[spawningIndex]);
                ++spawningIndex;
            }
        }
    }

    private void SpawnEnemy(EnemyResourceData.EnemySpawnTimeline spawnData)
    {
        var enemyType = spawnData.enemyType;
        if (spawnData.randomized)
        {
            for (int i = 0; i < spawnData.amount; i++)
            {
                GameObject enemy = Instantiate(enemyTemplate);
                enemy.transform.position = GetRandomSpawnPosition();
            }
        }
        else
        {
            GameObject enemy = Instantiate(enemyTemplate);
            enemy.transform.position = spawnData.coordinate;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 spawn2D = UnityEngine.Random.insideUnitCircle * radius;
        return new Vector3(spawn2D.x, 0.5f, spawn2D.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
