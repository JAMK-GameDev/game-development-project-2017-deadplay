﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code.Combat;
using Assets.Code.Items;
using Assets.Code.Actors;

public class playerController : MonoBehaviour
{

	KeyCode sb = KeyCode.Space;
	Weapon wp = new Weapon();
    GameObject sword1;
    BoxCollider bx;
    GameObject[] enemiesArray;
	bool enemyInRange;
	Enemy target;

	void Awake()
	{
		// TODO: How to initialize new weapon? Active weapon if more than 1?
		wp.Name = "Shitty sword";
		wp.Damage = 10;
		wp.Range = 3.1f;

        // Change weapon collider size based on weapon range, done for Players child object "Sword1"
        // TODO: needs better implementation
        sword1 = GameObject.Find("Sword1");
        BoxCollider boxCollider = sword1.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = new Vector3(wp.Range, 1.0f, wp.Range);
            boxCollider.center = new Vector3(2.0f, 0f, 0f);
        }
        // Get enemies to array
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

	}

	// Use this for initialization
	void Start()
	{
           
	}
    
	// Set states if in range
	void OnTriggerEnter(Collider other)
	{
		foreach (GameObject en in enemiesArray)
		{
			if (other.gameObject == en)
			{
			    //enemyInRange = true;
				//target = other.gameObject;
				target = Enemy.ToEnemy(en);
                wp.IsInRange(target);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		foreach (GameObject en in enemiesArray)
		{
			if (other.gameObject == en)
			{
                //enemyInRange = false;
				target = null;
                wp.IsInRange(target);
            }
		}
	}

	// Update is called once per frame
	void Update()
	{
		// If pressed Spacebar (Attack input key)
		if (Input.GetKeyDown(sb))
		{
            if (wp.IsInRange(target))
            {
                Debug.Log("In range, calling DealDamage()");
                //target.receiveDamage(wp);
                wp.DealDamage(target);
            }
            
		}

	}
}
