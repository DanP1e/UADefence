using Utilities;

namespace Spawn
{
    public interface IObstaclesContainer : IContainer<IObstacle>
    {
        public void AddObstacle(IObstacle newObstacle);

        public bool IsSomeObstacleOverlap(IObstacle obstacleB);
    }
}
