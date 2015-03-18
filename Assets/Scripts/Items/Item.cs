using Assets.Scripts.Interfaces;
using Assets.Scripts.Messages;
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

        public void Setup(IItem item)
        {
            _item = item;

            ItemName.text = item.Name;
            ItemPrice.text = item.Price.ToString("C");
            ItemMps.text = item.MoneyPerSecond.ToString("C");
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