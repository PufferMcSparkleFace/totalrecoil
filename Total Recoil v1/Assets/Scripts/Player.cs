using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    public float thrustSpeed = 20f;
    //speed the character turns, making it public so different chassis can change it
    private float turnSpeed = 7.5f;
    //speed the character turns while shooting, making it public so different chassis/guns can change it
    private float turnSpeedWhileShooting = 3f;
    public bool isMachineGun = true;
    public bool canShoot = true;
    public GameManager gameManager;
    public GameObject target;
    public bool isInside;
    public GameObject machineGunMuzzleFlash;
    public float machineGunScreenShake = 3.0f;
    public CinemachineVirtualCamera mainCamera;
    public float asteroidScreenShake = 15.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        machineGunMuzzleFlash.SetActive(false);
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

        if(isInside == false)
        {
            gameManager.Damage(0.1f);
            rb.AddForce((target.transform.position - this.transform.position) * 0.1f);
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
        machineGunMuzzleFlash.SetActive(true);
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = machineGunScreenShake;
        yield return new WaitForSeconds(0.05f);
        machineGunMuzzleFlash.SetActive(false);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        yield return new WaitForSeconds(0.05f);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            gameManager.Damage(40f);
            StartCoroutine(AsteroidImpact());
        }
        
    }

    IEnumerator AsteroidImpact()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = asteroidScreenShake;
        yield return new WaitForSeconds(0.1f);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bounds")
        {
            Debug.Log("DON'T LEAVE ME");
            isInside = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bounds")
        {
            isInside = true;
        }
    }


}
