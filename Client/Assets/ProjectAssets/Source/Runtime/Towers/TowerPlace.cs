using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefence.Runtime
{
    public class TowerPlace : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Tower[] m_towers = default;
        private Tower m_currentTower = default;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_currentTower == default)
            {
                m_currentTower = Instantiate(m_towers[Random.Range(0, m_towers.Length)]);
                m_currentTower.transform.position = transform.position;
            }
            else
            {
                Debug.Log($"Selected tower is {m_currentTower.name}");
            }
        }
    }
}