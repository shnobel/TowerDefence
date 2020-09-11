using UniRx;

namespace TowerDefence.Runtime
{
    public interface ILiveObservable
    {
        IReadOnlyReactiveProperty<int> Lives { get; }
    }
}
