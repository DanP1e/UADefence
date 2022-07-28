using Interaction;
using System;
using UnityEngine;
using Utilities;

namespace Economics
{
    public class TowerActivator : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObjectSelector _gameOjectSelector;

        public bool Interact(Vector3 interactPoint)
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

        public bool StopInteraction()
        {
            return true;
        }
    }
}
