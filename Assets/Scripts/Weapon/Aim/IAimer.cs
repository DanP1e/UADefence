using UnityEngine;

namespace Weapon.Aim
{
    public interface IAimer
    {
        float AimRange { get; set; }
        void StartAiming(Transform target);
        void StopAim();
        bool IsAimed();
    }
}
