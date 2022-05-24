using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public class CoroutineTimer : MonoBehaviour, ITimer
    {
        [SerializeField] private float _time;
        [SerializeField] private bool _isCyclical = false;
        [SerializeField] private UnityEvent _timeoutEvent;

        private Coroutine _coroutine;

        public UnityEvent TimeoutEvent { get => _timeoutEvent; }
        public float Time { get => _time; set => _time = value; }
        public bool IsCyclical { get => _isCyclical; set => _isCyclical = value; }

        private void OnEnable()
        {
            StartTimer();
        }
        private IEnumerator HideDeactivator()
        {
            do
            {
                yield return new WaitForSeconds(_time);
                _timeoutEvent?.Invoke(); 
            } while (_isCyclical);
        }

        public void StartTimer()
        {
            StopAllCoroutines();
            StartCoroutine(HideDeactivator());
        }
        public void StopTimer()
        {
            StopAllCoroutines();
        }
    }
}
