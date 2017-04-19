using Assets.Code.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Actors.Controller
{
    /// <summary>
    /// Controls the Animators, according to the movement of the Enemy
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovementController
    {
        private Enemy Enemy;
        private GameObject RightSide { get { return Enemy.RightSide; } }
        private GameObject FrontSide { get { return Enemy.FrontSide; } }
        private GameObject LeftSide { get { return Enemy.LeftSide; } }
        private GameObject BackSide { get { return Enemy.BackSide; } }
        private Vector3 prevPosition;

        public EnemyMovementController(Enemy enemy)
        {
            Enemy = enemy;
        }

        void Awake()
        {
            // Set all Character rigs to false. 
            // They need to be enabled on game startupm, otherwise unity has issues with activating them.
            ResetCharacterRigs();
        }

        private void ResetCharacterRigs()
        {
            RightSide.SetActive(false);
            FrontSide.SetActive(false);
            LeftSide.SetActive(false);
            BackSide.SetActive(false);
        }

        private float GetMovementSpeed()
        {
            float speed = 0;
            var position = Enemy.transform.position;
            if (prevPosition != null)
            {
                // Debug.Log("Enemy pos: {" + position.x + ", " + position.y + ", " + position.z + " }");
                speed = (float) Math.Sqrt((Math.Abs(position.x) + Math.Abs(position.z)));
                Debug.Log("Enemy speed: " + speed);
            }

            prevPosition = position;

            return speed;
        }

        public void Animate()
        {
            // Update Speed
            Enemy.MovementSpeed = GetMovementSpeed();
            ResetCharacterRigs();

            if (Enemy.LooksRight)
            {
                RightSide.SetActive(true);
            }
            else if (Enemy.LooksUp)
            {
                BackSide.SetActive(true);
            }
            else if (Enemy.LooksLeft)
            {
                LeftSide.SetActive(true);
            }
            else if (Enemy.LooksDown)
            {
                FrontSide.SetActive(true);
            }
        }
    }
}
