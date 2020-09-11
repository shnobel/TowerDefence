using System;
using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class EnemyModel : MonoBehaviour
        , IHittable
        , IDieable<EnemyModel>
    {
        [SerializeField] private HealthModel m_healthModel = default;
        [SerializeField] private DeathModel m_deathModel = default;

        private IHittable m_successor = default;

        private readonly Subject<EnemyModel> m_onDead = new Subject<EnemyModel>();
        public IObservable<EnemyModel> OnDead => m_onDead;

        private void Awake()
        {
            m_successor = m_healthModel;
            m_deathModel.OnDead.Subscribe(OnDeadChanged).AddTo(this);
        }

        public void Hit(float damage)
        {
            m_successor.Hit(damage);
        }

        private void OnDeadChanged(DeathModel _)
        {
            m_onDead.OnNext(this);
        }
    }
}
