using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public interface IInteractiveObjectsUser
    {
        public event UnityAction<GameObject, List<IInteractive>, Vector3> Interacted;

        public Vector3 InteractionPoint { get; }
        public List<IInteractive> InteractiveComponents { get; }
        public GameObject InteractedGameObject { get; }
    }
}
