using System;
using UnityEngine;

namespace Entity.Units
{
    public interface IUnit
    {
        /// <summary>
        /// Returns the point from which other objects will interact.
        /// </summary>
        Vector3 GetInteractPoint();
        void MakeMovementFrame(Vector3 target, float speed);
    }
}