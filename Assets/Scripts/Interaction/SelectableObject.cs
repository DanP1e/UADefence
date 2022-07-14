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

            bool result = OnSelecting();

            if (!previousState)
                Selected.Invoke(this);

            return result;
        }

        public bool Unselect()
        {
            bool previousState = _isSelected;
            _isSelected = false;

            bool result = OnUnselecting();

            if (previousState)
                Unselected.Invoke(this);
             
            return result;
        }

        protected abstract bool OnSelecting();

        protected abstract bool OnUnselecting();
       
    }
}
