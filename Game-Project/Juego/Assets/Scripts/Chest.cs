using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Variables Cofre
    private float distanciaJugador;
    public float distanciaInteractuar;
    private bool cofreAbierto = false;

    // Objetos
    public GameObject TextoUI;
    public GameObject cofreCerrado;
    public GameObject SpriteCofreAbierto;
    public Rigidbody2D rb2D;
    public Transform player;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    void Update()
    {
        // Calculo distancia Jugador al Cofre
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        if (distanciaJugador <= distanciaInteractuar && cofreAbierto == false)
        {
            // Mostrar texto en la UI para abrir.
            TextoUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                cofreAbierto = true;
                animator.SetTrigger("openChest");
            }
        } else
        {
            TextoUI.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar);;
    }


}
