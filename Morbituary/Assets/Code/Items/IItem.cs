using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Items
{
    /// <summary>
    /// Interface for all items that can be carried in the inventory of the player
    /// </summary>
    public interface IItem : IDropable
    {
        string Name { get; set; }
    }
}
