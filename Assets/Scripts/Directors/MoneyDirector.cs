using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Models;
using Assets.Scripts.Upgrades.MinimumWageWorkerUpgrades;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Directors
{
    public class MoneyDirector : MonoBehaviour
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
        }

        void Update()
        {
            PlayerContext.CurrentMoney += CachedMoneyPerSecond;
            MoneyText.text = PlayerContext.CurrentMoney.ToString("C");
        }
    }
}