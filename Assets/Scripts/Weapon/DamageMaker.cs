using Entity;
using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class DamageMaker : BulletDetonator
    {      
        [SerializeField] private float _minDamage = 50;
        [SerializeField] private float _maxDamage = 70;
        [Tooltip("График распростронения урона в зависимости от расстояния")]
        [SerializeField] private AnimationCurve _damageFunction;
        [SerializeField] private InterfaceComponent<ITargetsFinder<InterfaceComponent<IAlive>>> _targetsFinder;

        public UnityEvent<InterfaceComponent<IAlive>> AliveObejctDamaged;

        protected override void OnDetonating()
        {
            List<InterfaceComponent<IAlive>> aliveTargets = _targetsFinder.Interface.FindTargets();
            foreach (var item in aliveTargets)
            {
                float distToItem = Vector3.Distance(
                                    transform.position, 
                                    item.Object.transform.position);

                item.Interface.MakeDamage(
                    Random.Range(_minDamage, _maxDamage) * _damageFunction.Evaluate(distToItem));

                AliveObejctDamaged?.Invoke(item);
            }
        }
    }
}
