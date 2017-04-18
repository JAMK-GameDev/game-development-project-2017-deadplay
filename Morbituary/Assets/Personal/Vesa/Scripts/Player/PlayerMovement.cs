using Assets.Code.Actors;
using Assets.Code.Actors.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
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

    void Awake()
    {
        rightSide.SetActive(false);
        frontSide.SetActive(false);
        leftSide.SetActive(false);
        backSide.SetActive(false);

        Player = Player.ToPlayer(Player.GetPlayer());
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        // anim.SetBool("isMoving", isMoving);
        float hSpeed = Input.GetAxisRaw("Horizontal") * speed;
        float vSpeed = Input.GetAxisRaw("Vertical") * speed;

        Player.MovementSpeed = Mathf.Max(Mathf.Abs(hSpeed), Mathf.Abs(vSpeed));

        Move(hSpeed, vSpeed); //initial version
        Animate(hSpeed, vSpeed);
        //MoveTowardMouse();
    }

    void Move(float h, float v)
    {
        // Initial version of movement
        movement.Set(h, 0f, v);
        movement = movement.normalized * Time.deltaTime * speed;
        playerRigidbody.MovePosition(transform.position + movement);
        
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

        frontSide.GetComponent<Animator>();

    }
}
