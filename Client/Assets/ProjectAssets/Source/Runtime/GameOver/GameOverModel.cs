using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TowerDefence.Runtime
{
    public class GameOverModel : MonoBehaviour
    {
        private ISpawnFinishedObservable m_spawnFinishedObservable = default;
        private ILiveObservable m_livesObservable = default;
        private IUnitsCountObservable m_enemiesCountObservable = default;

        [Inject]
        private void Construct(ISpawnFinishedObservable spawnFinishedObservable,
            ILiveObservable livesObservable,
            IUnitsCountObservable unitsCountObservable)
        {
            m_spawnFinishedObservable = spawnFinishedObservable;
            m_livesObservable = livesObservable;
            m_enemiesCountObservable = unitsCountObservable;
        }

        private void Awake()
        {
            m_spawnFinishedObservable.SpawnFinished.Subscribe(OnSpawnFinished).AddTo(this);
            m_enemiesCountObservable.Enemies.Subscribe(OnEnemiesCountChanged).AddTo(this);
            m_livesObservable.Lives.Subscribe(OnLivesCountChanged).AddTo(this);
        }

        private void OnEnemiesCountChanged(int enemies)
        {
            GameStates s = GameStateHelper.GetState(
                m_spawnFinishedObservable.SpawnFinished.Value,
                m_livesObservable.Lives.Value,
                enemies
            );

            if (s == GameStates.Win)
            {
                Debug.LogError($"WIN");
                //TODO Move to DeathPresenter
                SceneManager
                    .LoadScene("ProjectAssets/Scenes/Win");
            }

            if (s == GameStates.Lose)
            {
                Debug.LogError($"LOSE");
                //TODO Move to DeathPresenter
                SceneManager
                    .LoadScene("ProjectAssets/Scenes/Lose");
            }
        }

        private void OnLivesCountChanged(int lives)
        {
            GameStates s = GameStateHelper.GetState(
                m_spawnFinishedObservable.SpawnFinished.Value,
                lives,
                m_enemiesCountObservable.Enemies.Value
            );
        }

        private void OnSpawnFinished(bool finished)
        {
            GameStates s = GameStateHelper.GetState(
                finished,
                m_livesObservable.Lives.Value,
                m_enemiesCountObservable.Enemies.Value
            );
        }
    }
}
