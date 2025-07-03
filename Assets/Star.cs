using UnityEngine;

public class Star : MonoBehaviour
{
    public float minRotateSpeed = 30f; // Tốc độ xoay nhỏ nhất (độ/giây)
    public float maxRotateSpeed = 90f; // Tốc độ xoay lớn nhất (độ/giây)
    private float currentRotateSpeed;

    void OnEnable()
    {
        // Tốc độ xoay ngẫu nhiên trong khoảng, chiều cũng ngẫu nhiên
        float speed = Random.Range(minRotateSpeed, maxRotateSpeed);
        currentRotateSpeed = speed * (Random.value < 0.5f ? 1f : -1f);
    }
    void Update()
    {
        // Xoay vật phẩm quanh trục Z với tốc độ và chiều ngẫu nhiên
        transform.Rotate(0, 0, currentRotateSpeed * Time.deltaTime);
    }
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
