namespace Economics
{
    public interface IWallet
    {
        void Deposit(float credits);
        bool TryGetWithdraw(float credits);
    }
}