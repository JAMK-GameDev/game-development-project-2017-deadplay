using Assets.Code.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Combat
{
    public interface IAttack
    {
		float Range { get; }
        int Damage { get; }
        // TODO: Attack frequency. We might want to use something like Unity.Time for this.
        // This requires some more research

        /// <summary>
        /// Deal damage to an actor
        /// </summary>
        /// <param name="target"></param>
        //void DealDamage(Actor target);
        
        /// <summary>
        /// Checks whether the desired target is in attacking range
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        //bool IsInRange(Actor target);
    }
}
