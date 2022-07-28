using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ViewControllers
{
    public class WindowsHandler : MonoBehaviour, IWindowsHandler
    {
        private List<IWindow> _windows = new List<IWindow>();

        public event UnityAction<IWindow> WindowHided;
        public event UnityAction<IWindow> WindowShown;
        public event UnityAction<IWindow> WindowDestroying;

        public void AddWindow(IWindow window)
        {
            window.Hided += OnWindowHided;
            window.Shown += OnWindowShown;
            window.Destroying += OnWindowDestroying;
            _windows.Add(window);         
        }

        private void OnWindowDestroying(IWindow window)
        {
            window.Hided -= OnWindowHided;
            window.Shown -= OnWindowShown;
            window.Destroying -= OnWindowDestroying;
            _windows.Remove(window);
            WindowDestroying?.Invoke(window);
        }

        private void OnWindowShown(IWindow window)
        {
            WindowShown?.Invoke(window);
        }

        private void OnWindowHided(IWindow window)
        {
            WindowHided?.Invoke(window);
        }

        public IEnumerable<IWindow> GetElements()
            => _windows;    
    }
}
