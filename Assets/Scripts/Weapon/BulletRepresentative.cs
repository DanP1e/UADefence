using UnityEngine;
using Zenject;

namespace Weapon
{
    public class BulletRepresentative : MonoBehaviour, IBulletRepresentative
    {
        [SerializeField] private GameObject _bulletRootObject;

        private IDamageMaker _damageMaker;
        private IBulletDeliverer _bulletDeliverer;

        public IDamageMaker DamageMaker => _damageMaker;
        public IBulletDeliverer Deliverer => _bulletDeliverer;

        public GameObject BulletRootObject { get => _bulletRootObject; }

        [Inject]
        public void Construct(
            IDamageMaker damageMaker, 
            IBulletDeliverer bulletDeliverer) 
        {
            _damageMaker = damageMaker;
            _bulletDeliverer = bulletDeliverer;
        }
    }
}
