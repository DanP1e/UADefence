using UnityEngine;

namespace Weapon.Aim
{
    public interface IAreaPresenter
    {
        bool IsInArea(Vector3 targetPosition);
    }
}
