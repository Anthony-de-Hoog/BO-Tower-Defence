using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health = 4; // The live of the player
    private HPText Gscore; 

    void Start()
    {
        Enemies.OnHit += Damage; // This will subscribe to the OnHit action event from Enemies
        Gscore = GetComponent<HPText>(); // Gets the component from the HPText script
    }

    private void Update()
    {

        if (health <= 0) 
        {
            SceneManager.LoadScene(2); // When the health of the player is 0 the player dies and the scene will switch to the game over switch
            Gscore.Score = 0; // Resets the game score
            
        }
    }
    private void Damage()
    {
        health -= 1; // When the action event is sent this function will be activated and take a health point from the player
    }
}
