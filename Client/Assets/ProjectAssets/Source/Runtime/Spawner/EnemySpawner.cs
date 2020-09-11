using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Runtime;
using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class EnemySpawner : MonoBehaviour
        , ISpawnFinishedObservable
        , IUnitsCountObservable
        , IWavesCountObservable
    {
        [SerializeField] private WaveModel[] m_waves;

        private readonly ReactiveProperty<bool> m_spawnFinished = new ReactiveProperty<bool>();
        private readonly ReactiveProperty<int> m_maxWaves = new ReactiveProperty<int>();
        private readonly ReactiveProperty<int> m_enemiesCount = new ReactiveProperty<int>();
        private readonly Dictionary<EnemyModel, IDisposable> m_enemies = new Dictionary<EnemyModel, IDisposable>();
        private readonly ReactiveProperty<int> m_currentWaveNumber = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> Enemies => m_enemiesCount;
        public IReadOnlyReactiveProperty<int> Waves => m_currentWaveNumber;
        public IReadOnlyReactiveProperty<bool> SpawnFinished => m_spawnFinished;
        public IReadOnlyReactiveProperty<int> MaxWaves => m_maxWaves;

        void Start()
        {
            m_maxWaves.Value = m_waves.Length;
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            for (int i = 0; i < m_waves.Length; i++)
            {
                m_currentWaveNumber.Value = i + 1;
                bool isLastWave = i == (m_waves.Length - 1);
                for (int j = 0; j < m_waves[i].EnemiesCount; j++)
                {
                    bool isLastEnemy = (j == (m_waves[i].EnemiesCount - 1));
                    int length = m_waves[i].EnemyPrefabs.Length;
                    GameObject enemy = Instantiate(m_waves[i].EnemyPrefabs[UnityEngine.Random.Range(0, length)]);
                    EnemyModel enemyModel = enemy.GetComponent<EnemyModel>();
                    if(enemyModel != null)
                    {
                        IDisposable d = enemyModel.OnDead.Subscribe(OnUnitDead);
                        m_enemies.Add(enemyModel, d);
                        m_enemiesCount.Value = m_enemies.Count;
                    }
                    IMovable enemyMovable = enemy.GetComponent<IMovable>();
                    enemyMovable?.Move();

                    if (!isLastEnemy)
                    {
                        yield return new WaitForSeconds(UnityEngine.Random.Range(m_waves[i].MinSpawnDelay, m_waves[i].MaxSpawnDelay));
                    }
                }
                if (!isLastWave)
                {
                    yield return new WaitForSeconds(m_waves[i].WaveDelay);
                }
            }

            m_spawnFinished.Value = true;
        }

        private void OnUnitDead(EnemyModel enemy)
        {
            if (m_enemies.ContainsKey(enemy))
            {
                IDisposable d = m_enemies[enemy];
                d.Dispose();
                m_enemies.Remove(enemy);
            }

            m_enemiesCount.Value = m_enemies.Count;
        }
    }
}