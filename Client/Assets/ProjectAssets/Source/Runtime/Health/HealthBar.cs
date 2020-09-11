using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Runtime
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider m_slider = default;
        [SerializeField] private Image fill = default;

        public Gradient gradient = default;

        public void SetMaxHealth(float health)
        {
            m_slider.maxValue = health;
            m_slider.value = health;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(float health)
        {
            m_slider.value = health;
            fill.color = gradient.Evaluate(m_slider.normalizedValue);
        }
    }
}

