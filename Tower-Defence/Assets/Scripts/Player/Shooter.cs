using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;  // Bullet prefab to shoot
    [SerializeField] private Transform shootPoint;    // The point where the bullet will be spawned
    private float fireRate = 1f;      // Time between shots
    private float fireCountdown = 0f;
    private FindTarget target;

    void Start()
    {
        target = GetComponent<FindTarget>();
    }
    void Update()
    {
        // Check if it's time to shoot
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }


    // Method to shoot a bullet towards the enemy
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        Bullets bullet = bulletGO.GetComponent<Bullets>();

        if (bullet != null)
        {
            bullet.Seek(target.Target); // Pass the target to the bullet script
        }
    }
}
