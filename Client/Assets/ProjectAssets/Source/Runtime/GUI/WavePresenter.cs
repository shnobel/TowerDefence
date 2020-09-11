using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TowerDefence.Runtime
{
    public class WavePresenter : MonoBehaviour
    {
        [SerializeField] private Text m_wave = default;

        private int m_maxWaves = default;

        [Inject]
        private void Construct(IWavesCountObservable wavesCountsObservable)
        {
            wavesCountsObservable.Waves.Subscribe(OnWavesCountChanged).AddTo(this);
            wavesCountsObservable.MaxWaves.Subscribe(maxWave => m_maxWaves = maxWave);
            OnWavesCountChanged(m_maxWaves);
        }

        private void OnWavesCountChanged(int wave)
        {
            m_wave.text = $"{wave}/{m_maxWaves}";
        }
    }
}

