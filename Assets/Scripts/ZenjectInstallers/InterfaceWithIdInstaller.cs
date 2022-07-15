using UnityEngine;

namespace ZenjectInstallers
{
    public abstract class InterfaceWithIdInstaller<T> : InterfaceInstaller<T>
    {
        [SerializeField] private string _id = "default";

        public override void InstallBindings()
        {
            Container.Bind<T>()
                .WithId(_id)
               .FromInstance(Interface);
        }
    } 
}

