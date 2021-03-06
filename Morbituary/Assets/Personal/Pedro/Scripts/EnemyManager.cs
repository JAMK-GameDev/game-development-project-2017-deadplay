﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 3f;
    public float spawnInterval = 10f;
    public Transform[] spawnPoints;

    bool isTriggered = false;

    void Spawn()
    {
        // This works for demoing, but should be refactored later
        if (GameObject.Find("EnemySpawnPoint") == null)
        {
            Debug.Log("Spawn destroyed!");
            CancelInvoke("Spawn");
        }
        else
        {
            // Find a random index between zero and one less than the number of spwan points.d
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            Debug.Log("Spawn.");
        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(!isTriggered)
        {
            Debug.Log("TRIGGERED!");
            InvokeRepeating("Spawn", spawnTime, spawnInterval);
            isTriggered = true;
        }
        
        
    }
    
}
