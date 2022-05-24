using System;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon.Aim
{
    public interface IAimer
    {
        void StartAiming(Transform target);
        void StopAim();
        bool IsAimed();
    }
}
