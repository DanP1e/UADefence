using InspectorAddons;
using Spawn;
using UnityEngine;

namespace ZenjectInstallers
{
    public class ObstacleContainerInstaller : InterfaceInstaller<IObstaclesContainer>
    {
        [SerializeField] 
        private InterfaceComponent<IObstaclesContainer> _obstaclesContainerComponent;

        protected override IObstaclesContainer Interface 
            => _obstaclesContainerComponent.Interface;
    }
}
