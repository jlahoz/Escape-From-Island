using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    //private Transform player;

    private KnightMovement KnightMovement;

    private void start()
    {
         //player = GameObject.Find("Knight").GetComponent<Transform>();
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(KnightMovement.player.position.x + 0.3f, KnightMovement.player.position.y - 0.3f);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
