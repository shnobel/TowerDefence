using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class HealthModel : MonoBehaviour, IHittable, IHealthReadOnly
    {
        [SerializeField] private float m_maxHealth = 2f;
        public IReadOnlyReactiveProperty<float> Health => m_health;

        private ReactiveProperty<float> m_health = new ReactiveProperty<float>(0);
        private IKillable m_killable = default;
        float IHealthReadOnly.MaxHealth => m_maxHealth;

        private void Awake()
        {
            m_health.Value = m_maxHealth;
            m_killable = gameObject.GetComponent<IKillable>();
        }

        public void Hit(float damage)
        {
            m_health.Value -= damage;
            if (m_health.Value <= 0f && m_killable != null)
            {
                m_killable?.Dead();
            }
        }
    }
}