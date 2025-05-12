using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // Drag your monster prefab here
    public float spawnInterval = 3f;  // Time between spawns
    public float spawnRadius = 5f;    // How far from this object to spawn

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(monsterPrefab, randomPos, Quaternion.identity);
    }
}
