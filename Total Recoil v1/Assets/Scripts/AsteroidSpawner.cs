using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRate = 1.0f;
    public int spawnAmount = 1;

    private void Start()
    {
        //repeatedly calls function, starting it at time x and repeating every time y
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < this.spawnAmount; i++)
        {

        }
    }
}
