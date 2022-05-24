using Effects;
using Entity;
using InspectorAddons;
using UnityEngine;
using Utilities;
using System.Linq;

namespace Weapon
{
    public class TargetInRangePresenter : 
        MonoBehaviour, 
        ITargetPresenter<InterfaceComponent<IAlive>>       
    {
        [SerializeField] private InterfaceComponent<IAreaPresenter> _areaPresenterComponent;
        [SerializeField]
        InterfaceComponent<IContainer<InterfaceComponent<IAlive>>> _aliveObjectsContainerComponent;

        private IAreaPresenter _rangeKepeer;
        private IContainer<InterfaceComponent<IAlive>> _aliveObjectsContainer;

        protected void Awake()
        {
            _rangeKepeer = _areaPresenterComponent.Interface;
            _aliveObjectsContainer = _aliveObjectsContainerComponent.Interface;
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
