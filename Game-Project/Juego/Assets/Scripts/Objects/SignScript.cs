using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{

    private float distanciaJugador;
    public float distanciaInteractuar;
    public static bool cartelAbierto = false;

    public GameObject TextoUI;
    public GameObject Sign;
    public Rigidbody2D rb2D;
    public Transform player;

    void Update()
    {
        distanciaJugador = Vector2.Distance(player.position, rb2D.position);

        if (distanciaJugador <= distanciaInteractuar)
        {
            // Mostrar texto en la UI para abrir.
            TextoUI.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Sign.SetActive(true);
                cartelAbierto = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && cartelAbierto)
            {
                Sign.SetActive(false);
                cartelAbierto = false;
            }
        }
        else
        {
            TextoUI.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar); ;
    }
}
