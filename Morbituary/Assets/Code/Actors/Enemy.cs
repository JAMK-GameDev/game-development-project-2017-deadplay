using Assets.Code.Actors.Enums;
using Assets.Code.Combat;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using System.Collections;
using UnityEngine.AI;
using Assets.Code.Actors.Controller;

namespace Assets.Code.Actors
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : Actor<IAttack>
    // Use this for initialization
    {
        private bool isAttacking;
        public int Damage { get; set; }

        public override bool IsAttacking { get { return isAttacking; } }

        public float timeBetweenAttacks = 0.5f;
        public float timer;
        public bool playerInRange;

        private GameObject PlayerGameObject;
        private Player target;
        private Player Player;
        private Enemy Enem;
        private GameObject[] enemiesArray;
        // Animations

        public GameObject RightSide;
        public GameObject FrontSide;
        public GameObject LeftSide;
        public GameObject BackSide;
        private EnemyMovementController movementController;

        void Awake()
        {
            movementController = new EnemyMovementController(this);

            if (RightSide == null || FrontSide == null || LeftSide == null || BackSide == null) throw new System.Exception("Not all Character Rigs have been initialized in Player");
            // Get enemies to array
            enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
            // TODO: How to implement this?
            foreach (GameObject enemy in enemiesArray)
            {
                Enem = ToEnemy(enemy);
                Enem.Damage = 13;
                Enem.health = Random.Range(50, 120);
            }

            Player Player = Player.ToPlayer(Player.GetPlayer());
            PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        }

        private void AdjustDirection()
        {
            var subObjects = GetComponentsInChildren<Transform>().ToList();
            var subTransform = subObjects.First(obj => obj.name == "Slime");

            transform.eulerAngles = new Vector3(-90, -180, 0);
        }

        void Start()
		{

        }

        protected override void UpdateAnimation(ActorStatus status)
        {
            var animator = GetComponentInChildren<Animator>();
            animator.SetBool("isMoving", IsMoving);
            animator.SetBool("isAttacking", IsAttacking); /*

            var childTrans = GetComponentInChildren<Transform>();
            childTrans.transform.eulerAngles = new Vector3(-transform.eulerAngles.x, -transform.eulerAngles.x, -transform.eulerAngles.z); */
        }

        // Update is called once per frame
        protected void Update()
        {
            // Update Movement
            AdjustDirection();
            movementController.Animate();
            // Update Direction
            Direction = ActorDirectionMethods.ParseDegrees(transform.eulerAngles.y);

            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange)
            {
                Attack(target);
                isAttacking = true;
            }
            else { isAttacking = true; }

            // Enemies follow player
            GetComponent<NavMeshAgent>().destination = Player.GetPlayer().transform.position;
        }

        void OnTriggerEnter(Collider other)
        {
        
            // If the entering collider is the player...
            if (other.gameObject == PlayerGameObject) //does not work
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
            //Debug.Log("Enemy Attack() here, target: " + target);
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
            Destroy(gameObject);
        }

		public static Enemy ToEnemy(GameObject gameObject)
		{
			return gameObject.GetComponentInParent<Enemy>();
		}
    }
}
