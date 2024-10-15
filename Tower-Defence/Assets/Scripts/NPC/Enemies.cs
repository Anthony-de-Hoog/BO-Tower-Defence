using System;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int health = 12; // The enemy starts with 12 health

    private Waypoints Wpoints;
    private int waypointIndex = 0;  // Initialize to 0

    public static event Action OnHit; //The action event for when the enemy reaches his end
    public static event Action OnDefeat;


    void Start()
    {
        // My the method to find a single GameObject, not an array
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();

        // Ensure you have at least one waypoint
        if (Wpoints == null || Wpoints.waypoints.Length == 0)
        {
            Debug.LogError("No waypoints found or Waypoints component missing.");
            return;
        }
    }

    void Update()
    {
        // Check if we still have waypoints to move toward
        if (Wpoints == null || Wpoints.waypoints.Length == 0) return;

        // Move towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        // Rotate the enemy to face the direction it's moving in
        //Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Check if we've reached the current waypoint
        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
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
