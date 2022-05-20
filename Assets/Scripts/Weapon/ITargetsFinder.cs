using System.Collections.Generic;

namespace Weapon
{
    public interface ITargetsFinder<T>
    {
        List<T> FindTargets();
    }
}