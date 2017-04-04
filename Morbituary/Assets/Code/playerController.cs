using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code.Combat;
using Assets.Code.Items;
using Assets.Code.Actors;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    Weapon wp = new Weapon();
    GameObject W1, W2;
    GameObject CurrentWeapon;
    BoxCollider bx;
	bool enemyInRange;
    bool canHit;
    private float lastAttack;
    Enemy target;
    Enemy enem;
    Image Slot1Image;
    Image Slot2Image;

	void Awake()
	{
        // Get UI slot images (red borders ATM)
        Slot1Image = GameObject.FindGameObjectWithTag("ActiveSlot1").GetComponent<Image>();
        Slot2Image = GameObject.FindGameObjectWithTag("ActiveSlot2").GetComponent<Image>();

        // Get weapon object references from scene
        W1 = GameObject.FindGameObjectWithTag("Weapon1");
        W2 = GameObject.FindGameObjectWithTag("Weapon2");
	}

	// Use this for initialization
	void Start()
	{
        W1.gameObject.SetActive(true);
        W2.gameObject.SetActive(true);

        Slot1Image.gameObject.SetActive(true);
        Slot2Image.gameObject.SetActive(true);
    }

    void SetWeaponStats(string targetGameObject, string name, int dmg, float range, float freq)
    {
        
        wp.Name = name;
        wp.Damage = dmg;
        wp.Range = range;
        wp.Frequency = freq;
        
        CurrentWeapon = GameObject.Find(targetGameObject);
        BoxCollider boxCollider = CurrentWeapon.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = new Vector3(range, 1.0f, range);
            boxCollider.center = new Vector3(2.0f, 0f, 0f);
        }
        
    }
    
	// Set states if in range
	void OnTriggerEnter(Collider other)
	{
        Debug.Log("on trigger enter");
		if (other.GetComponent<Collider>().tag == "Enemy")
		{
			target = Enemy.ToEnemy(other.gameObject);
		}
		
	}

	void OnTriggerExit(Collider other)
	{
        Debug.Log("on trigger exit");
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
			target = null;
        }
		
	}

	// Update is called once per frame
	void Update()
	{
    
        // Attack input with freq, not allowing while blocking, must be in range
        if (Time.time > wp.Frequency + lastAttack && Input.GetMouseButtonDown(0) && canHit && wp.IsInRange(target))
		{
            Debug.Log("In range, calling DealDamage()");
            wp.DealDamage(target);

            lastAttack = Time.time;
		}
        // Block input key
        if (Input.GetMouseButton(1))
        {
            canHit = false;
            Debug.Log("Blocking");
        } else {
            //released 
            canHit = true;
        }

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("1 pressed");

            resetWeapons();
            resetInventoryActiveSlot();
            W1.SetActive(true);
            Slot1Image.gameObject.SetActive(true);

            SetWeaponStats("Weapon1", "Dagger", 10, 2.1f, 0.4f);
        }
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("2 pressed");

            resetWeapons();
            resetInventoryActiveSlot();
            W2.SetActive(true);
            Slot2Image.gameObject.SetActive(true);

            SetWeaponStats("Weapon2", "Longsword", 33, 4.3f, 2.4f);
        }
    }

    void resetWeapons()
    {
        W1.gameObject.SetActive(false);
        W2.gameObject.SetActive(false);
    }

    void resetInventoryActiveSlot()
    {
        Slot1Image.gameObject.SetActive(false);
        Slot2Image.gameObject.SetActive(false);
    }
}
