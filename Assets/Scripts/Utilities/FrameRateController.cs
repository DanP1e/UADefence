using System;
using UnityEngine;

namespace Utilities
{
    public sealed class FrameRateController : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate;

        private void Awake()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}
