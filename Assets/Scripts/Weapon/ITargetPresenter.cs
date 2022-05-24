using Entity;
using InspectorAddons;
using UnityEngine;

namespace Weapon
{
    public interface ITargetPresenter<T>
    {
        bool TryGetTargetComponent(Vector3 seekerPosition, out T outComponent);
    }
}