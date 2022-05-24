using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace PathSystem
{
    public class PathDriversSpawner : MonoBehaviour, ISpawner<GameObject>
    {
        [SerializeField] private float _gizmosScale = 1;
        [SerializeField] private InterfaceComponent<IDriversRegistrator> _driversRegistrator;
        [SerializeField] private List<InterfaceComponent<IPathDriver>> _spawnList;
        [SerializeField] private UnityEvent<GameObject> _objectSpawned;

        private int _spawnCounter = 0;

        public UnityEvent<GameObject> ObjectSpawned => _objectSpawned;

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _gizmosScale);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.25f * _gizmosScale);
        }

        public GameObject SpawnObject()
        {           
            GameObject spawnedObject = Instantiate(
                _spawnList[_spawnCounter].Object.gameObject,
                transform.position,
                transform.rotation);

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
    }
}
