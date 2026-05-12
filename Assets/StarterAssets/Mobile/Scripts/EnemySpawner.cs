using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private float swarmerInterval = 3.5f;
    [SerializeField] private int maxCount = 50;
    [SerializeField] private float spawnRadius = 10f;

    private int currentCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        while (true)
        {
            while (currentCount >= maxCount)
            {
                yield return null;
            }

            yield return new WaitForSeconds(interval);

            if (currentCount >= maxCount)
                continue;

            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            currentCount++;

            EnemyTracker tracker = newEnemy.AddComponent<EnemyTracker>();
            tracker.Init(this);

            Debug.Log("Current Enemy Count: " + currentCount);
        }
    }

    public void EnemyDied()
    {
        currentCount--;
        currentCount = Mathf.Max(currentCount, 0);

        Debug.Log("Enemy died. Current Enemy Count: " + currentCount);
    }
}