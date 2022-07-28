using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Utilities;
using ViewControllers;
using Zenject;

namespace Interaction
{
    public sealed class RaycastUser : MonoBehaviour, IInteractiveObjectsUser
    {
        private OverUITester _overUITester;
        private MainControls _mainControls;
        private List<ISelectable> _selections = new List<ISelectable>();
        private List<IInteractive> _interactiveComponents = new List<IInteractive>();
        private GameObject _gameObject;
        private Vector3 _interactPoint;
        private bool _isInteracting = false;
        private bool _isOnPressMouseOverUI = false;

        public Vector3 InteractionPoint => _interactPoint;
        public List<IInteractive> InteractiveComponents => _interactiveComponents;
        public GameObject InteractedGameObject => _gameObject;

        public event UnityAction<GameObject, List<IInteractive>, Vector3> Interacted;

        [Inject]
        public void Construct(IWindowsHandler windowsHandler) 
        {
            windowsHandler.WindowHided += OnSomeWindowHided;
        }

        private void OnSomeWindowHided(IWindow arg0)
        {
            _isInteracting = false;
        }

        private void Awake()
        {
            _overUITester = new OverUITester(LayerMask.NameToLayer("UI"));
            _mainControls = new MainControls();
            _mainControls.Global.CursorPress.performed += OnCursorPress;
            _mainControls.Global.CursorRelease.performed += OnCursorRelease;
            _mainControls.Enable();
        }

        private void OnCursorPress(InputAction.CallbackContext obj)
        {
            _isOnPressMouseOverUI = _overUITester.IsPointerOverUIElement();

            if (_isInteracting)
            {
                if (!_isOnPressMouseOverUI)
                {
                    StopInteractions();
                    _isInteracting = false;
                }
            }
            else
            {
                _interactiveComponents = GetCmponentsFromRay<IInteractive>();
                _isInteracting = _interactiveComponents.Count > 0;
            }

            SelectComponents();
        }

        private void OnCursorRelease(InputAction.CallbackContext obj)
        {
            UnselectComponents();

            if (_gameObject != GetGameObject()
                || _isOnPressMouseOverUI
                || !_isInteracting)
                return;

            InteractWithComponents();
        }

        private void InteractWithComponents()
        {
            foreach (var item in _interactiveComponents)
                if (item != null)
                    item.Interact(_interactPoint);

            Interacted?.Invoke(_gameObject, _interactiveComponents, _interactPoint);
        }

        private void SelectComponents()
        {
            _selections = GetCmponentsFromRay<ISelectable>();
            foreach (var item in _selections)
                item.Select();
        }

        private void UnselectComponents()
        {
            foreach (var item in _selections)
                if (item != null)
                    item.Unselect();

            _selections.Clear();
        }

        private void StopInteractions()
        {
            foreach (var item in _interactiveComponents)
                if (item != null)
                    item.StopInteraction();

            _interactiveComponents.Clear();
        }

        private GameObject GetGameObject() 
        {
            if (_overUITester.IsPointerOverUIElement())
                return null;

            Ray ray = Camera.main.ScreenPointToRay(
                _mainControls.Global.MouseScreenPosition.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _interactPoint = hit.point;
                GameObject obj = hit.collider.gameObject;
                return obj;
            }

            return null;
        }

        private List<T> GetCmponentsFromRay<T>()
            where T: class 
        {
            List<T> reuslt = new List<T>();
            GameObject obj = GetGameObject();

            if (obj == null)
                return reuslt;

            foreach (var item in obj.GetComponents(typeof(T)))
                    reuslt.Add((T)(object)item);

            _gameObject = obj;
            return reuslt;
        }
    }
}
