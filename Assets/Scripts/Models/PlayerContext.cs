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

        public static List<OwnedItem> OwnedItems = new List<OwnedItem>();
        public static List<IUpgrade> OwnedUpgrades = new List<IUpgrade>();

        #region MoneyPerSecond

        public static float GetMoneyPerSecond()
        {
            return OwnedItems.Aggregate(0f, (accumulator, item) => GetMoneyPerSecondForItem(item)); ;
        }

        public static OwnedItem GetItem(IItem item)
        {
            return OwnedItems.FirstOrDefault(x => x.Item.Name == item.Name);
        }

        public static float GetMoneyPerSecondForItem(OwnedItem item)
        {
            return item.Item.MoneyPerSecond * item.Amount;
        }

        public static float GetMoneyPerSecondForItem(IItem item)
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
            var ownedItem = GetItem(item);

            if (ownedItem != null)
            {
                ownedItem.Amount++;
            }
        }
    }
}