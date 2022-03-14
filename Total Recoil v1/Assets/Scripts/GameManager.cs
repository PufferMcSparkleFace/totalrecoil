using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float health = 100f;
    public float healRate = 0.1f;
    public float healRateWhileShooting = 0.5f;
    public bool isHealing;
    public float healTime = 3.0f;

    private void Update()
    {
        if(health <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {

    }

    public void Damage(float damage)
    {
        health = health - damage;
    }
}
