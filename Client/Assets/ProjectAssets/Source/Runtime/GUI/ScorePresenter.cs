using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TowerDefence.Runtime
{
    public sealed class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private Text m_score = default;

        private int m_maxLives = default;
        
        [Inject]
        private void Construct(ILiveObservable livesObservable)
        {
            livesObservable.Lives.Subscribe(OnLivesChanged).AddTo(this);
            m_maxLives = livesObservable.Lives.Value;
            OnLivesChanged(m_maxLives);
        }

        private void OnLivesChanged(int lives)
        {
            m_score.text = $"{lives}";
        }
    }
}
