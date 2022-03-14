using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player playerScript;
    public GameObject playerObject;
    public float health;
    public float maxHealth = 100f;
    public float healRate = 0.1f;
    public float healRateWhileShooting = 0.5f;
    public bool isHealing;
    public float healTime = 3.0f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = playerObject.GetComponent<Rigidbody2D>();
        health = maxHealth;
    }
    private void FixedUpdate()
    {
        if(health <= 0)
        {
            GameOver();
        }
        if(isHealing == true && playerScript.isShooting == true && health < maxHealth)
        {
            health = health + healRateWhileShooting;
        }
        else if(isHealing == true && playerScript.isShooting == false && health < maxHealth)
        {
            health = health + healRate;
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
