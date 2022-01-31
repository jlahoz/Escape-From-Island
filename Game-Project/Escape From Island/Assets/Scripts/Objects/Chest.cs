using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private float distanciaJugador;
    public float distanciaInteractuar;
    private bool cofreAbierto = false;


    public GameObject TextoUI;
    public Rigidbody2D rb2D;
    public Transform player;
    private Transform posicionCofre;
    public Animator animator;

    public GameObject [] items;

    void Update()
    {
        posicionCofre = GetComponent<Transform>();

        // Calculo distancia Knight al Cofre
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        if (distanciaJugador <= distanciaInteractuar && cofreAbierto == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextoUI.SetActive(false);
                cofreAbierto = true;     // Control sobre apertura del cofre
                animator.SetTrigger("openChest");

                // Sistema de spawn de objetos de forma aleatoria

                int random = Random.Range(1, 101);

                if (random <= 40)
                {
                    // Cofre vacio
                    Debug.Log("Cofre vacio");
                }
                else if (random > 40 && random <= 50)
                {
                    Instantiate(items[4],posicionCofre.position, Quaternion.identity);
                }else if (random > 50 && random <= 75)
                {
                    // Items comunes
                    Instantiate(items[0], posicionCofre.position, Quaternion.identity);
                } else if (random > 75 && random <= 90)
                {
                    // Items raros
                    Instantiate(items[1], posicionCofre.position, Quaternion.identity);
                    Instantiate(items[2], posicionCofre.position, Quaternion.identity);
                } else
                {
                    // Items muy raros
                    Instantiate(items[3], posicionCofre.position, Quaternion.identity);
                }
            }
        } 
    }

    // Control de spawn del icono por trigger con el cofre.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !cofreAbierto)
        {
            TextoUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TextoUI.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar);;
    }


}
