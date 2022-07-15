using Entity;
using InspectorAddons;
using UnityEngine;
using Utilities;
using Weapon.Aim;
using Zenject;

namespace Weapon
{
    public class TargetInRangePresenter : 
        MonoBehaviour, 
        ITargetPresenter<InterfaceComponent<IAlive>>       
    {
        private IAreaPresenter _rangeKepeer;
        private IContainer<InterfaceComponent<IAlive>> _aliveObjectsContainer;

        [Inject]
        public void Construct(
            IAreaPresenter rangeKepeer,
            IContainer<InterfaceComponent<IAlive>> aliveObjectsContainer)
        {
            _rangeKepeer = rangeKepeer;
            _aliveObjectsContainer = aliveObjectsContainer;
        }       

        public bool TryGetTargetComponent(
            Vector3 seekerPosition,
            out InterfaceComponent<IAlive> closestComponent)
        {
            foreach (var item in _aliveObjectsContainer.GetElements())
            {
                if (_rangeKepeer.IsInArea(item.Object.transform.position))
                {
                    closestComponent = item;
                    return true;
                }
            }
            closestComponent = null;
            return false;
        }       
    }
}
