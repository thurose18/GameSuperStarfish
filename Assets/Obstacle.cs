using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 5f;
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
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        // Di chuyển chướng ngại vật xuống dưới
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Xoay chướng ngại vật quanh trục Z
        transform.Rotate(0, 0, currentRotateSpeed * Time.deltaTime);

        // Nếu chướng ngại vật ra khỏi màn hình dưới, ẩn nó đi (dùng cho Object Pooling)
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f)
        {
            gameObject.SetActive(false); // Nếu không dùng pooling thì có thể dùng Destroy(gameObject)
        }
    }
}