using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public class EventTimer : MonoBehaviour
    {
        [Tooltip("Время отсчитанное с момента активации объекта " +
            "по истечению которого будет вызвано событие.")]
        [SerializeField] private float _time;
        [SerializeField] private UnityEvent _timeoutEvent;

        private void OnEnable()
        {
            StartCoroutine(HideDeactivator());
        }

        private IEnumerator HideDeactivator()
        {
            yield return new WaitForSeconds(_time);
            _timeoutEvent?.Invoke();
        }
    } 
}
