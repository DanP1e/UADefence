using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;

namespace PathSystem
{
    public class PathDriversSpawner : MonoBehaviour
    {
        [Header("Gizmos: ")]
        [SerializeField] private float _spawnDirectionScale = 1;
        [Header("Spawner: ")]
        [SerializeField] private InterfaceComponent<IDriversRegistrator> _driversRegistrator;
        [SerializeField] private float _spawnCooldown = 1f;
        [SerializeField] private List<InterfaceComponent<IPathDriver>> _spawnList;
        
        private int _spawnCounter = 0;
        private float _timer = 0;

        protected void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _spawnCooldown)
            {
                IPathDriver driver = (IPathDriver)Instantiate(
                    _spawnList[_spawnCounter].Object.gameObject,
                    transform.position,
                    transform.rotation).GetComponent(typeof(IPathDriver));

                _driversRegistrator.Interface.RegisterDriver(driver);

                _spawnCounter++;

                if (_spawnCounter >= _spawnList.Count)
                    _spawnCounter = 0;

                _timer = 0;
            }
        }
        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * _spawnDirectionScale);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.25f * _spawnDirectionScale);
        }
    } 
}
