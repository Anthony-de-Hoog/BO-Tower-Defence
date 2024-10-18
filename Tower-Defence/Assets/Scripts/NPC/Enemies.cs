using System;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // The speed of the enemy
    [SerializeField] private int health = 12; // The enemy starts with 12 health

    private Waypoints Wpoints;
    private int waypointIndex = 0;  // Initialize to 0

    public static event Action OnHit; //The action event for when the enemy reaches his end
    public static event Action OnDefeat; // The action event for when the player lost all his health


    void Start()
    {
        // My method to find a single GameObject, not an array
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        // Check if I still have waypoints to move toward
        if (Wpoints == null || Wpoints.waypoints.Length == 0) return;

        // Moves towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);


        // Check if they have reached the current waypoint
        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1) 
            {
                waypointIndex++; // This will make sure the enemy goes to the next waypoint
            }
            else
            {
                OnHit?.Invoke(); // This will send the action event

                Destroy(gameObject);  // Destroy the enemy when it reaches the final waypoint
            }
        }
    }

    // This method is called when the enemy takes damage
    public void TakeDamage(int amount)
    {
        health -= amount; // Reduce health by the given amount
        if (health <= 0)
        {
            OnDefeat?.Invoke(); // This will send the action event
            Destroy(gameObject); // Destroy the enemy game object
        }
    }
}
