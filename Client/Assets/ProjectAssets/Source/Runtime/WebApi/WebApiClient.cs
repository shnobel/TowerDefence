using System;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Networking;

namespace TowerDefence.Runtime
{
    public sealed class WebApiClient
    {
        public async UniTask<string> Get(string uri)
        {
            Debug.Log($"{nameof(GameConfiguration)}: going to load from {uri}");
            UnityWebRequest request = UnityWebRequest.Get(uri);
            await request.SendWebRequest();
            if (!string.IsNullOrEmpty(request.error))
            {
                throw new Exception(request.error);
            }

            Debug.Log($"{nameof(GameConfiguration)}: loaded {request.downloadHandler.text}");
            return request.downloadHandler.text;
        }
    }
}
