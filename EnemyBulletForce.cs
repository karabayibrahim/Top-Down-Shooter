using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletForce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Transform player;
    public Vector2 Target;
    private Vector2 movement;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("RifleSoldier").transform;
        Target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            DestroyProjectile();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RifleSoldier"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
