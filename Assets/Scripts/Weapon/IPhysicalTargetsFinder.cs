using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public interface IPhysicalTargetsFinder
    {
        List<Rigidbody> FindRigidbodies();
    }
}
