using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Di chuyển chướng ngại vật xuống dưới
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Nếu chướng ngại vật ra khỏi màn hình dưới, ẩn nó đi (dùng cho Object Pooling)
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f)
        {
            gameObject.SetActive(false); // Nếu không dùng pooling thì có thể dùng Destroy(gameObject)
        }
    }
}