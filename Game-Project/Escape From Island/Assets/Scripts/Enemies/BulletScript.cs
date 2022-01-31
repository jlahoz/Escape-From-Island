using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private Vector2 Direction;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb2d.velocity = Direction * speed;
    }

    public void setDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Daño y destruccion de la bala.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Knight knightDamage = collision.GetComponent<Knight>();
            knightDamage.TakeDamage(AdventureScript.bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject, 10);
        }
    }
}
