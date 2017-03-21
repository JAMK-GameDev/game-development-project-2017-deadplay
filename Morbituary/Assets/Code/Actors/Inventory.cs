using Assets.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Actors
{
    class Inventory
    {
        private List<IItem> Items { get; set; }

        bool hasKey()
        {
            return Items.Any(item => item.Name == "Key");
        }

    }
}
