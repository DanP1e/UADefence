using System;
using UnityEngine;

namespace Utilities
{
    public sealed class FrameRateController : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate;

        private void OnEnable()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
        private void OnDisable()
        {
            Application.targetFrameRate = 0;
        }
    }
}
