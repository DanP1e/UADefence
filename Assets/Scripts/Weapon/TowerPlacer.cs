using System;
using UnityEngine;
using UnityEngine.Events;
using Utilities;
using Zenject;

namespace Weapon
{
    public class TowerPlacer : MonoBehaviour, ITowerPlacer
    {
        private DiContainer _sceneContainer;

        [Inject]
        public void Construct(
            [Inject(Id = "scene")]
            DiContainer sceneContainer)
        {
            _sceneContainer = sceneContainer;
        }

        public void PlaceTower(ITower towerPrefab, Vector3 placePosition)
        {
            var obj = _sceneContainer.InstantiatePrefab(towerPrefab.TowerGameObject);
            obj.transform.position = placePosition;
        }
    }
}
