using UnityEngine;

namespace Effects
{
    public interface IAreaPresenter
    {
        bool IsInArea(Vector3 targetPosition);
    }
}
