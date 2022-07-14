using UnityEngine.Events;

namespace Interaction
{
    public interface ISelectable
    {
        UnityEvent<ISelectable> Selected { get; }
        UnityEvent<ISelectable> Unselected { get; }

        bool IsSelected();
        bool Select();
        bool Unselect();
    }
}
