using UnityEngine;

namespace Economics
{
    public class Wallet : MonoBehaviour, IWallet
    {
        [SerializeField] private float _credits;

        public bool TryGetWithdraw(float credits)
        {
            if (_credits - credits < 0)
                return false;

            _credits -= credits;
            return true;
        }

        public void Deposit(float credits)
        {
            _credits += credits;
        }
    }
}
