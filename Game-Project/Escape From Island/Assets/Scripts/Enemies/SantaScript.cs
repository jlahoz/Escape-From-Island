using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaScript: MonoBehaviour
{
    // Movimiento
    public static float velocity;
    private float distanciaJugador;
    public float distanciaVision;
    public float distanciaAtaque;
    private bool Ground;
    // Ataque
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask KnightLayer;

    //Objetos 
    public GameObject Knight;
    public CapsuleCollider2D cc2D;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb2D;

    // Aturdir
    public static float dazedTime;
    public static float isAlive = 4;
    public static float startDazedTime = 3;
    private bool aturdido = false;


    void start()
    {

    }

    private void Update()
    {

        // Seguimiento del Personaje principal.
        Vector3 direction = Knight.transform.position - transform.position;

        // Rotar Santa en funcion de Knight
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        }
        else
        {
            transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);
        }

        // Calculo distancia del enemigo al jugador.
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        // Sistema para Aturdir
        if (dazedTime <= 0)
        {
            aturdido = false;
            velocity = 2f;
        }
        else
        {
            Debug.Log("Aturdido");
            velocity = 0f;
            aturdido = true;
            dazedTime -= Time.deltaTime;
        }

        //Evitar bug Volar.
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Ground = true;
        }
        else
        {
            Ground = false;
        }

        //Control de movimiento.
        if (distanciaJugador < distanciaVision && Ground)
        {
            Move();

            // Control de ataque por distancia y control de aturdir.
            if (distanciaJugador < distanciaAtaque && aturdido == false)
            {
                Attack();
            }
        }
        else
        {
            animator.SetBool("running", false);
        }
    }

    private void Move()
    {
        animator.SetBool("isAttacking", false);
        if (aturdido)
        {
            animator.SetBool("running", false);
            velocity = 0f;
        }
        else
        {
            animator.SetBool("running", true);
            velocity = 2f;
        }
        cc2D.size = new Vector2(3.295159f, 5.39774f);
        cc2D.offset = new Vector2(-0.7227471f, 0.1971104f);
        Vector2 objetivo = new Vector2(player.position.x, rb2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, objetivo, velocity * Time.deltaTime);
        rb2D.MovePosition(newPosition);

    }

    private void Attack()
    {
        cc2D.size = new Vector2(4.711664f, 4.711664f);  // Cambiar el Capsule Collider al cambiar animacion para que no flote.
        cc2D.offset = new Vector2(-0.9738923f, -0.3363523f);
        velocity = 3f;
        animator.SetBool("isAttacking", true);

        // Daño del Knight
        Collider2D[] hitKnight = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, KnightLayer);

        foreach (Collider2D knight in hitKnight)
        {
            knight.GetComponent<Knight>().TakeDamage(attackDamage);
        }
    }

    // Previsualizar distancias de movimiento y ataques.

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaVision);
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

