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
        private bool _isStarted;

        public UnityEvent TimeoutEvent { get => _timeoutEvent; }
        public float Interval { get => _time; set => _time = value; }
        public bool IsCyclical { get => _isCyclical; set => _isCyclical = value; }
        public bool IsStarted { get => _isStarted; }

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
            _isStarted = true;
            StopAllCoroutines();
            StartCoroutine(HideDeactivator());
        }
        public void StopTimer()
        {
            _isStarted = false;
            StopAllCoroutines();
        }
    }
}
