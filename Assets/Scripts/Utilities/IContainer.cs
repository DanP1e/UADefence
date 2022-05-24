using System.Collections.Generic;

namespace Utilities
{
    public interface IContainer<T>
    {
        IEnumerable<T> GetElements();
    }
}
