using TMPro;
using UnityEngine;

public class HPText : MonoBehaviour
{
    private int health = 4; // Player health
    private int score = 0; // The game score

    // Makes the score accesable for the other scripts and private for the users
    public int Score { 
        get { return score; } 
        set { score = value; }
    }

    private TMP_Text textField;

    private NextScene nextScene;

    void Start()
    {
        nextScene = GetComponent<NextScene>();
        textField = GetComponent<TMP_Text>();
        Enemies.OnHit += ShowHP; // This will subscribe to the OnHit action event from Enemies
        Enemies.OnDefeat += ShowScore; // This will subscribe to the OnDefeat action event from Enemies
    }

    void Update()
    {
        textField.text = "Score: " + score + "\n HP: " + health;
    }

    void ShowHP()
    {
        health -= 1;
    }

    void ShowScore()
    {
        score += 50;

        if (score >= 900)
        {
            nextScene.LoadScene(3);
            score = 0;
        }
    }
}
