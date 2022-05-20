using InspectorAddons;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class BulletDetonator : MonoBehaviour
    {
        [SerializeField] private GameObject _detonateEffect;
        [SerializeField] private Component[] _removableComponents;
        [SerializeField] private float _detonationDelay = 0.1f;
        [SerializeField] private float _detonationTime;
        private bool _isDetonating = false;

        private IEnumerator MakeBoom()
        {
            _isDetonating = true;
            yield return new WaitForSeconds(_detonationDelay);          
            OnDetonating();
            foreach (Component item in _removableComponents)
                Destroy(item);
            
            _detonateEffect.gameObject.SetActive(true);

            yield return new WaitForSeconds(_detonationTime);       
            OnDetonated();
            Destroy(gameObject);
        }

        /// <summary>
        /// Вызывается в момент детонации (перед проигрыванием эффектов).
        /// </summary>
        protected virtual void OnDetonating() { }
        /// <summary>
        /// Вызывается после детонации (после проигрывания эффектов).
        /// </summary>
        protected virtual void OnDetonated() { }

        public void Detonate()
        { 
            if(!_isDetonating)
                StartCoroutine(MakeBoom()); 
        }
    } 
}
