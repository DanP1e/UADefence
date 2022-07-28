using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class ObstacleContainer : MonoBehaviour, IObstaclesContainer
    {
        private List<IObstacle> _obstacles = new List<IObstacle>();

        public void AddObstacle(IObstacle newObstacle)
        {
            if (_obstacles.Contains(newObstacle))
                throw new ArgumentException("This obstacle is already in collection!");

            _obstacles.Add(newObstacle);
            newObstacle.Destroyed += OnObstacleDestroyed;
        }

        public IEnumerable<IObstacle> GetElements()
            => _obstacles;

        public bool IsSomeObstacleOverlap(IObstacle obstacleB)
        {
            foreach (var obstacleA in _obstacles)
            {
                if (obstacleA == obstacleB)
                    continue;

                if (obstacleA.IsOverlap(obstacleB))
                    return true;
            }

            return false;
        }

        private void OnObstacleDestroyed(IObstacle obstacle)
        {
            obstacle.Destroyed -= OnObstacleDestroyed;
            _obstacles.Remove(obstacle);
        }
    }
}
