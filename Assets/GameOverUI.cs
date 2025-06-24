using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void Show()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        Debug.Log("Game Over UI is now visible!");
    }
}