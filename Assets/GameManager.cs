using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    public int score = 0;
    public Text scoreText; // Kéo UI Text vào đây trong Inspector
    public int highScore = 0; // Thêm biến highScore để lưu điểm cao nhất
    public Text highScoreText; // Kéo UI Text cho điểm cao nhất vào đây trong Inspector

    public AudioClip collectSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }
    public void AddScore(int value)
    {
        score += value;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Lưu điểm cao nhất vào PlayerPrefs
            if (highScoreText != null)
                highScoreText.text = "Best Score: " + highScore; // Cập nhật UI cho điểm cao nhất
        }
        UpdateScoreUI();
        PlaySound(collectSound);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (highScoreText != null) 
            highScoreText.text = "Best Score: " + highScore; // Cập nhật UI cho điểm cao nhất
    }

    // Update the GameOver method to match the correct signature of the Show method in GameOverUI
    public void GameOver()
    {
        isGameOver = true;
        PlaySound(gameOverSound);
        if (GameOverUI.Instance != null)
        {
            GameOverUI.Instance.Show(); // Removed the arguments to match the method signature
        }
    }

}