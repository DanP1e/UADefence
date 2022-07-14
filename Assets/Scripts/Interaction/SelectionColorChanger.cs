using Effects;
using InspectorAddons;
using UnityEngine;

namespace Interaction
{
    public sealed class SelectionColorChanger : SelectableObject
    {
        [SerializeField] private Color _selectionColor;
        [SerializeField] private InterfaceComponent<IShaderAdapter> _shaderAdapterComponent;       

        private Color _originalColor;
        private IShaderAdapter _shaderAdapter;   

        private void Awake()
        {
            _shaderAdapter = _shaderAdapterComponent.Interface;
            _originalColor = _shaderAdapter.BaseColor;
        }

        protected override bool OnSelected()
        {
            _shaderAdapter.BaseColor = _selectionColor;
            return true;
        }
        protected override bool OnUnselected()
        {
            _shaderAdapter.BaseColor = _originalColor;
            return true;
        }
    }
}
