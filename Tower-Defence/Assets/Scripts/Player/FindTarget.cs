using UnityEngine;

public class FindTarget : MonoBehaviour
{
    private float range = 2f; // The radius of the tower's shooting range
    private Transform target; // Current target enemy

    public Transform Target 
    { 
        get { return target; }
        set { target = value; }
    }



    void Update()
    {
        // Find the closest enemy in range
        findTarget();

        if (target == null)
            return;
    }

    // Method to find the closest enemy within range
    void findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemie");  // Find all enemies
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Loop through all enemies to find the closest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is closer than the previous ones
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
