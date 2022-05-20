using System;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class ObjectDestroyer : MonoBehaviour
    {
        [SerializeField] private List<UnityEngine.Object> _destroyedObjects;

        public void DestroyObjects() 
        {
            foreach (var item in _destroyedObjects)
            {
                Destroy(item);
            }
        }
    }
}
