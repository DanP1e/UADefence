using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Spawn
{
    public abstract class Obstacle : MonoBehaviour, IObstacle
    {
        protected abstract Vector3 Center { get; }

        public event UnityAction<IObstacle> Destroyed;

        [Inject]
        public void Construct(IObstaclesContainer obstaclesContainer) 
        {
            obstaclesContainer.AddObstacle(this);
        }

        public abstract Vector3 ClosestPoint(Vector3 destination);

        public bool IsOverlap(IObstacle obstacle)
        {
            Vector3 b = obstacle.ClosestPoint(Center);
            Vector3 a = ClosestPoint(b);

            float aDistance = Vector3.Distance(Center, a);
            float bDistance = Vector3.Distance(Center, b);

            return aDistance >= bDistance;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}