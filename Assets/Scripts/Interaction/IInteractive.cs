using UnityEngine;

namespace Interaction
{
    public interface IInteractive
    {
        public bool Interact(Vector3 interactPoint);
        public bool StopInteraction();
    }
}
