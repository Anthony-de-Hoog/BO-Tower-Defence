using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Cube; // The prefab to spawn
    [SerializeField] private float timer = 0; // Timer for automatic spawning
    //public Vector3 spawnPoint = new Vector3(4, -5, 0); // Perfect spawn point for bottom of the camera

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
            Instantiate(Cube, new Vector2(1,-5), Quaternion.identity);
            timer = 0;
        }
    }
}
