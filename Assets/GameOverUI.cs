using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void Show()
    {
        gameOverPanel.SetActive(true);
    }
}