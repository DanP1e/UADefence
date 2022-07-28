using Zenject;

namespace ZenjectInstallers
{
    public class SceneContainerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DiContainer>()
                .WithId("scene")
                .FromInstance(Container);
        }
    }
}
