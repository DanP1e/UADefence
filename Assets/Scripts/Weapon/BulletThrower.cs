using InspectorAddons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Weapon
{
    public class BulletThrower : MonoBehaviour, IBulletThrower
    {
        [SerializeField] private InterfaceComponent<IBulletDeliverer> _bulletDeliver;
        [SerializeField] private Transform _muzle;

        public UnityEvent<GameObject> BulletThrown;

        public void Throw()
        {
            GameObject bulletObject = Instantiate(
                _bulletDeliver.Object.gameObject,
                _muzle.transform.position,
                _muzle.transform.rotation);
            IBulletDeliverer bullet = (IBulletDeliverer)bulletObject.GetComponent(typeof(IBulletDeliverer));
            bullet.Throw(_muzle.forward);
            BulletThrown?.Invoke(bulletObject);
        }
    }
}
