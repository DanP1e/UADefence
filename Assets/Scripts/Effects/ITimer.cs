using UnityEngine.Events;

namespace Effects
{
    public interface ITimer
    {
        /// <summary>
        /// The time counted from the moment the object was 
        /// activated, after which the event will be triggered.
        /// </summary>
        float Time { get; set; }
        /// <summary>
        /// Determines whether the timer will repeat.
        /// </summary>
        bool IsCyclical { get; set; }
        UnityEvent TimeoutEvent { get; }        

        void StartTimer();
        void StopTimer();
    }
}