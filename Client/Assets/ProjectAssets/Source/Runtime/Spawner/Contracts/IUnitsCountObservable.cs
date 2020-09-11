using UniRx;

namespace TowerDefence.Runtime
{
    public interface IUnitsCountObservable
    {
        IReadOnlyReactiveProperty<int> Enemies { get; }
    }
}
