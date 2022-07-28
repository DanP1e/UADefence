using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Spawn
{
    public class OverlapTest : MonoBehaviour
    {
        [SerializeField] private List<InterfaceComponent<IObstacle>> _obstacleComponents;

        private List<IObstacle> _obstacles;

        [Inject]
        public void Construct()
        {
            _obstacles = new List<IObstacle>();
            foreach (var obstacleComponent in _obstacleComponents)
            {
                _obstacles.Add(obstacleComponent.Interface);
            }
        }

        public bool CheckIsOverlaped() 
        {
            foreach (var obstacleA in _obstacles)
            {
                foreach (var obstacleB in _obstacles)
                {
                    
                }
            }

            return false;
        }

        protected void OnEnable()
        {
            UnityEngine.Debug.Log($"Is somebody overlaped = {CheckIsOverlaped()}");
        }
    }
}
