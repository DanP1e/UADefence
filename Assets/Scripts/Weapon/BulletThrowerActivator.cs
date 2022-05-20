using InspectorAddons;
using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class BulletThrowerActivator : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IBulletThrower> _bulletThrowerComponent;
        [SerializeField] private float _throwCooldown = 0.2f;

        private IBulletThrower _bulletThrower;

        private void Awake()
        {
            _bulletThrower = _bulletThrowerComponent.Interface;
        }
        private void OnEnable()
        {
            StartCoroutine(StartTrhowProcess());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        private IEnumerator StartTrhowProcess() 
        {
            while (true)
            {
                yield return new WaitForSeconds(_throwCooldown);
                _bulletThrower.Throw();
            }
        }
    }
}
