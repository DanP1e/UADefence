using UnityEngine.Events;
using Utilities;

namespace ViewControllers
{
    public interface IWindowsHandler : IContainer<IWindow>
    {
        event UnityAction<IWindow> WindowHided;
        event UnityAction<IWindow> WindowShown;
        event UnityAction<IWindow> WindowDestroying;

        public void AddWindow(IWindow window);
    }
}
