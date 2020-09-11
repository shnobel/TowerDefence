using System;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    [Serializable]
    public sealed class GameConfiguration
    {
        public LevelConfiguration Level = default;
        private readonly WebApiClient m_webApiClient = default;
        private readonly string m_uri = default;

        [Inject]
        public GameConfiguration(WebApiClient webApiClient, string uri)
        {
            m_webApiClient = webApiClient;
            m_uri = uri;
        }

        public IObservable<Unit> Load()
        {
            return m_webApiClient.Get(m_uri)
                .ToObservable()
                .Catch<string, Exception>(ex =>
                {
                    Debug.LogWarning($"{nameof(GameConfiguration)}: load failed due to {ex}");
                    TextAsset textAsset = Resources.Load<TextAsset>("GameConfiguration");
                    return Observable.Return(textAsset.text);
                })
                .ContinueWith(json =>
                {
                    JsonUtility.FromJsonOverwrite(json, this);
                    return Observable.ReturnUnit();
                });
        }
    }
}
