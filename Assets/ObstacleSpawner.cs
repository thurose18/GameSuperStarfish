using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int poolSize = 6;
    public float spawnInterval = 1f;
    public float spawnY = 6f;

    private List<GameObject> pool = new List<GameObject>();
    private float timer;

    void Start()
    {
        // Khởi tạo pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject obj = Instantiate(prefab, Vector3.up * 100, Quaternion.identity);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;
        // Dừng việc spawn khi game over

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
                float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane)).x;
                float spawnX = Random.Range(screenLeft + 0.5f, screenRight - 0.5f);

                obj.transform.position = new Vector3(spawnX, spawnY, 0);
                obj.SetActive(true);
                break;
            }
        }
    }
}