using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    public int score = 0;
    public Text scoreText; // Kéo UI Text vào đây trong Inspector

    public AudioClip collectSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        PlaySound(collectSound);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = " " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        PlaySound(gameOverSound);
    }

}