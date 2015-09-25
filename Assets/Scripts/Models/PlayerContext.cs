using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    [Serializable]
    public static class PlayerContext
    {
        public static float CurrentMoney;
        public static float TotalMoneyEarned;

        public static List<OwnedItems> OwnedItems = new List<OwnedItems>();
        public static List<IUpgrade> OwnedUpgrades = new List<IUpgrade>();

        #region MoneyPerSecond

        public static float GetMoneyPerSecond()
        {
            return OwnedItems.Aggregate(0f, (accumulator, item) => GetMoneyPerSecondForItem(item)); ;
        }

        private static float GetMoneyPerSecondForItem(OwnedItems item)
        {
            return item.Item.MoneyPerSecond * item.Amount;
        }

        private static float GetMoneyPerSecondForItem(IItem item)
        {
            var baseMps = item.MoneyPerSecond;
            var upgradesForItem = OwnedUpgrades.Where(x => x.Item == item).ToList();
            var mpsIncrease = upgradesForItem
                .Where(x => x.UpgradeType == UpgradeType.MoneyPerSecond)
                .Aggregate(0f, (accumulator, upgrade) => upgrade.UpgradeAmount);

            return baseMps + mpsIncrease;
        }

        #endregion

        public static void BuyItem(IItem item)
        {
            CurrentMoney -= item.Price;
            var ownedItem = OwnedItems.FirstOrDefault(x => x.Item.Name == item.Name);

            if (ownedItem != null)
            {
                ownedItem.Amount++;
            }
        }
    }
}