using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MachineGunBullet machineGunBulletPrefab;
    //reference to the rigidbody obv
    private Rigidbody2D rb;
    //if you're shooting, you turn slower
    public bool isShooting;
    //this is how the guy is doing turning, a bit weird but whatever
    public float turnDirection;
    //speed the character moves, making it public so different weapons can change it
    public float thrustSpeed = 15f;
    //speed the character turns, making it public so different chassis can change it
    private float turnSpeed = 5f;
    //speed the character turns while shooting, making it public so different chassis/guns can change it
    private float turnSpeedWhileShooting = 2.5f;
    public bool isMachineGun = true;
    public bool canShoot = true;
    public GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //setting turn direction based on inputs, values are reversed because we're applying torque to the player
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }
        
    }

    private void FixedUpdate()
    {
        //if you're turning add torque to turn, if you're shooting you turn slower
        if(turnDirection != 0.0 && isShooting == false)
        {
            rb.AddTorque(turnDirection * turnSpeed);
        }
        else if(turnDirection != 0.0 && isShooting == true)
        {
            rb.AddTorque(turnDirection * turnSpeedWhileShooting);
        }

        if(isMachineGun == true)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isShooting = true;
                Shoot();
            }
            else
            {
                isShooting = false;
            }

            //when you're shooting add force in opposite direction to shot
            if (isShooting == true)
            {
                rb.AddForce(-this.transform.up * thrustSpeed);
            }

        }
      
    }

    private void Shoot()
    {
        if (isMachineGun == true && canShoot == true)
        {
            MachineGunBullet bullet = Instantiate(this.machineGunBulletPrefab, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up);
            canShoot = false;
            StartCoroutine(MachineGunFire());
            
        }
        
    }

    IEnumerator MachineGunFire()
    {
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            
        }
    }
}
