using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Knight;

    void Update()
    {
        // Sistema de seguimiento de la camara al Knight.
        Vector3 position = transform.position;
        position.x = Knight.transform.position.x;
        position.y = Knight.transform.position.y;
        transform.position = position;
    }
}
