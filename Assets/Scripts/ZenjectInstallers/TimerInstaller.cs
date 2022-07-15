using Effects;
using InspectorAddons;
using UnityEngine;

namespace ZenjectInstallers
{
    public class TimerInstaller : InterfaceWithIdInstaller<ITimer>
    {
        [SerializeField] private InterfaceComponent<ITimer> _timerComponent;

        protected override ITimer Interface => _timerComponent.Interface;
    } 
}