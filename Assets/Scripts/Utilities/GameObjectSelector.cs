using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class GameObjectSelector : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objects;

        private void DisableAllObjects()
        {
            foreach (var item in _objects)
                item.SetActive(false);
        }

        public void SelectObject(int objectId) 
        {
            DisableAllObjects();
            _objects[objectId].SetActive(true);
        }
    }
}
