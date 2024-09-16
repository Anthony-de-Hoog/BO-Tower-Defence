using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cube;
    public float timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Enemie");
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(Cube);
            }
        }
        if (timer >= 3)
        {
            Instantiate(Cube);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            foreach (GameObject cube in cubes)
                Destroy(cube);
        }

    }
}