using UnityEngine;
using Zenject;

namespace Weapon
{
    public class BulletDestroyer : MonoBehaviour
    {
        private IDetonator _detonator;
        private IBulletRepresentative _bulletRepresentative;

        [Inject]
        public void Construct(
            IDetonator detonator,
            IBulletRepresentative bulletRepresentative) 
        {
            _detonator = detonator;
            _bulletRepresentative = bulletRepresentative;

            _detonator.Detonated += () => Destroy(_bulletRepresentative.BulletRootObject);     
        }
    }
}
