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
        /// <summary>
        /// Returns the point around which objects will rotate.
        /// </summary>
        Vector3 GetUnitPivotPosition();
        void MakeMovementFrame(Vector3 target, float speed);
    }
}