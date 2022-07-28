using InspectorAddons;
using Spawn;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Entity
{
    public class AliveObjectsContainer : MonoBehaviour, IContainer<InterfaceComponent<IAlive>>
    {
        [SerializeField] private List<InterfaceComponent<ISpawner<GameObject>>> _spawners;
        [SerializeField] private List<InterfaceComponent<IAlive>> _aliveComponents;

        private void TryAddAliveComponentFrom(GameObject gameObject)
        {
            Component aliveComponent = gameObject.GetComponent(typeof(IAlive));
            if (aliveComponent != null)
            {
                _aliveComponents.Add(new InterfaceComponent<IAlive>() { Object = aliveComponent });
                IAlive alive = (IAlive)aliveComponent;
                alive.Died.AddListener(OnAliveObjectDied);
            }
        }
        private void OnAliveObjectDied(IAlive obj)
        {
            obj.Died.RemoveListener(OnAliveObjectDied);
            _aliveComponents.Remove(_aliveComponents.Find((x) => x.Object == obj));
        }

        protected void Start()
        {
            foreach (var item in _spawners)
            {
                item.Interface.ObjectSpawned.AddListener(TryAddAliveComponentFrom);
            }
        }

        public IEnumerable<InterfaceComponent<IAlive>> GetElements()
            => _aliveComponents;
    }
}
