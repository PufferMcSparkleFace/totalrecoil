using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player playerScript;
    public GameObject playerObject;
    public float health = 100f;
    public float healRate = 0.1f;
    public float healRateWhileShooting = 0.5f;
    public bool isHealing;
    public float healTime = 3.0f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = playerObject.GetComponent<Rigidbody2D>();  
    }
    private void Update()
    {
        if(health <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0.0f;
        playerObject.SetActive(false);
    }

    public void Damage(float damage)
    {
        health = health - damage;
    }
}
