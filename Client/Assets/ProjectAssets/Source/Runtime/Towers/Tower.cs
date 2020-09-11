using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Random = System.Random;

namespace TowerDefence.Runtime
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] private float m_delay = default;
        [SerializeField] private float m_damage = 3f;
        protected float Damage => m_damage;

        private readonly Dictionary<EnemyModel, IDisposable> m_targets = new Dictionary<EnemyModel, IDisposable>();
        private bool m_isReloading = default;
        private Animator m_animator = default;
        private static readonly Random Randomizer = new Random();

        void Start()
        {
            m_animator = GetComponent<Animator>();
        }

        private IEnumerator Reloading()
        {
            m_isReloading = true;
            yield return new WaitForSeconds(m_delay);
            m_isReloading = false;
            if (m_targets.Any())
            {
                Attack();
            }
        }

        protected virtual void Attack()
        {
            m_animator.Play("attack");
            StartCoroutine(Reloading());
        }

        protected IEnumerable<IHittable> GetUnits(int count)
        {
            if (m_targets.Count <= 0)
            {
                return new List<IHittable>();
            }

            if (count > m_targets.Count)
            {
                count = m_targets.Count;
            }

            List<EnemyModel> targets = m_targets.Keys.ToList();
            var enemies = targets.OrderBy(x => Randomizer.Next()).Take(count);
            transform.LookAt(enemies.First().transform);
            return enemies;
        }

        private void OnEnemyDead(EnemyModel target)
        {
            Debug.Log($"OnUnitDying {target}");
            RemoveTarget(target);
        }

        private void RemoveTarget(EnemyModel target)
        {
            if (m_targets.TryGetValue(target, out IDisposable disposable))
            {
                m_targets.Remove(target);
                disposable?.Dispose();
            }
        }

        private void OnTriggerEnter(Collider target)
        {
            EnemyModel enemyModel = target.GetComponent<EnemyModel>();
            if (enemyModel != null)
            {
                IDisposable dyingDisposable = enemyModel.OnDead.Subscribe(OnEnemyDead);
                m_targets.Add(enemyModel, dyingDisposable);
                if (!m_isReloading)
                {
                    Attack();
                }
            }
        }

        private void OnTriggerExit(Collider target)
        {
            EnemyModel hittable = target.GetComponent<EnemyModel>();
            if (hittable != null)
            {
                RemoveTarget(hittable);
            }
        }
    }
    //public abstract class Tower : MonoBehaviour
    //{
    //    [SerializeField] private float m_delay = default;
    //    [SerializeField] private float m_damage = 3f;

    //    protected float Damage => m_damage;

    //    protected Queue<EnemyModel> m_enemyInside = default;
    //    private Animator m_animator = default;
    //    private bool m_isReloading = default;

    //    void Start()
    //    {
    //        m_enemyInside = new Queue<EnemyModel>();
    //        m_animator = GetComponent<Animator>();
    //    }

    //    private IEnumerator DetectNextEnemy()
    //    {
    //        yield return new WaitForSeconds(m_delay);
    //        if (m_enemyInside.Any() && m_enemyInside.Peek() == null)
    //        {
    //            m_enemyInside.Dequeue();
    //        }

    //        m_isReloading = false;
    //        TryToKill();
    //    }

    //    private void OnTriggerEnter(Collider target)
    //    {
    //        EnemyModel enemy = target.GetComponent<EnemyModel>();
    //        if (enemy != null)
    //        {
    //            m_enemyInside.Enqueue(enemy);
    //            TryToKill();
    //        }
    //    }

    //    private void OnTriggerExit(Collider target)
    //    {
    //        IHittable enemy = target.GetComponent<IHittable>();
    //        if (enemy != null)
    //        {
    //            m_enemyInside.Dequeue();
    //        }
    //    }

    //    private void TryToKill()
    //    {
    //        if (m_enemyInside.Any() && !m_isReloading)
    //        {
    //            m_animator.Play("attack");
    //            if(m_enemyInside.Peek() != null)
    //            {
    //                transform.LookAt(m_enemyInside.Peek().transform);
    //            }
    //            Attack();
    //            StartCoroutine(DetectNextEnemy());
    //        }
    //    }

    //    protected virtual void Attack()
    //    {
    //        m_isReloading = true;
    //    }

    //    protected IEnumerable<IHittable> GetEnemies(int count)
    //    {
    //        RemoveKilled();

    //        List<EnemyModel> enemies = m_enemyInside.ToList();
    //        if (enemies.Count > count)
    //        {
    //            enemies = enemies.GetRange(0, count);
    //        }
    //        return enemies;
    //    }

    //    private void RemoveKilled()
    //    {
    //        //m_enemyInside.Select(e => e.)
    //        //var count = m_enemyInside.Where(e => (e as IHealthReadOnly).MaxHealth <= 0).Count();
    //        //for (int i = 0; i < count; i++)
    //        //{
    //        //    m_enemyInside.Dequeue();
    //        //}
    //    }
    //}
}