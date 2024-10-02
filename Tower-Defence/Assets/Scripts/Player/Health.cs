using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health = 4; // The live of the player
    void Start()
    {
        Enemies.OnHit += Damage; // This will subscribe to the OnHit action event from Enemies
    }

    private void Update()
    {
        if (health <= 0) 
        {
            SceneManager.LoadScene(2); // When the health of the player is 0 the player dies and the scene will switch to the game over switch
            Debug.Log("You're dead");
        }
    }
    private void Damage()
    {
        health -= 1; // When the action event is sent this function will be activated and take a health point from the player
    }
}
