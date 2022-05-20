using UnityEngine;
using PathCreation;

namespace PathSystem
{
    public class BezierPathPresenter : MonoBehaviour, IPathPresenter
    {
        [SerializeField] private PathCreator _pathCreator;
        [Min(0.0001f)]
        [SerializeField] private float _gapBetweenPoints = 1f;

        public Vector3 GetPathPoint(Vector3 pathWalkerPosition)
        {
            float pathProgress = _pathCreator.path.GetClosestDistanceAlongPath(pathWalkerPosition);
            return _pathCreator.path.GetPointAtDistance(pathProgress + _gapBetweenPoints);
        }
        public float GetProgress(Vector3 walkerPosition)
        {
            Vector3 closestPoint = _pathCreator.path.GetClosestPointOnPath(walkerPosition);
            float result = _pathCreator.path.GetClosestTimeOnPath(walkerPosition);
            result += Vector3.Distance(closestPoint, walkerPosition);
            return result;
        }
    }
}
