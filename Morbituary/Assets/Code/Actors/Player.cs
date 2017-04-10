﻿using Assets.Code.Combat;
using Assets.Code.Items;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Code.Actors
{
    public class Player : Actor<Weapon>
    {
        public readonly static Inventory Inventory = new Inventory();
		protected bool invincible;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

        protected override void OnDeath()
        {
            Debug.Log("You Died..");
            // TODO
        }

		public static GameObject GetPlayer()
		{
			return GameObject.FindGameObjectWithTag("Player");
		}

        public static Player ToPlayer(GameObject gameObject)
        {
            return gameObject.GetComponentInParent<Player>();
        }

        internal void receiveDamage(int damage)
        {
			// Prevents too fast deaths
			if (!invincible)
			{
				invincible = true;
				Debug.Log("Player receiving damage: " + damage + ", Health is: " + health);
				health -= damage;

				if (Health <= 0)
				{
					OnDeath();
				}
				Invoke("resetInvulnerability", 2);
        	}
    	}

		void resetInvulnerability()
		{
			invincible = false;
		}
	}
}