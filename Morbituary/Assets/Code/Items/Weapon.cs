using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Actors;

namespace Assets.Items
{
    /// <summary>
    /// Carryable weapons which are used bz players to deal damage
    /// </summary>
    public class Weapon : IItem, IAttack
    {
        public int Damage { get; set; }
        public double Range { get; set; }
        public string Name { get; set; }
        
        public void DealDamage(Actor target)
        {
            throw new NotImplementedException();
        }

        public bool IsInRange(Actor target)
        {
            throw new NotImplementedException();
        }
    }
}
