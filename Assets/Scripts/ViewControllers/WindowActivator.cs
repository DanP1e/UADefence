using Interaction;
using System;
using UnityEngine;

namespace ViewControllers
{
    public class WindowActivator : MonoBehaviour, IInteractive
    {
        [SerializeField] private Window _window;

        public bool Interact(Vector3 interactPoint)
        {
            _window.Show();
            _window.MoveToWorldPoint(interactPoint);
            return true;
        }

        public bool StopInteraction()
        {
            _window.Hide();
            return true;
        }
    }
}
