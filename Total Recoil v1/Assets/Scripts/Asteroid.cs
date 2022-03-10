﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public Sprite[] sprites;
    public float size = 5.0f;
    public float minSize = 2f;
    public float maxSize = 5f;
    public float speed = 75.0f;
    public float lifetime = 60;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //randomising the sprite of the asteroid
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //randomizing the rotation of the asteroids
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

       //vector3.one is shorthand for new vector3 = (this.size, this.size, this.size)
        this.transform.localScale = Vector3.one * this.size;

        rb.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(this.gameObject, this.lifetime);
    }

    
}
