using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int scoreValue = 10;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.AddScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public float speed = 3f;
    private Vector2 randomDirection;

    void Start()
    {
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }

    void Update()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime);
        ScreenWrap();
    }

    void ScreenWrap()
    {
        Vector3 position = transform.position;
        Camera mainCamera = Camera.main;
        float screenHeight = mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

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