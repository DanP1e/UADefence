using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public sealed class RaycastUser : MonoBehaviour
    {
        private MainControls _mainControls;
        private List<ISelectable> _selections = new List<ISelectable>();
        private List<IInteractive> _interactives = new List<IInteractive>();
        private GameObject _gameObject;

        private void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.Global.CursorPress.performed += OnCursorPress;
            _mainControls.Global.CursorRelease.performed += OnCursorRelease;
            _mainControls.Enable();
        }

        private void OnCursorPress(InputAction.CallbackContext obj)
        {
            _interactives = GetCmponentsFromRay<IInteractive>();

            _selections = GetCmponentsFromRay<ISelectable>();
            foreach (var item in _selections)
                item.Select();
        }
        private void OnCursorRelease(InputAction.CallbackContext obj)
        {                    
            foreach (var item in _selections)
                item.Unselect();

            _selections.Clear();

            if (_gameObject != GetGameObject())
                return;

            foreach (var item in _interactives)
                item.Interact();

            _interactives.Clear();
        }
        private GameObject GetGameObject() 
        {         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                return hit.collider.gameObject;

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
