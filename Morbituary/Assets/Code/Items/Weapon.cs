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


            var key = new Key();
		}

		public virtual void Attack(bool isInRange, Actor<IAttack> target)
		{
			Debug.Log("Attack() here");
			Debug.Log("is in range: " + isInRange);
			Debug.Log("target is: " + target);
			// If in range
			if (isInRange)
			{
				Debug.Log("Attack() in range, deling damage");
				// Do damage
				DealDamage(Damage, target);
			}
		}

		public void DealDamage(int amount, Actor<IAttack> target)
		{
			if (target == null) throw new ArgumentNullException();

			Debug.Log("DealDamage() here, amount, target: ");
			Debug.Log(amount);
			Debug.Log(target);
			target.Health -= amount;

		}


		public void DealDamage(Actor<IAttack> target)
		{
			throw new NotImplementedException();
		}

		public bool IsInRange(Actor<IAttack> target)
		{
			throw new NotImplementedException();
		}

	}
}
