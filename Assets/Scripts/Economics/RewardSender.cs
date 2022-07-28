using System;
using UnityEngine;
using Zenject;

namespace Economics
{
    public class RewardSender : MonoBehaviour
    {
        [SerializeField] private float _rewardInCredits;

        private IWallet _wallet;

        [Inject]
        public void Construct(IWallet wallet) 
        {
            _wallet = wallet;
        }

        public void SendReward() 
        {
            _wallet.Deposit(_rewardInCredits);
        }
    }
}
