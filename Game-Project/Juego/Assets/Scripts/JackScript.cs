using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackScript : MonoBehaviour
{
    public GameObject Knight;

    public float velocity;
    private float distanciaJugador;
    public float distanciaVision;
    public float distanciaAtaque;

    public Animator animator;
    public Transform player;
    public Rigidbody2D rb2D;
    public float distancia = 2.0f;

    void start()
    {

    }

    private void Update()
    {
        Vector3 direction = Knight.transform.position - transform.position;
        if(direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        }else
        {
            transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);
        }

        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        if (distanciaJugador < distanciaVision)
        {
            Move();
            if (distanciaJugador < distanciaAtaque)
            {
                Attack();
            }
        } else
        {
            animator.SetBool("running", false);
        }


    }

    private void Move()
    {
        animator.SetBool("running", true);
        Vector2 objetivo = new Vector2(player.position.x, player.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, objetivo, velocity * Time.deltaTime);
        rb2D.MovePosition(newPosition);
    }

    private void Attack()
    {
        Debug.Log("Ataque");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaVision);
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}
