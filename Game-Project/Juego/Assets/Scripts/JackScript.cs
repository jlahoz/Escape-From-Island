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

    public CapsuleCollider2D cc2D;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb2D;
    public float distancia = 2.0f;

    void start()
    {
    }

    private void Update()
    {

        // Seguimiento del Personaje principal.

        Vector3 direction = Knight.transform.position - transform.position;
        
        if(direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        }else
        {
            transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);
        }

        // Calculo distancia al jugador.
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);


        //Control de movimiento.
        if (distanciaJugador < distanciaVision)
        {
            Move();
            // Control de ataque.
            if (distanciaJugador < distanciaAtaque)
            {
                cc2D.size = new Vector2(4f, 4.5f);
                Attack();
            }
        } else
        {
            animator.SetBool("running", false);
        }
    }

    private void Move()
    {
        Debug.Log("mover");
        cc2D.size = new Vector2(4f, 6f);
        animator.SetBool("running", true);
        animator.SetBool("isAttacking", false);
        Vector2 objetivo = new Vector2(player.position.x, rb2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, objetivo, velocity * Time.deltaTime);
        rb2D.MovePosition(newPosition);

    }

    private void Attack()
    {
        Debug.Log("Ataque");
        animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaVision);
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}
