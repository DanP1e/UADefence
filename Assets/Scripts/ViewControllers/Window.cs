using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace ViewControllers
{
    public class Window : MonoBehaviour, IWindow
    {
        [SerializeField] private RectTransform _windowTransform;

        public event UnityAction<IWindow> Hided;
        public event UnityAction<IWindow> Shown;
        public event UnityAction<IWindow> Destroying;

        [Inject]
        public void Construct(IWindowsHandler windowsHandler) 
        {
            windowsHandler.AddWindow(this);
        }

        public void Show()
        {
            _windowTransform.gameObject.SetActive(true);
            OnShowing();
            Shown?.Invoke(this);
        }      

        public void Hide()
        {
            _windowTransform.gameObject.SetActive(false);
            OnHiding();
            Hided?.Invoke(this);
        }        

        public void MoveToWorldPoint(Vector3 globalPostition)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(globalPostition);
            _windowTransform.position = screenPoint;
        }

        protected virtual void OnShowing() { }

        protected virtual void OnHiding() { }

        protected virtual void OnDestroy() 
        {
            Destroying?.Invoke(this);
        }
    }
}
