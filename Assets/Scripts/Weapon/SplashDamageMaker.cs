using Entity;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public class SplashDamageMaker : MonoBehaviour, IDamageMaker
    {
        [SerializeField] private float _minDamage = 50;
        [SerializeField] private float _maxDamage = 70;
        [Tooltip("График распростронения урона в зависимости от расстояния")]
        [SerializeField] private AnimationCurve _damageFunction;

        private IBulletDeliverer _bulletDeliverer;

        public float MinDamage { get => _minDamage; }
        public float MaxDamage { get => _maxDamage; }

        [Inject]
        public void Construct(
            IBulletDeliverer bulletDeliverer)
        {
            _bulletDeliverer = bulletDeliverer;
        }

        public void SetDamage(Vector2 minMaxDamage)
        {
            _minDamage = Mathf.Min(minMaxDamage.x, minMaxDamage.y);
            _maxDamage = Mathf.Max(minMaxDamage.x, minMaxDamage.y);
        }

        protected virtual void OnEnable()
        {
            _bulletDeliverer.ObjectHit += OnObjectHit;
        }

        protected virtual void OnDisable()
        {
            _bulletDeliverer.ObjectHit -= OnObjectHit;
        }

        private void OnObjectHit(BulletHit bulletHit)
        {
            IAlive aliveObject
                = bulletHit.GameObject.GetComponent(typeof(IAlive)) as IAlive;

            if (aliveObject == null)
                return;

            float distToHit = Vector3.Distance(transform.position, bulletHit.Point);
            aliveObject.MakeDamage(
                    Random.Range(_minDamage, _maxDamage) * _damageFunction.Evaluate(distToHit));
        }
    }
}
