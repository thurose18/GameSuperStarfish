using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    public GameObject gameOverPanel;
    public Text restartHintText;
    public Text scoreText;
    public Text bestScoreText;

    private bool canRestart = false;

    // Lưu vị trí ban đầu
    private Vector2 scoreTextOriginalPos;
    private Vector2 bestScoreTextOriginalPos;
    private Vector2 centerPos = new Vector2(0, 0); // Giữa màn hình (Canvas)

    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
        if (restartHintText != null)
            restartHintText.gameObject.SetActive(false);
        // Lưu vị trí ban đầu
        if (scoreText != null)
            scoreTextOriginalPos = scoreText.rectTransform.anchoredPosition;
        if (bestScoreText != null)
            bestScoreTextOriginalPos = bestScoreText.rectTransform.anchoredPosition;
    }

    public void Show()
    {
        gameOverPanel.SetActive(true);
        canRestart = true;
        if (restartHintText != null)
        {
            restartHintText.text = "Tap to continue";
            restartHintText.gameObject.SetActive(true);
        }
        Debug.Log("Game Over UI is now visible!");
        if (scoreText != null)
        {
            scoreText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            scoreText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            scoreText.rectTransform.anchoredPosition = new Vector2(0, 40);
        }
        if (bestScoreText != null)
        {
            bestScoreText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            bestScoreText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            bestScoreText.rectTransform.anchoredPosition = new Vector2(68, -75);
        }
    }
    void Update()
    {
        if (canRestart)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
#else
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RestartGame();
            }
#endif
        }
    }
    void ResetScoreTextPosition()
    {
        // Trả về vị trí ban đầu khi chơi lại
        if (scoreText != null)
        {
            scoreText.rectTransform.anchorMin = new Vector2(0, 1);
            scoreText.rectTransform.anchorMax = new Vector2(0, 1);
            scoreText.rectTransform.anchoredPosition = scoreTextOriginalPos;
        }
        if (bestScoreText != null)
        {
            bestScoreText.rectTransform.anchorMin = new Vector2(0, 1);
            bestScoreText.rectTransform.anchorMax = new Vector2(0, 1);
            bestScoreText.rectTransform.anchoredPosition = bestScoreTextOriginalPos;
        }
    }
    void RestartGame()
    {
        canRestart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}