using InspectorAddons;
using Spawn;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace PathSystem
{
    public class PathDriversSpawner : MonoBehaviour, ISpawner<GameObject>
    {
        [SerializeField] private float _gizmosScale = 1;
        [SerializeField] private InterfaceComponent<IDriversRegistrator> _driversRegistrator;
        [SerializeField] private List<InterfaceComponent<IPathDriver>> _spawnList;
        [SerializeField] private UnityEvent<GameObject> _objectSpawned;

        private int _spawnCounter = 0;
        private DiContainer _sceneContainer;

        public UnityEvent<GameObject> ObjectSpawned => _objectSpawned;

        [Inject]
        public void Construct(
            [Inject(Id = "scene")] DiContainer sceneContainer)
        {
            _sceneContainer = sceneContainer;
        }

        public GameObject SpawnObject()
        {           
            GameObject spawnedObject = _sceneContainer.InstantiatePrefab(
                _spawnList[_spawnCounter].Object.gameObject);

            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = transform.rotation;

            IPathDriver driver = (IPathDriver)spawnedObject.GetComponent(typeof(IPathDriver));

            _driversRegistrator.Interface.RegisterDriver(driver);
            _spawnCounter++;

            if (_spawnCounter >= _spawnList.Count)
                _spawnCounter = 0;

            ObjectSpawned?.Invoke(spawnedObject);

            return spawnedObject;
        }

        public void TrySpawnNextObject()
        {
            if (!gameObject.activeInHierarchy 
                || !enabled)
                return;

            SpawnObject();
        }

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _gizmosScale);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.25f * _gizmosScale);
        }
    }
}
