using Assets.Actors.Enemies;
using Assets.Actors.Enums;
using Assets.Code.Actors.Enums;
using Assets.Code.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Actors
{
    /// <summary>
    /// Base actor class for the most fundamental functions, including movement and attack.
    /// Enemies and players inherit from this class
    /// </summary>
    public abstract class Actor<A> : MonoBehaviour where A : IAttack
    {
        // Fields
        public double facingDegree;

        // Properties
        public double MovementSpeed { get; set; }
        public int Health { get; set; }
        public ActorType Type { get; set; }
        public ActorStatus Status { get; set; }
        public List<A> Attacks { get; set; }

        /// <summary>
        /// Returns the facing direction of the actor in degrees.
        /// Only values between 0 and 360 can be assigned to this.
        /// </summary>
        public double FacingDegree {
            get { return facingDegree; }
            set
            {
                // Perform check, so only ever valid values are assigned as facing degrees. This are values between 0 and 360
                if (!ActorDirection.IsValidDegree(value)) throw new ArgumentException(value + " is not a valid degree. It must be between 0 and 360!");
                facingDegree = value;
            }
        }

        public ActorDirection ActorDirection
        {
            get { return ActorDirection.ParseDegrees(FacingDegree); }
            set { FacingDegree = value.GetDegrees(); }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
