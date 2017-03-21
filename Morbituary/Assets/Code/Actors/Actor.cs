using Assets.Actors.Enemies;
using Assets.Actors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Actors
{
    public abstract class Actor : MonoBehaviour
    {
        // Properties
        public double MovementSpeed { get; set; }
        public int Health { get; set; }
        public ActorType Type { get; set; }
        public ActorStatus Status { get; set; }


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
