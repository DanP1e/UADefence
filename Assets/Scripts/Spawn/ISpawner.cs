using UnityEngine.Events;

namespace Spawn
{
    public interface ISpawner<T>
    {
        public T SpawnObject();
        public UnityEvent<T> ObjectSpawned { get; }
    }
}
