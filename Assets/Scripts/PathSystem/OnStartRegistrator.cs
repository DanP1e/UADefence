using InspectorAddons;
using System;
using UnityEngine;

namespace PathSystem
{
    public sealed class OnStartRegistrator : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IPathDriver> _pathDriverComponent;
        [SerializeField] private InterfaceComponent<IDriversRegistrator> _driversSetComponent;

        private void Start()
        {
            _driversSetComponent.Interface.RegisterDriver(_pathDriverComponent.Interface);
        }
    }
}
