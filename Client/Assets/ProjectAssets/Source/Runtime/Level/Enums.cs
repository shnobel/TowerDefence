namespace TowerDefence.Runtime
{
    public enum GameStates
    {
        Win,
        Lose,
        Running
    }

    public class GameStateHelper
    {
        public static GameStates GetState(bool isSpawnFinished, int lives, int unitsCount)
        {
            if (lives <= 0)
            {
                return GameStates.Lose;
            }

            //Lives > 0
            if (!isSpawnFinished)
            {
                return GameStates.Running;
            }

            //Lives > 0 spawn finished
            if (unitsCount > 0)
            {
                return GameStates.Running;
            }

            //Lives > 0 spawn finished units <= 0
            return GameStates.Win;
        }
    }
    
}
