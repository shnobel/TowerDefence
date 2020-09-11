namespace TowerDefence.Runtime
{
    public delegate void GameWin();
    
    interface IGameWinObservable
    {
        event GameWin OnGameWin;
    }
}
