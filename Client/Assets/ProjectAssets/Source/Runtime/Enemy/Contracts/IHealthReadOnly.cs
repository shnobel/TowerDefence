using UniRx;

namespace TowerDefence.Runtime
{
    public interface IHealthReadOnly
    {
        float MaxHealth { get; }

        IReadOnlyReactiveProperty<float> Health { get; } 
    }
}
