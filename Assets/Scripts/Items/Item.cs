using Assets.Scripts.Interfaces;
using Assets.Scripts.Messages;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using UnityEventAggregator;

namespace Assets.Scripts.Items
{
    public class Item : MonoBehaviour
    {
        private IItem _item { get; set; }

        public Text ItemName;
        public Text ItemPrice;
        public Text ItemMps;
        public Text ItemAmount;

        public void Setup(IItem item)
        {
            _item = item;

            ItemName.text = item.Name;
            ItemPrice.text = item.Price.ToString("C");
        }

        void Update()
        {
            var ownedItem = PlayerContext.GetItem(_item);
            if (ownedItem != null)
            {
                ItemMps.text = PlayerContext.GetMoneyPerSecondForItem(ownedItem).ToString("C");
                ItemAmount.text = ownedItem.Amount.ToString();
            }
        }

        public void Buy()
        {
            EventAggregator.SendMessage(new BuyItemMessage
            {
                Item = _item
            });
        }
    }
}