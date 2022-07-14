using UnityEngine;

namespace Entity.Units
{
    public interface IUnitRotator
    {
        void RotateBodyTo(Vector3 target, float movementFactor, IUnit sender);
    }
}