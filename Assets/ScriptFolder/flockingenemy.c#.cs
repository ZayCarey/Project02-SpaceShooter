using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingEnemy : MonoBehaviour
{
    public float speed = 2f;                  
    public float neighborRadius = 2f;         
    public float avoidanceRadius = 1f;        
    public float alignmentWeight = 1f;        
    public float cohesionWeight = 1f;         
    public float avoidanceWeight = 2f;        
    public float attackRange = 5f;            
    public float fireRate = 2f;               
    public GameObject bulletPrefab;           
    public Transform firePoint;               

    private FlockingEnemy[] allEnemies;       
    private Transform player;                 
    private float nextFireTime;               

    void Start()
    {
        allEnemies = FindObjectsOfType<FlockingEnemy>();  
        player = GameObject.FindGameObjectWithTag("Player").transform;  
        nextFireTime = Time.time;  
    }

    void Update()
    {
        Vector2 alignment = Vector2.zero;
        Vector2 cohesion = Vector2.zero;
        Vector2 avoidance = Vector2.zero;
        int neighborCount = 0;

        foreach (FlockingEnemy otherEnemy in allEnemies)
        {
            if (otherEnemy != this)
            {
                float distance = Vector2.Distance(transform.position, otherEnemy.transform.position);

                if (distance < neighborRadius)
                {
                    alignment += (Vector2)otherEnemy.transform.up;
                    cohesion += (Vector2)otherEnemy.transform.position;
                    if (distance < avoidanceRadius)
                    {
                        avoidance += (Vector2)(transform.position - otherEnemy.transform.position);
                    }
                    neighborCount++;
                }
            }
        }

        if (neighborCount > 0)
        {
            alignment /= neighborCount;
            cohesion /= neighborCount;
            cohesion = (cohesion - (Vector2)transform.position).normalized;
        }

        Vector2 direction = (alignment * alignmentWeight + cohesion * cohesionWeight + avoidance * avoidanceWeight).normalized;

        transform.up = Vector3.Lerp(transform.up, direction, Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (player != null)
        {
            float playerDistance = Vector2.Distance(transform.position, player.position);
            if (playerDistance <= attackRange)
            {
                AttackPlayer();
            }
        }
    }
    void AttackPlayer()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null && player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * 5f;  
            }
            nextFireTime = Time.time + fireRate;  
        }
    }
}
