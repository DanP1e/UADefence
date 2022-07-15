using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class MagazineInstaller : InterfaceInstaller<IMagazine>
    {
        [SerializeField] private InterfaceComponent<IMagazine> _magazine;

        protected override IMagazine Interface => _magazine.Interface;
    }
}
