using System;
using UniRx;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class DeathModel : MonoBehaviour, IKillable, IDieable<DeathModel>
    {
        public IObservable<DeathModel> OnDead => m_onDead;
        private readonly Subject<DeathModel> m_onDead = new Subject<DeathModel>();

        void IKillable.Dead()
        {
            Debug.Log($"{name}: I'm dead!");
            Destroy(gameObject, 0.35f);
            m_onDead.OnNext(this);
        }
    }
}
