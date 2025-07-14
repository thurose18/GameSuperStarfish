using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    public GameObject gameOverPanel;
    public Text restartHintText;

    private bool canRestart = false;

    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
        if (restartHintText != null)
            restartHintText.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameOverPanel.SetActive(true);
        if (restartHintText != null)
        {
            restartHintText.text = "Nhấn vào màn hình để chơi lại";
            restartHintText.gameObject.SetActive(true);
        }
        canRestart = true;
        Debug.Log("Game Over UI is now visible!");
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

    void RestartGame()
    {
        canRestart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}