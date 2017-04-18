using Assets.Code.Combat;
using Assets.Code.Items;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Code.Actors.Enums;
using UnityEngine.UI;

namespace Assets.Code.Actors
{
    public class Player : Actor<Weapon>
    {
        public readonly static Inventory Inventory = new Inventory();
		protected bool invincible;
        public Slider healthSlider;
        public float refillSpeed;
        public bool refilling;
        public override bool IsAttacking { get { return Input.GetMouseButton(0); } }
        public override bool IsBlocking { get { return !IsAttacking && Input.GetMouseButton(1); } }

        // Use this for initialization
        void Start()
		{
            // TODO do we need to specify which slider?
            healthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
            refillSpeed = 0.01f;
		}

        private void UpdateDirection()
        {
            if (Input.GetKey(KeyCode.D)) Direction = ActorDirection.Right;
            else if (Input.GetKey(KeyCode.W)) Direction = ActorDirection.Up;
            else if (Input.GetKey(KeyCode.A)) Direction = ActorDirection.Left;
            else if (Input.GetKey(KeyCode.S)) Direction = ActorDirection.Down;
        }

        private void UpdateStatus()
        {


            if (health <= 0) Status = ActorStatus.Dead;
            else if (IsAttacking) Status = ActorStatus.Attacking;
            else if (IsBlocking) Status = ActorStatus.Blocking;
            else if (IsMoving) Status = ActorStatus.Walking;
            else Status = ActorStatus.Idle;
        }
		// Update is called once per frame
		void Update()
		{
            UpdateStatus();
            UpdateDirection();
            if (Status != ActorStatus.Dead)
            {
                base.Update();

                // Draw healt orb based on health
                generateHealth();

            }

        }

        protected override void UpdateAnimation(ActorStatus status)
        {
            var animator = GetComponentInChildren<Animator>();
            animator.SetBool("isAttacking", IsAttacking);
            animator.SetBool("isMoving", IsMoving);

            if (IsDead) { animator.SetTrigger("isDead"); }
            Debug.Log("Is Attacking? " + IsAttacking + ", IsBlocking? " + IsBlocking);
        }

        protected override void OnDeath()
        {
            Debug.Log("You Died..");
            Status = ActorStatus.Dead;
            // TODO add animation
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
			if (!invincible && Status != Enums.ActorStatus.Blocking)
			{
				invincible = true;
				Debug.Log("Player receiving damage: " + damage + ", Health is: " + health);
				health -= damage;

                // Reduce slider
                healthSlider.value = healthSlider.value - (damage * 0.01f);

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

        void generateHealth()
        {
            
            if (healthSlider.value < 1)
            {
                // Draw orb and generate health until slider is full and health is 100
                healthSlider.value = healthSlider.value < 1 ? healthSlider.value + (refillSpeed * Time.deltaTime) : healthSlider.value;
                Health =  Mathf.FloorToInt(healthSlider.value * 100f);
            }  
            
        }
	}
}