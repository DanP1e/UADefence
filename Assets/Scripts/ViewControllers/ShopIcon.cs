using Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace ViewControllers
{
    public class ShopIcon : SelectableObject, IIcon
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _imageComponent;
        [SerializeField] private LayoutElement _layoutElement;
        [SerializeField] private float _selectedSizeShiftInPercents = 20;

        private Vector2 _size;
        private Vector2 _temporarySizeModifierInPercents;

        public Vector2 TemporarySizeModifierInPercents 
        { 
            get => _temporarySizeModifierInPercents;
            set 
            {
                _temporarySizeModifierInPercents = value;
                UpdateSize();
            }
        }

        private void Awake()
        {
            _button.onClick.AddListener(() => { Select(); });
            UpdateSize();
            OnUnselecting();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetBaseSize(Vector2 size)
        {
            _size = size;
            UpdateSize();
        }

        public void SetSprite(Sprite image)
        {
            _imageComponent.sprite = image;
        }

        protected override bool OnSelecting()
        {
            TemporarySizeModifierInPercents = Vector2.zero;

            return true;
        }

        protected override bool OnUnselecting()
        {
            TemporarySizeModifierInPercents
                = -Vector2.one * _selectedSizeShiftInPercents;
            return true;
        }

        private void UpdateSize()
        {
            float y = _size.y + _size.y * (TemporarySizeModifierInPercents.y / 100);
            _layoutElement.preferredHeight = y;
            _layoutElement.minHeight = y;
                
            float x = _size.x + _size.x * (TemporarySizeModifierInPercents.x / 100);
            _layoutElement.preferredWidth = x;
            _layoutElement.minWidth = x;
                
        }
    }
}
