using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public float thrustSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject target;
    public float health = 20.0f;
    public Score score;
    public PolygonCollider2D enemyCollider;
    public SpriteRenderer sprite;
    public AudioSource shot;
    public AudioSource crash;
    public AudioSource death;
    public Rigidbody2D playerrb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        playerrb = target.GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = target.transform.position - this.transform.position;
        rb.AddForce(direction * thrustSpeed);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 87;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - 3;
            crash.Play(0);
            playerrb.AddForce((transform.up * 40)* 20f);
            if (health <= 0)
            {
                score.UpdateScore(1000);
                sprite.enabled = false;
                enemyCollider.enabled = false;
                score.combo++;
                death.Play(0);
                Destroy(this.gameObject, 4.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health = health - 1;
            shot.Play(0);
            if (health <= 0)
            {
                score.UpdateScore(1000);
                sprite.enabled = false;
                enemyCollider.enabled = false;
                score.combo++;
                death.Play(0);
                Destroy(this.gameObject, 4.0f);
            }
        }
    }
}
