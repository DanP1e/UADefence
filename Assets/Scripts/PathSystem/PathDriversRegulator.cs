using InspectorAddons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PathSystem
{
    public class PathDriversRegulator : MonoBehaviour, IDriversRegistrator
    {
        [SerializeField] private InterfaceComponent<IPathPresenter> _pathPresenterComponent;

        private IPathPresenter _pathPresenter;
        private List<IPathDriver> _registeredDrivers = new List<IPathDriver>();
        private bool _speedUpdating = false;

        private void Awake()
        {
            _pathPresenter = _pathPresenterComponent.Interface;
        }
        private void OnDestroy()
        {
            foreach (var item in _registeredDrivers)
            {
                item.LeftPath -= OnPathDriverLeftPath;
                item.SpeedChanged -= OnPathDriverSpeedChanged;
            }
        }
        private void UpdateDriversSpeed()
        {
            if (_speedUpdating)
                return;

            _speedUpdating = true;

            if (_registeredDrivers.Count >= 1)
                _registeredDrivers[0].Speed = _registeredDrivers[0].MaxSpeed;

            for (int i = 1; i < _registeredDrivers.Count; i++)
                _registeredDrivers[i].Speed = Mathf.Min(
                        _registeredDrivers[i - 1].Speed,
                        _registeredDrivers[i].MaxSpeed);          

            _speedUpdating = false;
        }
        private void UnregisterDriver(IPathDriver pathDriver)
        {
            pathDriver.LeftPath -= OnPathDriverLeftPath;
            pathDriver.SpeedChanged -= OnPathDriverSpeedChanged;
            _registeredDrivers.Remove(pathDriver);
            SortDriversByPathProgress();
            UpdateDriversSpeed();
        }
        private void SortDriversByPathProgress()
           => _registeredDrivers.Sort((a, b) => a.GetPathProgress().CompareTo(b.GetPathProgress()));
        private void OnPathDriverSpeedChanged(float newSpeed)
           => UpdateDriversSpeed();
        private void OnPathDriverLeftPath(IPathDriver sender, IPathPresenter leftPath)
        {
            if (leftPath == _pathPresenter)
                UnregisterDriver(sender);
        }

        public void RegisterDriver(IPathDriver pathDriver)
        {
            if (_registeredDrivers.Contains(pathDriver))
                throw new ArgumentException($"This {nameof(pathDriver)} is already registrated!");

            pathDriver.SetPathPresenter(_pathPresenter);
            pathDriver.LeftPath += OnPathDriverLeftPath;
            pathDriver.SpeedChanged += OnPathDriverSpeedChanged;
            _registeredDrivers.Add(pathDriver);
            SortDriversByPathProgress();
            UpdateDriversSpeed();
        }
    }
}

