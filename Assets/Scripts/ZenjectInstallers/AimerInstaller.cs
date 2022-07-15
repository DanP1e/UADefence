using InspectorAddons;
using UnityEngine;
using Weapon.Aim;

namespace ZenjectInstallers
{
    public class AimerInstaller : InterfaceInstaller<IAimer>
    {
        [SerializeField] private InterfaceComponent<IAimer> _aimerComponent;

        protected override IAimer Interface => _aimerComponent.Interface;
    }
}
