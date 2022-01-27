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

    private void Update()
    {
        distanciaJugador = Vector2.Distance(player.position, rb2d.position);

        if(distanciaJugador <= distanciaInteractuar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                boyDialog.index = 0;
                boyDialog.boyDialog();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar); ;
    }
}
