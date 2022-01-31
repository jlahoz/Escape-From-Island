using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Camera MiniMapCam;

    public void AumentarZoom()
    {
        if (MiniMapCam.orthographicSize > 2f)
        {
            MiniMapCam.orthographicSize -= 0.4f;
        }
    }
    public void ReducirZoom()
    {
        if(MiniMapCam.orthographicSize < 10f)
        {
            MiniMapCam.orthographicSize += 0.4f;
        }
    }

}

