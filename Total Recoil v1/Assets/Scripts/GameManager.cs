using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player playerScript;
    public GameObject playerObject;
    public float health;
    public float maxHealth = 100f;
    public float healRate = 0.1f;
    public float healRateWhileShooting = 0.05f;
    public bool isHealing;
    public float healTime = 3.0f;
    public Rigidbody2D rb;
    public Slider slider;

    private void Awake()
    {
        rb = playerObject.GetComponent<Rigidbody2D>();
        health = maxHealth;
        SetMaxHealth(maxHealth);
        
    }
    private void FixedUpdate()
    {
        if(health <= 0)
        {
            GameOver();
        }
        if(isHealing == true && playerScript.isShooting == true && health < maxHealth && health > 0)
        {
            health = health + healRateWhileShooting;
            SetHealth(health);
        }
        else if(isHealing == true && playerScript.isShooting == false && health < maxHealth && health > 0)
        {
            health = health + healRate;
            SetHealth(health);
        }
        else if(health >= maxHealth)
        {
            isHealing = false;
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
        SetHealth(health);
        isHealing = false;
        StartCoroutine(Healing());
    }

    IEnumerator Healing()
    {
        yield return new WaitForSeconds(healTime);
        isHealing = true;
    }

    public void SetHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

    }
}
