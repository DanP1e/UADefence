using UnityEngine.Events;

namespace Utilities
{
    public interface IDestroyable<T>
    {
        public event UnityAction<T> Destroyed;

        public void Destroy();
    }
}
