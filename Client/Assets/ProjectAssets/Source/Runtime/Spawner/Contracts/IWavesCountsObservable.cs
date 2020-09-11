using UniRx;

namespace TowerDefence.Runtime
{
    public interface IWavesCountObservable
    {
        IReadOnlyReactiveProperty<int> Waves { get; }
        IReadOnlyReactiveProperty<int> MaxWaves { get; }
    }
}
