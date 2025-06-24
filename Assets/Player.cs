using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of horizontal movement

    private float halfWidth;

    void Start()
    {
        // Calculate half the width of the player in world units
        halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
#if UNITY_EDITOR
        // Kiểm tra nếu nhấn giữ chuột trái
        if (Input.GetMouseButton(0))
        {
            // Lấy vị trí chuột trên màn hình và chuyển sang tọa độ thế giới
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, Camera.main.nearClipPlane));
            Vector3 newPosition = transform.position;

            // Chỉ cập nhật vị trí X (di chuyển ngang)
            newPosition.x = mousePosition.x;

            // Giới hạn vị trí trong màn hình
            float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x + halfWidth;
            float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane)).x - halfWidth;
            newPosition.x = Mathf.Clamp(newPosition.x, screenLeft, screenRight);

            transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world position
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, transform.position.y, Camera.main.nearClipPlane));
            Vector3 newPosition = transform.position;

            // Only update X position (horizontal movement)
            newPosition.x = touchPosition.x;

            // Clamp the position so the player stays within the screen bounds
            float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x + halfWidth;
            float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane)).x - halfWidth;
            newPosition.x = Mathf.Clamp(newPosition.x, screenLeft, screenRight);

            transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
        }
#endif
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with an obstacle!");
            GameOver();
        }
    }

    void GameOver()
    {
        // Ẩn sao biển hoặc dừng game
        gameObject.SetActive(false);
        Debug.Log("Game Over!");

        // Hiển thị màn hình Game Over
         GameOverUI.Instance.Show();

        GameManager.Instance.GameOver();
    }
}