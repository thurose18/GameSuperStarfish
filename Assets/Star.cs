using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tăng điểm
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(1);

            // Ẩn vật phẩm (hoặc Destroy nếu không dùng pooling)
            gameObject.SetActive(false);
        }
    }
}
