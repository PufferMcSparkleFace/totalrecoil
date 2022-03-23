using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public float thrustSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    private void FixedUpdate()
    {
        rb.AddForce((target.transform.position - this.transform.position) * thrustSpeed);
    }
}
