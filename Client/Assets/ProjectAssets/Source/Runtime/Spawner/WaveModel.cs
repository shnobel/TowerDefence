using System;
using UnityEngine;

namespace TowerDefense.Runtime
{
    [Serializable]
    public class WaveModel
    {
        public GameObject[] EnemyPrefabs;
        public float MinSpawnDelay;
        public float MaxSpawnDelay;
        public float WaveDelay;
        public int EnemiesCount;
    }
}
