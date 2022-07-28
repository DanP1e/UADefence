using UnityEngine;

namespace Weapon.Aim
{
    public interface IAreaPresenter
    {
        float AreaScale { get; set; }
        bool IsInArea(Vector3 targetPosition);
    }
}
