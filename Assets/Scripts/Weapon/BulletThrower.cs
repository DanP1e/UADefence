using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Weapon
{
    public class BulletThrower : MonoBehaviour, IBulletThrower
    {
        [SerializeField] private Transform _muzle;

        private DiContainer _sceneContainer;
        public UnityEvent<GameObject> BulletThrown;

        [Inject]
        public void Construct(
            [Inject(Id = "scene")]
            DiContainer sceneContainer) 
        {
            _sceneContainer = sceneContainer;
        }

        public void Throw(IBulletRepresentative bulletPrefab, Vector2 damage)
        {
            GameObject bulletObject = _sceneContainer.InstantiatePrefab(
                bulletPrefab.BulletRootObject);

            bulletObject.transform.position = _muzle.transform.position;
            bulletObject.transform.rotation = _muzle.transform.rotation;

            IBulletRepresentative bullet = (IBulletRepresentative)bulletObject.GetComponent(typeof(IBulletRepresentative));
            bullet.DamageMaker.SetDamage(damage);
            bullet.Deliverer.Throw(_muzle.forward);
            BulletThrown?.Invoke(bulletObject);
        }
    }
}
