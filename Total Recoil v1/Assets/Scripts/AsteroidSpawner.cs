using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 1.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 20.0f;
    public float trajectoryVariance = 15.0f;

    private void Start()
    {
        //repeatedly calls function, starting it at time x and repeating every time y
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < this.spawnAmount; i++)
        {
            //sets spawn point to be at any point around the edge of a circle (insideUnitCircle is any point inside circle of radius one, and normalized makes it a whole number always)
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            
            //ensures that asteroids spawn relative to the spawner which can then be moved
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            //creates a cone for variance in the trajectory of the asteroids, making them seem more varied
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);

            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            //trajectory needs to be opposite because it spawns facing outwards
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
