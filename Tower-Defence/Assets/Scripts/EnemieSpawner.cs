using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Cube; // The prefab to spawn
    public float timer = 0; // Timer for automatic spawning
    public Vector3 spawnPoint = new Vector3(4, -5, 0); // Perfect spawn point for bottom of the camera

    void Start()
    {
        

    }

    void Update()
    {
        
        // Find all objects with the "Enemie" tag
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Enemie");

        // Update timer
        timer += Time.deltaTime;

        // Automatic spawning every 3 seconds
        if (timer >= 3)
        {
            Instantiate(Cube, spawnPoint, Quaternion.identity);
            Debug.Log("Spawned Cube automatically at: " + spawnPoint);
            timer = 0;
        }
    }
}
