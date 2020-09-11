using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    [CreateAssetMenu(fileName = "WebApiClientInstaller", menuName = "Installers/WebApiClientInstaller")]
    public class WebApiClientInstaller : ScriptableObjectInstaller<WebApiClientInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<WebApiClient>()
                .AsSingle();
        }
    }
}