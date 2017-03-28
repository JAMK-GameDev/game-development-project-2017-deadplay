using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Actors;
using Assets.Code.Combat;
using UnityEngine;

namespace Assets.Code.Items
{
	/// <summary>
	/// Carryable weapons which are used bz players to deal damage
	/// </summary>
	public class Weapon : IItem, IAttack
	{
		public BoxCollider Collider { get; set; }
		public int Damage { get; set; }
		public float Range { get; set; }
		public string Name { get; set; }

		public virtual void init()
		{
			Collider = new BoxCollider();
			Collider.size = new Vector3(Range, 2.0f, Range);
			Collider.center = new Vector3(Range / 2, 0, 0);
			var player = Player.GetPlayer();
		}

		public void DealDamage(Actor<IAttack> target)
		{
			if (target == null) throw new ArgumentNullException();

			Debug.Log("DealDamage() here, target is: " + target);
            Debug.Log("Range is: " + Range);
            Debug.Log("Dmg is: " + Damage);
            // dealing the damage of the weapon itself
            target.receiveDamage(this);
        }
        
		public bool IsInRange(Actor<IAttack> target)
		{
            if (target)
                return true;
            return false;
		}

	}
}
