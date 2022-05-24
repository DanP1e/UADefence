using Effects;
using InspectorAddons;
using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class RepeatingBulletThrower : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IBulletThrower> _bulletThrowerComponent;
        [SerializeField] private InterfaceComponent<ITimer> _timerComponent;

        private IBulletThrower _bulletThrower;
        private ITimer _timer;
        private void Awake()
        {
            _bulletThrower = _bulletThrowerComponent.Interface;
            _timer = _timerComponent.Interface;
            _timer.TimeoutEvent.AddListener(_bulletThrower.Throw);
        }
        private void OnEnable()
        {
            _timer.StartTimer();
        }
        private void OnDisable()
        {
            _timer.StopTimer();
        }
        
    }
}
