using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int scoreValue;
    public Text healthText;
    public Text scoreText;
    public Image healthBar;
    public Image scoreBar;
    public static GameController Instance { get; private set; }

    private int health = 100;
    private int temporaryScore = 0;
    private int score = 0;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void AddLife(int amount = 25)
    {
        if (health >= 100) return;

        health += amount;
        healthText.text = health.ToString();
        healthBar.fillAmount = (float)(health * 0.01);
    }

    public void RemoveLife(int amount)
    {
        if (health <= 0) return;

        health -= amount;
        healthText.text = health.ToString();
        healthBar.fillAmount = (float)(health * 0.01);
    }

    public void AddScore(int amount)
    {
        if (temporaryScore < scoreValue - 1)
        {
            temporaryScore += amount;
            float totalValue = (float)((temporaryScore * 100) / scoreValue * 0.01);
            scoreBar.fillAmount = totalValue;
        }
        else
        {
            score += amount;
            temporaryScore = 0;
            scoreBar.fillAmount = 0;
            scoreText.text = score.ToString();
        }
    }
}
