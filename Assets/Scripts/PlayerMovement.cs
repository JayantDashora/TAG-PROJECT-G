using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables 

    private float moveSpeed = 10f;
    private float jumpFactor = 40f;
    private Rigidbody playerRb;
    private int leftMouseButton = 0;
    private int rightMouseButton = 1;

    private float bulletSpeed = 20f;

    [SerializeField] private GameObject destoryingBullet;
    [SerializeField] private GameObject changingBullet;
    [SerializeField] private Transform bulletSpawnPoint;


    private bool isOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        
        // Player Movement 

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }
        
        if(Input.GetKeyUp(KeyCode.Space) && isOnGround){
            playerRb.AddForce(Vector3.up * jumpFactor);
            isOnGround = false;
        }

        // Shooting with left mouse button

        if(Input.GetMouseButtonDown(leftMouseButton)){
            var bullet = Instantiate(destoryingBullet, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.up * bulletSpeed;
        }

        // Shooting with right mouse button

        if(Input.GetMouseButtonDown(rightMouseButton)){
            var bullet = Instantiate(changingBullet, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.up * bulletSpeed;
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
    }

}
