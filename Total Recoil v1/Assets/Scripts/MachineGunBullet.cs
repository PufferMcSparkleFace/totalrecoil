﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    public float speed = 750.0f;
    private Rigidbody2D rb;
    public float lifetime = 3.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
