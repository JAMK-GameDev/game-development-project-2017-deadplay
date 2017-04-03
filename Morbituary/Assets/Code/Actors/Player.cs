using Assets.Code.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Actors
{
    public class Player : Actor<Weapon>
    {
        public readonly static Inventory Inventory = new Inventory();
        


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
	}
}