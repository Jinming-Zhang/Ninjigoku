using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    EnemyResourceData enemyResourceData;
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
        string enemyType = spawnData.enemyType;
        if (spawnData.randomized)
        {
            Debug.Log($"Spawning {spawnData.amount} randomized enemy of type {spawnData.enemyType}");
        }
        else
        {
            Debug.Log($"Spawning 1 randomized enemy of type {spawnData.enemyType} at position {spawnData.coordinate}");
        }
    }

}
