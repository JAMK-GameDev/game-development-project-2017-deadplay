using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTest : MonoBehaviour
{
    public GameObject enemy;
    public int numOfEnemies = 5;

    bool fakeLeverActivated = false;
    bool levelActivated = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Lever")
        {
            Debug.Log("It's a lever");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.collider.tag == "FakeLever" && !fakeLeverActivated)
        {
            Debug.Log("Ya dun goofed");
            fakeLeverActivated = true;
            Spawn();
        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.collider.tag == "Lever" && !levelActivated)
        {
            Debug.Log("Yay");
            levelActivated = true;
            Destroy(GameObject.Find("Door"));
        }
    }

    void Spawn()
    {
        float angle = 0;
        float angleDiff = 360f / numOfEnemies;
        Vector3 center = transform.position;
        for (int i = 0; i < numOfEnemies; i++)
        {
            Vector3 pos = CalculateEnemyPosition(center, 4.0f, angle);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(enemy, pos, rot);
            angle += angleDiff;
            Debug.Log("Spawn.");
        }
    }

    Vector3 CalculateEnemyPosition(Vector3 center, float radius, float angle)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return pos;
    }
}
