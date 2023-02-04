using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyResourceData : ScriptableObject
{
    // if random is true, then spawn randomly for amount amount
    // else, spawn at specific position
    [System.Serializable]
    public class EnemySpawnTimeline
    {
        public float timeElapsed;
        public string enemyType;
        public int amount;
        public bool randomized;
        public Vector3 coordinate;
    }
    public List<EnemySpawnTimeline> enemySpawnData;
}
