using System;
using UnityEngine;
using UnityEngine.Events;

namespace Economics
{
    public class Wallet : MonoBehaviour, IWallet
    {
        [SerializeField] private float _account;

        public event UnityAction AccountChanged;

        public float Credits { get => _account; }

        public bool TryGetWithdraw(float credits)
        {
            if (credits <= 0)
                throw new ArgumentException( $"\"{nameof(credits)}\" " +
                    $"variable should be greater then 0");

            if (_account - credits < 0)
                return false;

            _account -= credits;
            AccountChanged?.Invoke();
            return true;
        }

        public void Deposit(float credits)
        {
            if (credits <= 0)
                throw new ArgumentException($"\"{nameof(credits)}\" " +
                    $"variable should be greater then 0");

            _account += credits;
            AccountChanged?.Invoke();
        }
    }
}
