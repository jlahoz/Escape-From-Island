using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Objeto del Caballero
    public GameObject Knight;

    // Update is called once per frame
    void Update()
    {
        // Sistema de seguimiento de la camara al caballero.
        Vector3 position = transform.position;
        position.x = Knight.transform.position.x;
        position.y = Knight.transform.position.y;
        transform.position = position;
    }
}
