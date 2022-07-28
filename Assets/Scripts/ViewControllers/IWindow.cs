using UnityEngine;
using UnityEngine.Events;

namespace ViewControllers
{
    public interface IWindow
    {
        event UnityAction<IWindow> Hided;
        event UnityAction<IWindow> Shown;
        event UnityAction<IWindow> Destroying;

        void Show();

        void Hide();

        void MoveToWorldPoint(Vector3 globalPostition);      
    }
}