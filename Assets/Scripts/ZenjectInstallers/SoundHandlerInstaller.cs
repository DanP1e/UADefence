using Effects;
using InspectorAddons;
using UnityEngine;

namespace ZenjectInstallers
{
    public class SoundHandlerInstaller : InterfaceInstaller<ISoundHandler>
    {
        [SerializeField] private InterfaceComponent<ISoundHandler> _soundHandlerComponent;

        protected override ISoundHandler Interface => _soundHandlerComponent.Interface;
    }
}
