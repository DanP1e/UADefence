using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public class UpdateTimer : MonoBehaviour, ITimer
    {
        [SerializeField] private float _time = 1f;
        [SerializeField] private bool _isCyclical;      
        [SerializeField] private UnityEvent _timeoutEvent;

        private float _timer = 0;

        public float Interval { get => _time; set => _time = value; }
        public bool IsCyclical { get => _isCyclical; set => _isCyclical = value; }
        public bool IsStarted { get => enabled; }
        public UnityEvent TimeoutEvent => _timeoutEvent;

        private void Tick()
        {
            _timer = 0;
            _timeoutEvent?.Invoke();
            OnTimeOut();

            if (!_isCyclical)
                StopTimer();
        }

        protected void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _time)
                Tick();
        }      

        protected virtual void OnTimeOut() { }

        public void StartTimer()
        {
            _timer = 0;            
            enabled = true;
        }

        public void StopTimer()
        {
            enabled = false;
        }
    }
}
