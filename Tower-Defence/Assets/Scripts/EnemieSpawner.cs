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
        // Debug the initial spawn point value
        Debug.Log($"Initial spawnPoint: {spawnPoint}");

    }

    void Update()
    {
        // Debug the spawn point value each frame
        Debug.Log($"Current spawnPoint: {spawnPoint}");

        // Find all objects with the "Enemie" tag
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Enemie");

        // Update timer
        timer += Time.deltaTime;

        // Spawn on W key press
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(Cube, spawnPoint, Quaternion.identity);
            Debug.Log("Spawned Cube at: " + spawnPoint);
        }

        // Automatic spawning every 3 seconds
        if (timer >= 3)
        {
            Instantiate(Cube, spawnPoint, Quaternion.identity);
            Debug.Log("Spawned Cube automatically at: " + spawnPoint);
            timer = 0;
        }

        // Destroy all enemies on Q key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (GameObject cube in cubes)
                Destroy(cube);
        }
    }
}
