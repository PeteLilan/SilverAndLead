using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
   /* [SerializeField]
    private GameObject shooterPrefab;
    [SerializeField]
    private GameObject tankPrefab;
    [SerializeField]
    private GameObject flyingPrefab;
   */

    [SerializeField]
    private float swarmerInterval = 3.5f;
   /* [SerializeField]
    private float shooterInterval = 25.0f;
    [SerializeField]
    private float tankInterval = 15.0f;
    [SerializeField]
    private float flyingInterval = 6.0f;
   */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy(swarmerInterval, swarmerPrefab));
        /*
        StartCoroutine(SpawnEnemy(shooterInterval, shooterPrefab));
        StartCoroutine(SpawnEnemy(tankInterval, tankPrefab));
        StartCoroutine(SpawnEnemy(flyingInterval, flyingPrefab));
        */

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            float radius = 10f; // how far from the spawner enemies appear
            //Creates a random point within a radius of the spawner
            Vector2 randomOffset = Random.insideUnitCircle * radius;
            //Spawns the enemy at the random position
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
