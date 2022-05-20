using Entity;
using InspectorAddons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class AliveHitTargetsFinder : MonoBehaviour, ITargetsFinder<InterfaceComponent<IAlive>>
    {
        [SerializeField] private InterfaceComponent<IBulletDeliverer> _bulletDelivererComponent;

        public List<InterfaceComponent<IAlive>> FindTargets()
        {
            List<InterfaceComponent<IAlive>> aliveTargets 
                = new List<InterfaceComponent<IAlive>>();
            BulletHit[] hits = _bulletDelivererComponent.Interface.GetCurrentHits();

            if(hits == null)
                return aliveTargets;

            foreach (var item in hits)
            {
                GameObject target = item.GameObject;
                if (target == null)
                    continue;
                Component aliveComponent = target.GetComponent(typeof(IAlive));
                if (aliveComponent == null)
                    continue;

                aliveTargets.Add(new InterfaceComponent<IAlive>() { Object = aliveComponent });
            }
            return aliveTargets;
        }
    }
}
