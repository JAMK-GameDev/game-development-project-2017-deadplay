using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {

    public GameObject enemy;
    public int numOfEnemies = 5;
    bool isTriggered = false;


    void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            // Spawn enemies once, remove collider and light, show text
            UIPopupTextController.CreatePopupText("Whoa, enemies!", transform);
            isTriggered = true;
            Spawn();
            Destroy(GetComponent<Collider>());
            Destroy(GetComponentInChildren<Light>());
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
