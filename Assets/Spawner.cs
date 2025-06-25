using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs ?? spawn (ch??ng ng?i v?t và v?t ph?m)")]
    public GameObject[] spawnPrefabs;

    [Header("Cài ??t spawn")]
    public float spawnInterval = 1.5f; // Th?i gian gi?a các l?n spawn
    public float minX = -2.5f;         // Gi?i h?n trái tr?c X
    public float maxX = 2.5f;          // Gi?i h?n ph?i tr?c X
    public float spawnY = 6f;          // V? trí Y phía trên màn hình
    public float minSpacing = 1.0f;    // Kho?ng cách t?i thi?u gi?a các v?t th? (theo th?i gian)
    public float maxSpacing = 2.5f;    // Kho?ng cách t?i ?a gi?a các v?t th? (theo th?i gian)

    private float timer = 0f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            SpawnRandomObject();
            // Sinh v?t th? ti?p theo sau m?t kho?ng th?i gian ng?u nhiên
            nextSpawnTime = Random.Range(minSpacing, maxSpacing);
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        // Ch?n prefab ng?u nhiên
        int prefabIndex = Random.Range(0, spawnPrefabs.Length);
        GameObject prefab = spawnPrefabs[prefabIndex];

        // Ch?n v? trí X ng?u nhiên trong kho?ng cho phép
        float spawnX = Random.Range(minX, maxX);

        // Sinh v?t th? t?i v? trí trên cùng màn hình
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}