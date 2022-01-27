using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureScript: MonoBehaviour
{
    // Movimiento
    public static float velocity;
    private float distanciaJugador;
    public float distanciaVision;
    public float distanciaDisparo;
    public float distanciaArrastre;
    public float distanciaMelee;
    private bool Ground;
    // Ataque
    public int attackDamage = 2;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask KnightLayer;
    float attackAnimationTime = 0f;
    public float nextAttack;
    public float nextAttackAnimation;
    float nextAttackTime = 0f;


    //Objetos 
    public GameObject Knight;
    public CapsuleCollider2D cc2D;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb2D;

    // Aturdir
    public static float dazedTime;
    public static float startDazedTime = 3;
    private bool aturdido = false;


    private void Update()
    {

        // Seguimiento del Personaje principal.
        Vector3 direction = Knight.transform.position - transform.position;

        // Rotar Jack en funcion de Knight
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.2872167f, 0.2872167f, 0.2872167f);
        }
        else
        {
            transform.localScale = new Vector3(-0.2872167f, 0.2872167f, 0.2872167f);
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
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.8f))
        {
            Ground = true;
        }
        else
        {
            Ground = false;
        }

        //Control de movimiento y ataque.
        if (distanciaJugador < distanciaVision && Ground)
        {
            Move();

            if (distanciaJugador <= distanciaMelee)
            {
                // Ataque melee
                Debug.Log("Melee");
                meleeAttack();
                
            } else if (distanciaJugador <= distanciaArrastre)
            {
                //Ataque arrastre
                Debug.Log("Arrastre");
                slideAttack();
            } else if (distanciaJugador <= distanciaDisparo)
            {
                //Ataque disparando
                Debug.Log("Disparo");
                shootAttack();
            }
        }
        else
        {
            animator.SetBool("running", false);
        }
    }

    private void Move()
    {
        animator.SetBool("slideAttack", false);
        animator.SetBool("meleeAttack", false);
        animator.SetBool("shootAttack", false);

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
        cc2D.size = new Vector2(2.652733f, 4.914186f);
        cc2D.offset = new Vector2(-0.4295662f, 0.0467446f);
        Vector2 objetivo = new Vector2(player.position.x, rb2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, objetivo, velocity * Time.deltaTime);
        rb2D.MovePosition(newPosition);

    }
    
    private void slideAttack()
    {
        cc2D.size = new Vector2(3.708249f, 3.978895f);   // Cambiar el CC al cambiar de animacion.
        cc2D.offset = new Vector2(-0.6323901f, -0.5707018f);
        velocity = 3f;
        animator.SetBool("slideAttack", true);

        // Daño del Knight
        Collider2D[] hitKnight = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, KnightLayer);

        foreach (Collider2D knight in hitKnight)
        {
            knight.GetComponent<Knight>().TakeDamage(attackDamage);
        }
    }

    private void meleeAttack()
    {

        Collider2D[] hitKnight = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, KnightLayer);
        animator.SetBool("running" , false);
        if(Time.time >= nextAttackTime)
        {
            animator.SetBool("meleeAttack", true);

            if (Time.time >= attackAnimationTime)
            {
                foreach (Collider2D knight in hitKnight)
                {
                    knight.GetComponent<Knight>().TakeDamage(attackDamage);
                }
                attackAnimationTime = Time.time + nextAttackAnimation;
            }
            nextAttackTime = Time.time + nextAttack;
        }
    }

    private void shootAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetBool("shootAttack", true);
            nextAttackTime = Time.time + nextAttack;
            // Instanciar prefabs de balas
        }
   
    }






    // Previsualizar distancias de movimiento y ataques.

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaVision);
        Gizmos.DrawWireSphere(transform.position, distanciaArrastre);
        Gizmos.DrawWireSphere(transform.position, distanciaDisparo);
        Gizmos.DrawWireSphere(transform.position, distanciaMelee);
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
