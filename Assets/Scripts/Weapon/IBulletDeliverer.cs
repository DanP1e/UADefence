using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public interface IBulletDeliverer
    {
        event UnityAction<BulletHit> ObjectHit;

        /// <summary>
        /// Возвращает задетые объекты в текущем кадре.
        /// </summary>
        BulletHit[] GetCurrentHits();

        /// <summary>
        /// Начинает движение в указаном направлении.
        /// </summary>
        void Throw(Vector3 direction);
    }
}