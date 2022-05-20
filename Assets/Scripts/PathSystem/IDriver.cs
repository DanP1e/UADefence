using System;
using UnityEngine;

namespace PathSystem
{
    public interface IDriver
    {
        event Action<float> SpeedChanged;
        float MaxSpeed { get; }
        float Speed { get; set; }
        void MoveTo(Vector3 target);
        void Stop();
    }
}