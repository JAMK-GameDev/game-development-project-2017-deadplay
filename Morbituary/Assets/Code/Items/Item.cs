using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Items
{
    public interface IItem : IDropable
    {
        string Name { get; set; }
    }
}
