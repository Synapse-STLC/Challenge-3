using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerShip;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private AudioSource shotSound;

    private float nextFire;

    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
        shotSound = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotSound.Play();
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerShip.velocity = movement * speed;

        playerShip.position = new Vector3
            (
            Mathf.Clamp(playerShip.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(playerShip.position.z, boundary.zMin, boundary.zMax)
            );

        playerShip.rotation = Quaternion.Euler(0.0f, 0.0f, playerShip.velocity.x * -tilt);
    }
}
