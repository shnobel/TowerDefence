using UnityEngine;

namespace TowerDefence.Runtime
{
    public class GameWinObserver : IGameWinObserver
    {
        public void Win()
        {
            Debug.Log($"Game is Over you win");
            Clear.Enemy();
        }
    }
}