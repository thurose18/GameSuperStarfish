using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    public int score = 0;
    public Text scoreText; // Kéo UI Text vào đây trong Inspector


    void Awake()
    {
        Instance = this;
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = " " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}