using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemySpawner : MonoBehaviour
{
    public float spawnRate = 3.0f;
    public int spawnAmount = 1;
    public HomingEnemy homingEnemyPrefab;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 10.0f, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * 20.0f;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-15, 15);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            HomingEnemy homingEnemy = Instantiate(this.homingEnemyPrefab, spawnPoint, rotation);
        }
    }
}
