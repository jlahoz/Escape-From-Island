using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{
    private float distanciaJugador;
    public float distanciaInteractuar;

    public Rigidbody2D rb2d;
    public Transform player;
    public Dialog boyDialog;
    public GameObject eKeyIcon;
    private bool pulsado = false;

    private void Update()
    {
        distanciaJugador = Vector2.Distance(player.position, rb2d.position);

        if(distanciaJugador <= distanciaInteractuar && !pulsado)
        {
            eKeyIcon.SetActive(true);    // Tecla para interactuar por distancia

            // Sistema de dialogo
            if (Input.GetKeyDown(KeyCode.E))
            {
                pulsado = true; 
                boyDialog.indexBoy = 0;
                boyDialog.boyDialog();
            }
        } else
        {
            eKeyIcon.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar); ;
    }
}
