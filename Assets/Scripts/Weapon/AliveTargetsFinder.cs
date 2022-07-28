using Entity;
using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class AliveTargetsFinder : MonoBehaviour, 
        ITargetsFinder<InterfaceComponent<IAlive>>
    {
        [SerializeField] private float _findRadius = 4f;

        public List<InterfaceComponent<IAlive>> FindTargets()
        {
            List<InterfaceComponent<IAlive>> aliveTargets = new List<InterfaceComponent<IAlive>>();
            Collider[] colliders = Physics.OverlapSphere(transform.position, _findRadius);
            foreach (var item in colliders)
            {
                Component aliveComponent = item.transform.GetComponent(typeof(IAlive));
                if(aliveComponent != null)
                    aliveTargets.Add(new InterfaceComponent<IAlive>() {Object = aliveComponent});
            }

            return aliveTargets;
        }
    }
}
