using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Messages;
using Assets.Scripts.Models;
using Assets.Scripts.Upgrades.MinimumWageWorkerUpgrades;
using UnityEngine;
using UnityEngine.UI;
using UnityEventAggregator;

namespace Assets.Scripts.Directors
{
    public class MoneyDirector : MonoBehaviour, IListener<BuyItemMessage>
    {
        public float CachedMoneyPerSecond = PlayerContext.GetMoneyPerSecond();

        public Text MoneyText;

        void Start()
        {
            PlayerContext.OwnedItems = new List<OwnedItems>
            {
                new OwnedItems
                {
                    Item = new MinimumWageWorker(),
                    Amount = 1
                }
            };

            PlayerContext.OwnedUpgrades = new List<IUpgrade>
            {
                new PositiveReinforcement()
            };

            CachedMoneyPerSecond = PlayerContext.GetMoneyPerSecond();

            this.Register<BuyItemMessage>();
        }

        void OnDestory()
        {
            this.UnRegister<BuyItemMessage>();
        }

        void Update()
        {
            PlayerContext.CurrentMoney += CachedMoneyPerSecond;
            MoneyText.text = PlayerContext.CurrentMoney.ToString("C");
        }

        public void Handle(BuyItemMessage message)
        {
            PlayerContext.BuyItem(message.Item);
            CachedMoneyPerSecond = PlayerContext.GetMoneyPerSecond();
        }
    }
}