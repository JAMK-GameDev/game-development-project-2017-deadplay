using Assets.Code.Actors;
using Assets.Code.Actors.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0f;
    public GameObject rightSide;
    public GameObject frontSide;
    public GameObject leftSide;
    public GameObject backSide;
    public Plane playerPlane;
    public Transform PlayerTransform;
    public Ray ray;

    private Vector3 movement;
    private Rigidbody playerRigidbody;
    // private Animator anim;
    private Player Player;
    ArrayList weapons = new ArrayList();

    void Awake()
    {
        if (rightSide == null || frontSide == null || leftSide == null || backSide == null) throw new System.Exception("Not all Character Rigs have been initialized in Player");

        // Set all Character rigs to false. 
        // They need to be enabled on game startupm, otherwise unity has issues with activating them.
        rightSide.SetActive(false);
        frontSide.SetActive(false);
        leftSide.SetActive(false);
        backSide.SetActive(false);

        Player = Player.ToPlayer(Player.GetPlayer());
        playerRigidbody = GetComponent<Rigidbody>();

        GameObject wp1 = GameObject.Find("Weapon1");
        GameObject wp2 = GameObject.Find("Weapon2");
        GameObject wp3 = GameObject.Find("Weapon3");
        
        weapons.Add(wp1);
        weapons.Add(wp2);
        weapons.Add(wp3);

    }

    void FixedUpdate()
    {
        if (!Player.IsDead)
        {
            // anim.SetBool("isMoving", isMoving);
            float hSpeed = Input.GetAxisRaw("Horizontal") * speed;
            float vSpeed = Input.GetAxisRaw("Vertical") * speed;

            Player.MovementSpeed = Mathf.Max(Mathf.Abs(hSpeed), Mathf.Abs(vSpeed));

            Move(hSpeed, vSpeed); //initial version
            ChangeSpeed();
            Animate(hSpeed, vSpeed);
            ChangeWeaponDirection();
            //MoveTowardMouse();
        }
    }

    void ChangeWeaponDirection()
    {
        // Change weapon direction
        // TODO: add other weapons too
        

        foreach (GameObject wp in weapons)
        {
            if (Player.LooksDown)
            {
                Transform playerTransform = Player.GetComponent<Transform>();
                Vector3 newPos = transform.position;
                Vector3 offset = new Vector3(-2.0f, 0f, -2f);
                wp.transform.position = newPos + offset;
            }
            if (Player.LooksUp)
            {
                Transform playerTransform = Player.GetComponent<Transform>();
                Vector3 newPos = transform.position;
                Vector3 offset = new Vector3(-2.0f, 0f, 2f);
                wp.transform.position = newPos + offset;
            }
            if (Player.LooksLeft)
            {
                Transform playerTransform = Player.GetComponent<Transform>();
                Vector3 newPos = transform.position;
                Vector3 offset = new Vector3(-4.0f, 0f, 0f);
                wp.transform.position = newPos + offset;
            }
            if (Player.LooksRight)
            {
                Transform playerTransform = Player.GetComponent<Transform>();
                Vector3 newPos = transform.position;
                Vector3 offset = new Vector3(0.0f, 0f, 0f);
                wp.transform.position = newPos + offset;
            }
        }
    }

    void Move(float h, float v)
    {
        // Initial version of movement
        movement.Set(h, 0f, v);
        movement = movement.normalized * Time.deltaTime * speed;
        playerRigidbody.MovePosition(transform.position + movement);
        
    }

	void ChangeSpeed()
	{ 
		if (Input.GetKey("left shift"))
		{
			speed = 6.0f;
		}
		else
		{
			speed = 4.0f;
		}
	}

    void MoveTowardMouse()
    {
        // Different version for movement with mousepostion
        //Player to move left, right, up, down
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        playerPlane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = targetRotation;
        }
    }

    void Animate(float h, float v)
    {
        var anim = GetComponentInChildren<Animator>();
        bool isMoving = Player.IsMoving;
        if (Player.LooksRight)
        {
            // isMoving = true;
            frontSide.SetActive(false);
            rightSide.SetActive(true);
            backSide.SetActive(false);
            leftSide.SetActive(false);
        }
        else if (Player.LooksUp)
        {
            // isMoving = true;
            frontSide.SetActive(false);
            rightSide.SetActive(false);
            backSide.SetActive(true);
            leftSide.SetActive(false);
            
        }
        else if (Player.LooksLeft)
        {
            // isMoving = true;
            frontSide.SetActive(false);
            rightSide.SetActive(false);
            backSide.SetActive(false);
            leftSide.SetActive(true);
        }
        else if (Player.LooksDown)
        {
            // isMoving = true;
            frontSide.SetActive(true);
            rightSide.SetActive(false);
            backSide.SetActive(false);
            leftSide.SetActive(false);
        }
    }
}
