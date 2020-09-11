using System;

namespace TowerDefence.Runtime
{
    public interface IDieable<T>
    {
        IObservable<T> OnDead { get; }
    }
}
