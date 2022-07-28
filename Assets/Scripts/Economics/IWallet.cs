using UnityEngine.Events;

namespace Economics
{
    public interface IWallet
    {
        event UnityAction AccountChanged;

        float Credits { get; }

        void Deposit(float credits);
        bool TryGetWithdraw(float credits);
    }
}