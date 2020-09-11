using UniRx;

namespace TowerDefence.Runtime 
{ 
    interface ISpawnFinishedObservable
    {
        IReadOnlyReactiveProperty<bool> SpawnFinished { get; }
    }
}
