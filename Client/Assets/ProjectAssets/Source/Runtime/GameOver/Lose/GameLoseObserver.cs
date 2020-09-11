using UnityEngine;

namespace TowerDefence.Runtime
{
    public class GameLoseObserver : IGameLoseObserver
    {
        public void Lose()
        {
            Debug.Log($"Game is Over you lose");
            Clear.Enemy();
        }
    }
}