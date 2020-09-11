namespace TowerDefence.Runtime
{
    public delegate void GameLose();  
    interface IGameLoseObservable
    {
        event GameLose OnGameLose;
    }
}
