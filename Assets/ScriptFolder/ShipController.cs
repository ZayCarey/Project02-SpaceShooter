using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        
    public float rotationSpeed = 200f;  
    public GameObject bulletPrefab;     
    public Transform firePoint;         

    private float screenWidth;         
    private float screenHeight;    

    void Start()
    {
        Camera mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize;  
        screenWidth = screenHeight * mainCamera.aspect;  
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        if (rotationInput != 0)
        {
            transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        }
        ScreenWrap();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void ScreenWrap()
    {
        Vector3 position = transform.position;
        if (position.x > screenWidth)
        {
            position.x = -screenWidth;
        }
        else if (position.x < -screenWidth)
        {
            position.x = screenWidth;
        }

        if (position.y > screenHeight)
        {
            position.y = -screenHeight;
        }
        else if (position.y < -screenHeight)
        {
            position.y = screenHeight;
        }
        transform.position = position;
    }
}

