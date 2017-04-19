﻿using Assets.Code.Combat;
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
            healthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
            refillSpeed = 0.01f;
		}

        private void UpdateDirection()
        {
            if (!IsDead)
            {
                if (Input.GetKey(KeyCode.W)) Direction = ActorDirection.Up;
                else if (Input.GetKey(KeyCode.D)) Direction = ActorDirection.Right;
                else if (Input.GetKey(KeyCode.A)) Direction = ActorDirection.Left;
                else if (Input.GetKey(KeyCode.S)) Direction = ActorDirection.Down;

                // Debug Only
                if (Input.GetKey(KeyCode.X)) receiveDamage(100);
            }
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
            if (!IsDead)
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
        }

        protected override void UpdateAnimation(ActorStatus status)
        {
            var animator = GetComponentInChildren<Animator>();
            animator.SetBool("isAttacking", IsAttacking);
            animator.SetBool("isMoving", IsMoving);
        }

        protected override void OnDeath()
        {
            Debug.Log("You Died..");
            Status = ActorStatus.Dead;

            if (!hasDied)
            { // hasDied is necessary, so it is only triggered once
                var animator = GetComponentInChildren<Animator>();
                animator.SetTrigger("isDead");
                hasDied = true;
            }
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
            if (!IsDead)
            {
                Debug.Log("Receive damg");
                // Prevents too fast deaths, allows blocking
                if (!invincible && Status != ActorStatus.Blocking)
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
<<<<<<< HEAD
				// Debug.Log("generateHealth, healthsliderValue: " + healthSlider.value + " Healt: " + Health);
=======
>>>>>>> 014f9eae8754d26564581768273ab5740ba77b47
            }
        }
	}
}