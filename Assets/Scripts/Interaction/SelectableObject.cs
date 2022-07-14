using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public abstract class SelectableObject : MonoBehaviour, ISelectable
    {
        [SerializeField] private UnityEvent<ISelectable> _selected;
        [SerializeField] private UnityEvent<ISelectable> _unselected;

        private bool _isSelected = false;

        public UnityEvent<ISelectable> Selected => _selected;
        public UnityEvent<ISelectable> Unselected => _unselected;

        public bool IsSelected()
            => _isSelected;

        public bool Select()
        {
            bool previousState = _isSelected;
            _isSelected = true;

            if (!previousState)
                Selected.Invoke(this);

            return OnSelected();
        }
        public bool Unselect()
        {
            bool previousState = _isSelected;
            _isSelected = false;

            if (previousState)
                Unselected.Invoke(this);
             
            return OnSelected();
        }
        protected abstract bool OnSelected();
        protected abstract bool OnUnselected();
       
    }
}
