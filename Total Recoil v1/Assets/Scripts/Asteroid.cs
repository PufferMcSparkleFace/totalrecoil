using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public BoxCollider2D asteroidCollider;
    public Sprite[] sprites;
    public float size = 5.0f;
    public float minSize = 2f;
    public float maxSize = 5f;
    public float speed = 75.0f;
    public float lifetime = 60;
    public AudioSource crash;
    public GameObject canvas;
    public Score score;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        canvas = GameObject.Find("Canvas");
        score = canvas.GetComponent<Score>();
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            if((this.size * 0.9f) >= this.minSize)
            {
                Split();
                Split();
            }
            asteroidCollider.enabled = false;
            spriteRenderer.enabled = false;
            score.UpdateScore(100);
            crash.Play(0);
            Destroy(this.gameObject, 4.0f);
        }
    }

    private void Split()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed * 0.1f);
    }

}
