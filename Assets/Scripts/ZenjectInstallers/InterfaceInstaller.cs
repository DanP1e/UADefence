using Zenject;

namespace ZenjectInstallers
{
    public abstract class InterfaceInstaller<T> : MonoInstaller
    {
        protected abstract T Interface { get; }

        public override void InstallBindings()
        {
            Container.Bind<T>()
                .FromInstance(Interface);
        }
    } 
}