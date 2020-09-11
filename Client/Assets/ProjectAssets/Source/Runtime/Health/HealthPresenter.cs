using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private HealthBar m_healthBar = default;

        private IHealthReadOnly m_model = default;

        private void Awake()
        {
            m_model = GetComponent<IHealthReadOnly>();
            m_healthBar.SetMaxHealth(m_model.MaxHealth);
            m_model.Health.Subscribe(OnHealthChanged);
        }

        private void SetSize(float percent)
        {
            if(m_healthBar != null)
            {
                m_healthBar.SetHealth(m_model.MaxHealth * percent);
            }
        }

        private void OnHealthChanged(float health)
        {
            if(health < 0)
            {
                health = 0;
            }

            SetSize(health / m_model.MaxHealth);
        }

        private void OnDestroy()
        {
            m_healthBar.enabled = false;
        }
    }
}
