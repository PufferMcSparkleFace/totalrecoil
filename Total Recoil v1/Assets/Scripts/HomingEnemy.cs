﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public float thrustSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject target;
    public float health = 20.0f;
    public Score score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        rb.AddForce((target.transform.position - this.transform.position) * thrustSpeed);
        if(health <= 0)
        {
            score.UpdateScore(1000);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health = health - 1;
        }
    }
}
