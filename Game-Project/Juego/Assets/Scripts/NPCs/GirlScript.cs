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
    public GameObject eKeyIcon;
    private bool pulsado = false;

    private void Update()
    {
        distanciaJugador = Vector2.Distance(player.position, rb2d.position);

        if (distanciaJugador <= distanciaInteractuar && !pulsado)
        {
            pulsado = true;
            eKeyIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                girlDialog.indexGirl = 0;
                girlDialog.girlDialog();
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
