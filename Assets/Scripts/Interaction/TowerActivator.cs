using System;
using UnityEngine;
using Utilities;

namespace Interaction
{
    public class TowerActivator : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObjectSelector _gameOjectSelector;

        public bool Interact()
        {
            try
            {
                _gameOjectSelector.SelectObject(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }
    }
}
