using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

namespace Weapon
{
    public class CannonsContainer : MonoBehaviour, IContainer<ICannon>
    {
        private List<ICannon> _cannons;

        public IEnumerable<ICannon> GetElements()
        {
            if(_cannons == null)
                _cannons = GetComponentsInChildren(typeof(ICannon)).Cast<ICannon>().ToList();

            return _cannons;
        }
        
    }
}
