using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Weapon
{
    public class BulletDetonator : MonoBehaviour, IDetonator
    {
        [SerializeField] private float _detonationDelay = 0.02f;

        public event UnityAction Detonating;
        public event UnityAction Detonated;

        private bool _isDetonating = false;
        private IBulletDeliverer _bulletDeliverer;

        [Inject]
        public void Construct(IBulletDeliverer bulletDeliverer) 
        {
            _bulletDeliverer = bulletDeliverer;
        }

        public void Detonate()
        {
            if (!_isDetonating)
                StartCoroutine(MakeBoom());
        }

        protected virtual void OnDetonating() { }

        protected virtual void OnEnable()
        {
            _bulletDeliverer.ObjectHit += OnObjectHit;
        }

        protected virtual void OnDisable()
        {
            _bulletDeliverer.ObjectHit -= OnObjectHit;
        }

        private void OnObjectHit(BulletHit arg0)
        {
            Detonate();
        }

        private IEnumerator MakeBoom()
        {
            _isDetonating = true;
            yield return new WaitForSeconds(_detonationDelay);
            Detonating?.Invoke();
            OnDetonating();
            yield return new WaitForEndOfFrame();
            Detonated?.Invoke();
        }     
    }
}
