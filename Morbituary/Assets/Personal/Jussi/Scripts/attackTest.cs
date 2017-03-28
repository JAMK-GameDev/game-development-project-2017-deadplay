using UnityEngine;

using Assets.Code.Items;
using Assets.Code.Actors;

public class attackTest : MonoBehaviour
{

	KeyCode sb = KeyCode.Space;
	Weapon wp = new Weapon();

	BoxCollider enemyCollider;
	GameObject player;
	GameObject[] enemies;
	bool enemyInRange;
	Enemy target;

	void Awake()
	{
		// TODO: How to initialize new weapon? Active weapon if more than 1?
		wp.Name = "Shitty sword";
		wp.Damage = 10;
		wp.Range = 12.1f;

		// TODO: Is there better way to do this? Direction?
		// TODO: Also, case for multiple enemies?
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
		//enemy = GameObject.FindGameObjectWithTag ("Enemy");

		BoxCollider b = player.GetComponent<BoxCollider>();

		//  weapon range
		if (b != null)
		{
			b.size = new Vector3(wp.Range, 2.0f, wp.Range);
		}
		Debug.Log(player); // PlayerTest, ok!
	}

	// Use this for initialization
	void Start()
	{

	}

	static int i = 0;

	// Set states if in range
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter: " + i++);

		foreach (GameObject en in enemies)
		{

			var tmp = other.gameObject.GetComponentsInParent<Enemy>();

			//Debug.Log (en); EnemyTest, EnemyTest (1)

			if (other.gameObject == en)
			{

				Debug.Log(other.gameObject);

				enemyInRange = true;
				//target = other.gameObject;
				target = Enemy.ToEnemy(en);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		foreach (GameObject en in enemies)
		{
			if (other.gameObject == en)
			{
				enemyInRange = false;
				target = null;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

		// If pressed Spacebar (Attack input key)
		if (Input.GetKeyDown(sb))
		{

			//Debug.Log ("hit pressed");
			// class Weapon Attack() method
			// wp.Attack(enemyInRange, target);
		}
	}
}
