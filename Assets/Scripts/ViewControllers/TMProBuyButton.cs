using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ViewControllers
{
    public class TMProBuyButton : MonoBehaviour, IBuyButton
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public bool Interactable 
        { 
            get => _button.interactable; 
            set => _button.interactable = value; 
        }

        public event UnityAction ButtonPressed;

        protected void Awake()
        {
            _button.onClick.AddListener(() => { ButtonPressed?.Invoke(); });
        }

        public void SetText(string text)
        {
            _textMeshPro.text = text;
        }
    }
}
