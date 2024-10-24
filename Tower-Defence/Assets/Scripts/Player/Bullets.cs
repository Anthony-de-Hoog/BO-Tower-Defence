using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float speed = 5f; // Speed of the bullets
    private Transform target;

    // Function to assign a target to the bullet
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        // If there is no target, the bullet will be destroyed
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Move the bullet towards the target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // If the bullet reaches the target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Move the bullet forward
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Damage(target); // Damages the target, in this instance the enemie object
        Destroy(gameObject); // Destroy the bullet
    }

    void Damage(Transform enemy)
    {
        // Check if the target has an Enemy component and apply damage
        Enemies enemyComponent = enemy.GetComponent<Enemies>();
        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(1); // Deal 1 damage to the enemy
        }
    }
}
