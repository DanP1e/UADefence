using UnityEngine;
using Utilities;

namespace Spawn
{
    public interface IObstacle : IDestroyable<IObstacle>
    {
        bool IsOverlap(IObstacle obstacle);

        Vector3 ClosestPoint(Vector3 destination);
    }
}
