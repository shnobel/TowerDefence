using TowerDefense.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    [CreateAssetMenu(fileName = "LevelInstaller", menuName = "Installers/LevelInstaller")]
    public class LevelInstaller : ScriptableObjectInstaller<LevelInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Level>()
                .AsSingle();
        }
    }
}