using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class ItemDirector : MonoBehaviour
    {
        private List<IItem> _itemList = new List<IItem>(); 

        void Start()
        {
            PopulateItems();
            AddItemsToUi();
        }

        void Update()
        {
            
        }

        private void PopulateItems()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterface("IItem") != null && !type.IsInterface)
                .Each(item =>
                {
                    var obj = (IItem)Activator.CreateInstance(item);
                    _itemList.Add(obj);
                });
        }

        private void AddItemsToUi()
        {
            
        }
    }
}