using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    public GameObject rightSide;
    public GameObject frontSide;
    public GameObject leftSide;
    public GameObject backSide;

    Vector3 movement;
    Rigidbody playerRigidbody;
    public Plane playerPlane;
    public Transform Player;
    public Ray ray;

    bool isMoving;
    Animator anim;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        isMoving = false;
        anim.SetBool("isMoving", isMoving);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v); //initial version
        Animate(h, v);
        //MoveTowardMouse();
    }

    void Move(float h, float v)
    {
        // Initial version of movement
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
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
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            frontSide.SetActive(false);
            rightSide.SetActive(true);
            backSide.SetActive(false);
            leftSide.SetActive(false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            frontSide.SetActive(false);
            rightSide.SetActive(false);
            backSide.SetActive(true);
            leftSide.SetActive(false);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            frontSide.SetActive(false);
            rightSide.SetActive(false);
            backSide.SetActive(false);
            leftSide.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            frontSide.SetActive(true);
            rightSide.SetActive(false);
            backSide.SetActive(false);
            leftSide.SetActive(false);
            
        }

    }

}
