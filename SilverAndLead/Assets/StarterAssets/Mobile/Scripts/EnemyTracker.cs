using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private EnemySpawner spawner;
    private bool hasReportedDeath = false;

    public void Init(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }

    private void OnDestroy()
    {
        if (spawner != null && !hasReportedDeath)
        {
            hasReportedDeath = true;
            spawner.EnemyDied();
        }
    }
}