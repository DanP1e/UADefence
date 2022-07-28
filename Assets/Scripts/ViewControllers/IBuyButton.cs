using UnityEngine.Events;

namespace ViewControllers
{
    public interface IBuyButton
    {
        public bool Interactable { get; set; }

        public event UnityAction ButtonPressed;

        void SetText(string text);
    }
}
