using System;
using UnityEngine;

namespace Weapon
{
    public interface IBulletDeliverer
    {
        /// <summary>
        /// Возвращает задетые объекты в текущем кадре.
        /// </summary>
        BulletHit[] GetCurrentHits();

        /// <summary>
        /// Запускает пулю в указаном направлении.
        /// </summary>
        void Throw(Vector3 direction);
    }
}