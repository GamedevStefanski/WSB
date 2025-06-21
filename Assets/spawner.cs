using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float respawnCooldown = 3f;

    private List<GameObject> trackedEnemies = new List<GameObject>();
    private bool isSpawning = false;

    void Update()
    {
        CleanupDeadEnemies();

        if (!isSpawning)
        {
            StartCoroutine(SpawnIfEnemyMissing());
        }
    }

    private void CleanupDeadEnemies()
    {
        trackedEnemies.RemoveAll(enemy => enemy == null);
    }

    private IEnumerator SpawnIfEnemyMissing()
    {
        if (trackedEnemies.Count == 0)
        {
            isSpawning = true;
            yield return new WaitForSeconds(respawnCooldown);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            trackedEnemies.Add(newEnemy);

            isSpawning = false;
        }
    }
}
