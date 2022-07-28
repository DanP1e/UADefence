using UnityEngine.Events;

namespace Weapon
{
    public interface IDetonator
    {
        event UnityAction Detonating;

        event UnityAction Detonated;

        void Detonate();
    }
}