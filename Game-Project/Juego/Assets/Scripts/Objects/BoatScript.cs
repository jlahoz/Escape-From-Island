using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public float distanciaInteractuar;
    private float distanciaJugador;

    public static bool canUseItem = false;

    private Transform KnightPosition;
    private Rigidbody2D rb2d;

    public GameObject RedSlot1;
    public GameObject RedSlot2;
    public GameObject RedSlot3;
    public GameObject GreenSlot1;
    public GameObject GreenSlot2;   
    public GameObject GreenSlot3;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        KnightPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        distanciaJugador = Vector2.Distance(KnightPosition.position, rb2d.position);

        if (distanciaJugador <= distanciaInteractuar)
        {
            canUseItem = true;

            RedSlot1.SetActive(true);
            RedSlot2.SetActive(true);
            RedSlot3.SetActive(true);

            if (Items.usedWood)
            {
                RedSlot1.SetActive(false);
                GreenSlot1.SetActive(true);
            }
            if (Items.usedStone)
            {
                RedSlot2.SetActive(false);
                GreenSlot2.SetActive(true);
            }
            if (Items.usedRope)
            {
                RedSlot3.SetActive(false);
                GreenSlot3.SetActive(true);
            }


        } else
        {
            canUseItem = false;

            RedSlot1.SetActive(false);
            RedSlot2.SetActive(false);
            RedSlot3.SetActive(false);
            GreenSlot1.SetActive(false);
            GreenSlot2.SetActive(false);
            GreenSlot3.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaInteractuar); ;
    }
}


