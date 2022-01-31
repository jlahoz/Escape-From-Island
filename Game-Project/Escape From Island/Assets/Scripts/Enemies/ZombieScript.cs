using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript: MonoBehaviour
{
    // Movimiento
    public float velocity;
    private float distanciaJugador;
    public float distanciaVision;
    public float distanciaAtaque;
    private bool Ground;
    // Ataque
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask KnightLayer;
    public float nextAttack;
    public float nextAttackAnimation;
    float nextAttackTime = 0f;
    float attackAnimationTime = 0f;

    //Objetos 
    public GameObject Knight;
    public CapsuleCollider2D cc2D;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb2D;

    void start()
    {

    }

    private void Update()
    {

        // Seguimiento del Personaje principal.
        Vector3 direction = Knight.transform.position - transform.position;

        // Rotar Jack en funcion de Knight
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.1754747f, 0.1754747f, 0.1754747f);
        }
        else
        {
            transform.localScale = new Vector3(-0.1754747f, 0.1754747f, 0.1754747f);
        }

        // Calculo distancia del enemigo al jugador.
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        //Evitar bug Volar.
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Ground = true;
        }
        else
        {
            Ground = false;
        }

        if (distanciaJugador < distanciaVision && Ground)
        {
            Move();
            if (distanciaJugador < distanciaAtaque && Time.time >= nextAttackTime)
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
        animator.SetBool("isAttacking", false);
        animator.SetBool("running", true);
        Vector2 objetivo = new Vector2(player.position.x, rb2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, objetivo, velocity * Time.deltaTime);
        rb2D.MovePosition(newPosition);

    }

    private void Attack()
    {
        Debug.Log("ataque");
        animator.SetBool("isAttacking", true);
        //Daño del Knight
        Collider2D[] hitKnight = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, KnightLayer);

        if (Time.time >= attackAnimationTime)
        {
            foreach (Collider2D knight in hitKnight)
            {
                knight.GetComponent<Knight>().TakeDamage(attackDamage);
            }
            attackAnimationTime = Time.time + nextAttackAnimation;
        }
        nextAttackTime = Time.time + nextAttack;
        Debug.Log("cerrado");
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
