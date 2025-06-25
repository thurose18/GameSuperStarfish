using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs ?? spawn (ch??ng ng?i v?t v� v?t ph?m)")]
    public GameObject[] spawnPrefabs;

    [Header("C�i ??t spawn")]
    public float spawnInterval = 1.5f; // Th?i gian gi?a c�c l?n spawn
    public float minX = -2.5f;         // Gi?i h?n tr�i tr?c X
    public float maxX = 2.5f;          // Gi?i h?n ph?i tr?c X
    public float spawnY = 6f;          // V? tr� Y ph�a tr�n m�n h�nh
    public float minSpacing = 1.0f;    // Kho?ng c�ch t?i thi?u gi?a c�c v?t th? (theo th?i gian)
    public float maxSpacing = 2.5f;    // Kho?ng c�ch t?i ?a gi?a c�c v?t th? (theo th?i gian)

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
            // Sinh v?t th? ti?p theo sau m?t kho?ng th?i gian ng?u nhi�n
            nextSpawnTime = Random.Range(minSpacing, maxSpacing);
            timer = 0f;
        }
    }

    void SpawnRandomObject()
    {
        // Ch?n prefab ng?u nhi�n
        int prefabIndex = Random.Range(0, spawnPrefabs.Length);
        GameObject prefab = spawnPrefabs[prefabIndex];

        // Ch?n v? tr� X ng?u nhi�n trong kho?ng cho ph�p
        float spawnX = Random.Range(minX, maxX);

        // Sinh v?t th? t?i v? tr� tr�n c�ng m�n h�nh
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}