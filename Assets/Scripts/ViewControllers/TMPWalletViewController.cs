using Effects;
using InspectorAddons;
using TMPro;
using UnityEngine;
using Zenject;

namespace ViewControllers
{
    public class TMPWalletViewController : MonoBehaviour, IWalletViewController
    {
        [SerializeField] private InterfaceComponent<ITimer> _restColorTimerComponent;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private Color _creditsIncreasedColor;
        [SerializeField] private Color _creditsDecreasedColor;

        private Color _defaultColor;
        private ITimer _timer;
        private float _account = 0;

        [Inject]
        public void Construct() 
        {
            _defaultColor = _textMeshProUGUI.color;
            _timer = _restColorTimerComponent.Interface;
            _timer.StopTimer();
            _timer.IsCyclical = false;
            _timer.TimeoutEvent.AddListener(RestColor);
        }
        
        public void ChangeAccountView(float newAccountValue)
        {
            float change = newAccountValue - _account;
            _account = newAccountValue;

            _textMeshProUGUI.text = newAccountValue.ToString("R0");

            if (change < 0)
                SetTextColor(_creditsDecreasedColor);
            else
                SetTextColor(_creditsIncreasedColor);
        }

        private void SetTextColor(Color color)
        {
            _textMeshProUGUI.color = color;
            _timer.StartTimer();
        }

        private void RestColor()
        {
            _textMeshProUGUI.color = _defaultColor;
            _timer.StopTimer();
        }
    }
}
