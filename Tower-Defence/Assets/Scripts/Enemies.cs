using UnityEngine;
public class Enemies : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float lifetime = 5f; // Time before the object is destroyed
    void Start()
    {
        // Destroy the object after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position = transform.position + transform.up * speed * Time.deltaTime;
    }
}
