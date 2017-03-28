using Assets.Code.Actors.Enums;
using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Actors
{
	class Enemy : Actor<IAttack>
	// Use this for initialization
	{
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

        protected override void OnDeath()
        {
            Status = ActorStatus.Dead;
            Debug.Log(this + " is now dead");
        }

		public static Enemy ToEnemy(GameObject gameObject)
		{
			return gameObject.GetComponentInParent<Enemy>();
		}
    }
}
