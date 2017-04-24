using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code.Combat;
using Assets.Code.Items;
using Assets.Code.Actors;
using UnityEngine.UI;
using Assets.Code.Actors.Enums;
using Assets.Code.Actors.Controller;

public class playerController : MonoBehaviour
{
    GameObject PlayerGameObject;
    Weapon wp = new Weapon();
    GameObject W1, W2, W3;
    GameObject CurrentWeapon;
    BoxCollider bx;
	bool enemyInRange;
    bool canHit;
    private float lastAttack;
    Enemy target;
    Enemy enem;
    Image Slot1Image, Slot2Image, Slot3Image;
    private Player Player {  get { return Player.ToPlayer(Player.GetPlayer()); } }

    void Awake()
    {
        // Get UI slot images
        Slot1Image = GameObject.FindGameObjectWithTag("ActiveSlot1").GetComponent<Image>();
        Slot2Image = GameObject.FindGameObjectWithTag("ActiveSlot2").GetComponent<Image>();
        Slot3Image = GameObject.FindGameObjectWithTag("ActiveSlot3").GetComponent<Image>();

        // Get weapon object references from scene
        W1 = GameObject.FindGameObjectWithTag("Weapon1");
        W2 = GameObject.FindGameObjectWithTag("Weapon2");
        W3 = GameObject.FindGameObjectWithTag("Weapon3");
    }

	// Use this for initialization
	void Start()
	{
        resetWeapons();
        resetInventoryActiveSlot();
        W1.SetActive(true);
        Slot1Image.gameObject.SetActive(true);

        // Initialize player
        Player Player = Player.ToPlayer(Player.GetPlayer());
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        Player.Health = 100;
    }

    void SetWeaponStats(string targetGameObject, string weaponName, int dmg, float range, float freq)
    {
        
        wp.Name = weaponName;
        wp.Damage = dmg;
        wp.Range = range;
        wp.Frequency = freq;
        
        CurrentWeapon = GameObject.Find(targetGameObject);
        BoxCollider boxCollider = CurrentWeapon.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = new Vector3(range, 1.0f, range);
            boxCollider.center = new Vector3(0f, 0f, 0f);
        }
        
    }
    
	// Set states if in range
	void OnTriggerEnter(Collider other)
	{
        //Debug.Log("on trigger enter");
		if (other.GetComponent<Collider>().tag == "Enemy")
		{
            //Debug.Log("target set");
			target = Enemy.ToEnemy(other.gameObject);
		}
		
	}

	void OnTriggerExit(Collider other)
	{
        //Debug.Log("on trigger exit");
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            //Debug.Log("target null");
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
            // Debug.Log("Blocking");

        } else {
            //released 
            canHit = true;
        }

        var controller = WeaponSoundController.Instance;
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("1 pressed");

            Player.EquippedWeaponNumber = 1;
            resetWeapons();
            resetInventoryActiveSlot();
            W1.SetActive(true);
            Slot1Image.gameObject.SetActive(true);
            controller.PlayWeapon1Sound();

            SetWeaponStats("Weapon1", "Dagger", 10, 2.1f, 0.4f);
        }
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("2 pressed");

            Player.EquippedWeaponNumber = 2;
            resetWeapons();
            resetInventoryActiveSlot();
            W2.SetActive(true);
            Slot2Image.gameObject.SetActive(true);
            controller.PlayWeapon2Sound();

            SetWeaponStats("Weapon2", "Longsword", 33, 4.3f, 2.4f);
        }
        if (Input.GetKeyDown("3"))
        {
            Debug.Log("3 pressed");

            Player.EquippedWeaponNumber = 3;
            resetWeapons();
            resetInventoryActiveSlot();
            W3.SetActive(true);
            Slot3Image.gameObject.SetActive(true);
            controller.PlayWeapon3Sound();

            SetWeaponStats("Weapon3", "Kayrapaska", 90, 5.3f, 3.1f);
        }
        if (Player.IsAttacking)
        {
            PlayerSlashSounds();
        }
    }

    private void PlayerSlashSounds()
    {
        int weaponNr = Player.EquippedWeaponNumber;
        var controller = WeaponSoundController.Instance;

        if (weaponNr == 1) controller.PlayWeapon1Slash();
        else if (weaponNr == 2) controller.PlayWeapon2Slash();
        else if (weaponNr == 3) controller.PlayWeapon3Slash();
    }


    void resetWeapons()
    {
        W1.gameObject.SetActive(false);
        W2.gameObject.SetActive(false);
        W3.gameObject.SetActive(false);
    }

    void resetInventoryActiveSlot()
    {
        Slot1Image.gameObject.SetActive(false);
        Slot2Image.gameObject.SetActive(false);
        Slot3Image.gameObject.SetActive(false);
    }
}
