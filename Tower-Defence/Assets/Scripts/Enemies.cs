using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 2f;

    public float lifetime = 5f; // Time before the object is destroyed

    void Start()
    {
        // Destroy the object after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
