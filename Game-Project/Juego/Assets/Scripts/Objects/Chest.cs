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
    public Rigidbody2D rb2D;
    public Transform player;
    private Transform posicionCofre;
    public Animator animator;

    public GameObject [] items;

    void start()
    {
       
    }

    void Update()
    {
        posicionCofre = GetComponent<Transform>();
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
                int random = Random.Range(1, 101);

                if (random <= 50)
                {
                    // Cofre vacio
                    Debug.Log("Cofre vacio");
                } else if (random > 50 && random <= 75)
                {
                    // Items comunes
                    Instantiate(items[0], posicionCofre, false);
                } else if (random > 75 && random <= 90)
                {
                    // Items raros
                    Instantiate(items[1], posicionCofre, false);
                    Instantiate(items[2], posicionCofre, false);
                } else
                {
                    // Items muy raros
                    Instantiate(items[3], posicionCofre, false);
                }
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
