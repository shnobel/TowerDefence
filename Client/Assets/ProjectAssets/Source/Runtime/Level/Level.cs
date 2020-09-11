using TowerDefence.Runtime;
using UniRx;
using UnityEngine;
using Zenject;

namespace TowerDefense.Runtime
{
    public sealed class Level : ILiveDecreseable, ILiveObservable
    {
         private readonly ReactiveProperty<int> m_lives = new ReactiveProperty<int>(default);
        IReadOnlyReactiveProperty<int> ILiveObservable.Lives => m_lives;

        [Inject]
        public Level(GameConfiguration configuration)
        {
            m_lives.Value = configuration.Level.Lives;
        }

        public void Decrease()
        {
            m_lives.Value--;
            Debug.Log($"{nameof(Level)}: lives changed to {m_lives}");
        }
    }
}