using Assets.Code.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Actors
{
	public class Player : Actor<Weapon>
	{
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public static GameObject GetPlayer()
		{
			return GameObject.FindGameObjectWithTag("Player");
		}
	}
}