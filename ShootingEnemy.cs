using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public AudioSource EnemyBulletSound;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float EnemyHealth = 10;
    public float EnemyDamage = 2;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;
    public Transform firepoint;
    private Vector2 movement;
    public Rigidbody2D rb;
    public GameObject EnemyBulletParticle;

    public float bulletForce;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Target").transform;

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Bullet Variant(Clone)"), 2f);

        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance )
        {
            transform.position = this.transform.position;
            EnemyShoot();


        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            EnemyShoot();

        }
        
        


       
        


    }
    void EnemyShoot()
    {
        if (timeBtwShots <= 0)
        {
            //Instantiate(projectile, transform.position, transform.rotation);
            GameObject bullet = Instantiate(projectile, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
            EnemyBulletSound.Play();
            Instantiate(EnemyBulletParticle, firepoint.position, firepoint.rotation);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
