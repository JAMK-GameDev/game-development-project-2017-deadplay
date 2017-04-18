using Assets.Code.Actors.Enemies;
using Assets.Code.Actors.Enums;
using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Actors
{
	/// <summary>
	/// Base actor class for the most fundamental functions, including movement and attack.
	/// Enemies and players inherit from this class
	/// </summary>
	public abstract class Actor<A> : MonoBehaviour where A : IAttack
	{
		// Fields
		public double facingDegree;
        protected int health;
        protected bool hasDied = false;

        // Properties
        public ActorDirection Direction;
        public bool LooksUp { get { return Direction == ActorDirection.Up; } }
        public bool LooksDown { get { return Direction == ActorDirection.Down; } }
        public bool LooksRight { get { return Direction == ActorDirection.Right; } }
        public bool LooksLeft { get { return Direction == ActorDirection.Left; } }

        public abstract bool IsAttacking { get; }
        public virtual bool IsBlocking { get { return false; } }
        public bool IsDead { get { return health <= 0; } }

        public bool IsMoving { get { return MovementSpeed > 0.1f; } }
		public double MovementSpeed { get; set; }
		public ActorType Type { get; set; }
		public ActorStatus Status { get; set; }
		public List<A> Attacks { get; set; }
        public int Health
        {
            get { return health; }
            set { health = value;  }
        }

        /// <summary>
        /// Returns the facing direction of the actor in degrees.
        /// Only values between 0 and 360 can be assigned to this.
        /// </summary>
        public double FacingDegree
		{
			get { return facingDegree; }
			set
			{
				// Perform check, so only ever valid values are assigned as facing degrees. This are values between 0 and 360
				if (!ActorDirection.IsValidDegree(value)) throw new ArgumentException(value + " is not a valid degree. It must be between 0 and 360!");
				facingDegree = value;
			}
		}

		private  ActorDirection ActorDirection
		{
			get { return ActorDirection.ParseDegrees(FacingDegree); }
			set { FacingDegree = value.GetDegrees(); }
		}

		// Use this for initialization
		void Start()
		{
            Direction = ActorDirection.Down;
        }

		// Update is called once per frame
		protected void Update()
        {
            UpdateAnimation(Status);
		}

        protected abstract void UpdateAnimation(ActorStatus status);

        public void receiveDamage(IAttack attack)
        {
            OnDamaged(attack);
            health -= attack.Damage;

            if(Health <= 0)
            {
                OnDeath();
            }

        }

        protected abstract void OnDeath();
        protected virtual void OnDamaged(IAttack attack) { }
    }
}
