using UnityEngine;

namespace Spawn
{
    public class ColliderObstacle : Obstacle
    {
        [SerializeField] private Collider _collider;

        protected override Vector3 Center { get => _collider.bounds.center; }

        public override Vector3 ClosestPoint(Vector3 destination)
            => _collider.ClosestPoint(destination);  
    }
}
