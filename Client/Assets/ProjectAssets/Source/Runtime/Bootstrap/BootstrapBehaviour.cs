using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TowerDefence.Runtime
{
    public class BootstrapBehaviour : MonoBehaviour
    {
        [Inject] private GameConfiguration m_configuration = default;

        void Start()
        {
            Debug.Log(" Hello!");
            Debug.Log(" Check PlayerPrefs Lives " + PlayerPrefs.GetInt("Lives"));
            m_configuration.Load()
                .ContinueWith(LoadGame())
                .Subscribe(_ =>
                {
                    Debug.Log("Scene loaded!");
                });
        }

        private IObservable<Unit> LoadGame()
        {
            return Observable.Create<Unit>(o =>
            {
                Debug.Log("Going to load scene...");
                SceneManager
                    .LoadSceneAsync("ProjectAssets/Scenes/Start")
                    .AsAsyncOperationObservable()
                    .AsUnitObservable()
                    .Subscribe(_ =>
                    {
                        o.OnNext(Unit.Default);
                        o.OnCompleted();
                    });
                return Disposable.Empty;
            });
        }
    }
}