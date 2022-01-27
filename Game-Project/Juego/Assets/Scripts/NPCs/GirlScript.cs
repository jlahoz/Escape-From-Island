using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScript : MonoBehaviour
{
    private float distanciaJugador;
    public float distanciaInteractuar;

    public Rigidbody2D rb2d;
    public Transform player;
    public Dialog girlDialog;

    private void Update()
    {
        distanciaJugador = Vector2.Distance(player.position, rb2d.position);

        if (distanciaJugador <= distanciaInteractuar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                girlDialog.indexGirl = 0;
                girlDialog.girlDialog();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar); ;
    }
}
