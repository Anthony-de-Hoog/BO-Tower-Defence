using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HPText : MonoBehaviour
{
    private int health = 4;
    private int score = 0;
    private TMP_Text textField;

    void Start()
    {
        textField = GetComponent<TMP_Text>();
        Enemies.OnHit += ShowHP; // This will subscribe to the OnHit action event from Enemies
        Enemies.OnDefeat += ShowScore; // This will subscribe to the OnDefeat action event from Enemies
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = "Score: " + score + "    HP: " + health;
    }

    void ShowHP()
    {
        health -= 1;
    }

    void ShowScore()
    {
        score += 50;
    }
}
