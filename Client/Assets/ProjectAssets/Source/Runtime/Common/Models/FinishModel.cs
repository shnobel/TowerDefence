using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    public class FinishModel : MonoBehaviour
    {
        [Inject] private ILiveDecreseable m_level = default;

        private void OnTriggerEnter(Collider other)
        {
            IKillable enemy = other.GetComponent<IKillable>();
            if (enemy != null)
            {
                m_level.Decrease();
                enemy.Dead();
            }
        }
    }
}