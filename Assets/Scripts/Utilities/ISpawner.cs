using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public interface ISpawner<T>
    {
        public T SpawnObject();
        public UnityEvent<T> ObjectSpawned { get; }
    }
}
