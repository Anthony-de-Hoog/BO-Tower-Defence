using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Cube; // The prefab to spawn
    [SerializeField] private float timer = 0; // Timer for automatic spawning

    void Update()
    {
        // Find all objects with the "Enemie" tag
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Enemie");
        // Update timer
        timer += Time.deltaTime;
        // Automatic spawning every 3 seconds
        if (timer >= 3)
        {
            Instantiate(Cube, new Vector2(1,-6), Quaternion.identity);
            timer = 0;
        }
    }
}
