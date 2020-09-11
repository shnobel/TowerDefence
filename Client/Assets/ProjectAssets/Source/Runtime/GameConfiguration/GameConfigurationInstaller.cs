using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    [CreateAssetMenu(fileName = "GameConfigurationInstaller", menuName = "Installers/GameConfigurationInstaller")]
    public class GameConfigurationInstaller : ScriptableObjectInstaller<GameConfigurationInstaller>
    {
        [SerializeField] private string m_uri = default;

        public override void InstallBindings()
        {
            Container
                .Bind<GameConfiguration>()
                .AsSingle()
                .WithArguments(m_uri);
        }
    }
}