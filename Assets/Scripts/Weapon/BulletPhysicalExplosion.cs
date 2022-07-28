using UnityEngine;
using Zenject;

namespace Weapon
{
    public sealed class BulletPhysicalExplosion : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 500;
        [SerializeField] private float _explosionRadius = 3;

        private IDetonator _detonator;
        private IPhysicalTargetsFinder _physicalTargetsFinder;

        [Inject]
        public void Construct(IDetonator detonator,
            IPhysicalTargetsFinder physicalTargetsFinder) 
        {
            _detonator = detonator;
            _physicalTargetsFinder = physicalTargetsFinder;
        }

        private void OnEnable()
        {
            _detonator.Detonated += OnBulletDetonated;
        }

        private void OnDisable()
        {
            _detonator.Detonated -= OnBulletDetonated;
        }

        private void OnBulletDetonated()
        {
            foreach (var rb in _physicalTargetsFinder.FindRigidbodies())
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
