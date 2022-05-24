using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    public sealed class FrameRateCounter : MonoBehaviour
    {
        [SerializeField] private Text m_Text;
        [SerializeField] private float refresh;

        private string _display = "{0} FPS";
        private float _timer;
        private float _avgFramerate;

        private void Update()
        {
            //Change smoothDeltaTime to deltaTime or fixedDeltaTime to see the difference
            float timelapse = Time.smoothDeltaTime;
            _timer = _timer <= 0 ? refresh : _timer -= timelapse;

            if (_timer <= 0)
                _avgFramerate = (int)(1f / timelapse);
            m_Text.text = string.Format(_display, _avgFramerate.ToString());
        }
    }
}
