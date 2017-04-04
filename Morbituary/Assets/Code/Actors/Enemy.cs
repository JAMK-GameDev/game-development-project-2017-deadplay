﻿using Assets.Code.Actors.Enums;
using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using System.Collections;

namespace Assets.Code.Actors
{
	class Enemy : Actor<IAttack>
	// Use this for initialization
	{
        public int Damage { get; set; }
        public float timeBetweenAttacks = 0.5f;
        float timer;
        bool playerInRange;
        
        GameObject PlayerGameObject;
        Player target;
        Player Player;
        Enemy Enem;
        GameObject[] enemiesArray;

        void Awake()
        {

            // Get enemies to array
            enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
            // TODO: How to implement this?
            foreach (GameObject enemy in enemiesArray)
            {
                Enem = ToEnemy(enemy);
                Enem.Damage = 3;
                Enem.health = UnityEngine.Random.Range(50, 120);
            }

            Player Player = Player.ToPlayer(Player.GetPlayer());
            PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        }

        void Start()
		{

            
        }

		// Update is called once per frame
		void Update()
		{

            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange)
            {
                Attack(target);
            }
            
        }

        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == PlayerGameObject)
            {
                // ... the player is in range.
                playerInRange = true;
                target = Player.ToPlayer(PlayerGameObject);
            }
        }


        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == PlayerGameObject)
            {
                // ... the player is no longer in range.
                playerInRange = false;
                target = null;
            }
        }

        protected void Attack(Player target)
        {
            Debug.Log("Enemy Attack() here, target: " + target);
            // Reset the timer.
            timer = 0f;
            // Deal damage
            target.receiveDamage(Damage);
        }

        protected override void OnDeath()
        {
            Status = ActorStatus.Dead;
            Debug.Log(this + " is now dead");
            // TODO: this should be replaced by death animation
            Destroy(this.gameObject);

        }

		public static Enemy ToEnemy(GameObject gameObject)
		{
			return gameObject.GetComponentInParent<Enemy>();
		}
    }
}
