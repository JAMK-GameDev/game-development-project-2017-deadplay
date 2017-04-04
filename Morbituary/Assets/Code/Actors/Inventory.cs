using Assets.Code.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Actors
{
    public class Inventory
    {
        public List<IItem> items;
        private int keyCount;

        public bool HasKey
        {
            get { return keyCount > 0; }
        }

        public int GetKeyCount()
        {
            return keyCount;
        }

        public void AddKey()
        {
            keyCount++;
        }

        public bool UseKey()
        {
            if (HasKey)
            {
                keyCount--;
                return true;
            }

            return false;
        }
        
    }
}
