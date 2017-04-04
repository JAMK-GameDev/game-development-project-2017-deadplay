using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Lever")
        {
            Debug.Log("It's a lever");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.collider.tag == "Lever")
        {
            Debug.Log("Something happened");
        }
    }
}
