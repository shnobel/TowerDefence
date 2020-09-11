using System.Collections;
using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class DeathPresenter : MonoBehaviour
    {
        [SerializeField] private Collider m_collider = default;
        [SerializeField] private DeathModel m_deathModel = default;

        private void Awake()
        {
            m_deathModel.OnDead.Subscribe(OnDead).AddTo(this);
        }

        private void OnDead(DeathModel _)
        {
            StartCoroutine("Die");
            m_collider.enabled = false;
        }

        private IEnumerator Die()
        {
            var animator = GetComponent<Animator>();
            animator.Play("Death");
            yield return new WaitForSeconds(1.2f);
        }
    }
}
